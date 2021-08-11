using Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Db;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly CongreeLangDbContext _context;

        public AnalysisController(CongreeLangDbContext context)
        {
            _context = context;
        }

        // POST: api/Documents
        [HttpPost]
        public async Task<ActionResult<AnalysisResponseDto>> AnalysisDocument([FromForm] AnalysisRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid data");
                }

                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.LoadXml(request.Data);
                }
                catch (Exception xmlEx)
                {
                    return BadRequest("Invalid xml data");
                }

                Document document = new Document();
                DateTime startDate = DateTime.UtcNow;
                document.Date = startDate;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                await SaveDocumentTagTagFieldsToDbAsync(request, xmlDocument, document);

                Dictionary<Tag, List<string>> dictionaryDocumentTagWithWords = new Dictionary<Tag, List<string>>(); 
                FindDocumentTagWithWords(document, dictionaryDocumentTagWithWords);

                Analysis analysis = new Analysis();
                analysis.Document = document;
                analysis.StartDate = startDate;

                foreach (var dictionaryDocumentTagWithWholeWord in dictionaryDocumentTagWithWords)
                {
                    var duplicateWordsWithCount = dictionaryDocumentTagWithWholeWord.Value
                        .GroupBy(x => x)
                        .Where(z => z.Count() > 1)
                        .Select(y => new { Word = y.Key, Count = y.Count() })
                        .OrderByDescending(t => t.Count)
                        .ToList();

                    List<AnalysisItem> analysisResultList = new List<AnalysisItem>();
                    foreach (var duplicateWordWithCount in duplicateWordsWithCount)
                    {
                        AnalysisItem analysisResult = new AnalysisItem();
                        analysisResult.Analysis = analysis;
                        analysisResult.Tag = dictionaryDocumentTagWithWholeWord.Key;

                        analysisResult.Word = duplicateWordWithCount.Word;
                        analysisResult.Count = duplicateWordWithCount.Count;

                        analysisResultList.Add(analysisResult);
                    }
                    analysis.AnalysisItems.AddRange(analysisResultList);
                }

                stopwatch.Stop();
                TimeSpan timeTaken = stopwatch.Elapsed;
                double elapsedMiliseconds = timeTaken.TotalMilliseconds;
                DateTime endDate = startDate.Add(timeTaken);
                Console.WriteLine($"Time elapsed milliseconds: {elapsedMiliseconds}");

                analysis.EndDate = endDate;
                analysis.ElapsedMiliseconds = elapsedMiliseconds;

                await _context.Analyzes.AddAsync(analysis);
                await _context.SaveChangesAsync();

                AnalysisResponseDto analysisResponseDTO = new AnalysisResponseDto();
                analysisResponseDTO.AnalysisId = analysis.Id;
                analysisResponseDTO.StartDate = analysis.StartDate;
                analysisResponseDTO.EndDate = analysis.EndDate;
                analysisResponseDTO.ElapsedMiliseconds = analysis.ElapsedMiliseconds;

                foreach (var dictionaryDocumentTagWithWholeWord in dictionaryDocumentTagWithWords)
                {
                    TagDto tagDTO = new TagDto();
                    tagDTO.Content = dictionaryDocumentTagWithWholeWord.Key.Content;

                    var analysisResults = analysis.AnalysisItems.Where(x => x.TagId == dictionaryDocumentTagWithWholeWord.Key.Id)
                                                                        .OrderByDescending(y => y.Count);
                    foreach (var analysisResult in analysisResults)
                    {
                        AnalysisResultDto analysisResultDTO = new AnalysisResultDto();
                        analysisResultDTO.Word = analysisResult.Word;
                        analysisResultDTO.Count = analysisResult.Count;

                        tagDTO.AnalysisResultDtos.Add(analysisResultDTO);
                    }

                    analysisResponseDTO.AnalysisTagDtos.Add(tagDTO);
                }

                return Ok(analysisResponseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occured!");
                throw;
            }
        }

        private static void FindDocumentTagWithWords(Document document, Dictionary<Tag, List<string>> dictionaryDocumentTagWithWords)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US", false);
            foreach (var documentTag in document.Tags)
            {
                List<string> sentenceWords = new List<string>();
                foreach (var tagDetail in documentTag.TagDetails)
                {
                    string sentence = tagDetail.Content;
                    char[] charsToTrim = { ';', ',', '.', ':', ' ', '\t', '"', '(', ')', '/' };
                    string[] words = sentence.ToLower(cultureInfo).Split();
                    foreach (string word in words)
                    {
                        string trimmedWord = word.Trim(charsToTrim);
                        if (!string.IsNullOrWhiteSpace(trimmedWord))
                        {
                            sentenceWords.Add(trimmedWord);
                        }
                    }
                }
                dictionaryDocumentTagWithWords.Add(documentTag, sentenceWords);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="xmlDocument"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        private async Task SaveDocumentTagTagFieldsToDbAsync(AnalysisRequestDto request, XmlDocument xmlDocument, Document document)
        {
            document.Data = request.Data;

            var tagList = request.Tags.Split(';').ToList();
            foreach (var strTag in tagList)
            {
                SearchTagAndTagDetails(strTag, xmlDocument, document);
            }

            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }

        private static void SearchTagAndTagDetails(string strTag, XmlDocument xmlDocument, Document document)
        {
            Tag tag = new Tag();
            tag.Document = document;
            tag.Content = strTag;

            XmlNodeList nodes = xmlDocument.GetElementsByTagName(strTag);

            foreach (XmlNode node in nodes)
            {
                var sentence = node.InnerText;
                TagDetail tagDetail = new TagDetail();
                tagDetail.Tag = tag;
                tagDetail.Content = sentence;

                tag.TagDetails.Add(tagDetail);
            }
            document.Tags.Add(tag);
        }
    }
}