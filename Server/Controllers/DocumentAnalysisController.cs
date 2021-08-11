using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Db;
using Server.DTOs;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentAnalysisController : ControllerBase
    {

        private readonly CongreeLangDbContext _context;

        public DocumentAnalysisController(CongreeLangDbContext context)
        {
            _context = context;
        }

        // POST: api/Documents
        [HttpPost]
        public async Task<ActionResult<DocumentAnalysisResponseDTO>> AnalysisDocument([FromForm] DocumentAnalysisRequestDTO request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model is invalid.");
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(request.Data);

                Document document = new Document();
                document.Data = request.Data;
                document.StartDate = DateTime.UtcNow;

                List<Tag> tags = new List<Tag>();

                var tagList = request.Tags.Split(';').ToList();

                Dictionary<string, List<string>> dictionaryDocumentTagWithWholeWords = new Dictionary<string, List<string>>();

                foreach (var tagItem in tagList)
                {
                    Tag tag = new Tag();
                    tag.Document = document;
                    tag.Content = tagItem;

                    XmlNodeList nodes = doc.GetElementsByTagName(tagItem);
                    Console.WriteLine("All capitals:");

                    StringBuilder stringBuilder = new StringBuilder();
                    List<string> sentenceWholeWords = new List<string>();
                    foreach (XmlNode node in nodes)
                    {
                        var sentence = node.InnerText;
                        Console.WriteLine(sentence);
                        TagDetail tagDetail = new TagDetail();
                        tagDetail.Tag = tag;
                        tagDetail.Content = sentence;

                        tag.TagDetails.Add(tagDetail);

                        stringBuilder.Append(sentence);
                        stringBuilder.Append(Environment.NewLine);

                        char[] charsToTrim = { ';', ',', '.', ' ', '\t', '\'' };
                        string[] words = sentence.ToLower().Split();
                        foreach (string word in words)
                        {
                            string trimmedWord = word.Trim(charsToTrim);
                            Console.WriteLine(word.Trim(charsToTrim));
                            if (!string.IsNullOrWhiteSpace(trimmedWord))
                            {
                                sentenceWholeWords.Add(trimmedWord);
                            }
                        }
                    }

                    dictionaryDocumentTagWithWholeWords.Add(tagItem, sentenceWholeWords);
                    document.Tags.Add(tag);
                }

                document.EndDate = DateTime.UtcNow;
                // Saving All Items to Db
                await _context.Documents.AddAsync(document);
                await _context.SaveChangesAsync();

                foreach (var dictionaryDocumentTagWithWholeWord in dictionaryDocumentTagWithWholeWords)
                {
                    var duplicateWordsWithCount = dictionaryDocumentTagWithWholeWord.Value
                        .GroupBy(x => x)
                        .Where(z => z.Count() > 1)
                        .Select(y => new { Word = y.Key, Count = y.Count() });
                }

                return Ok("heyo :)");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occured!");
                throw;
            }
        }
    }
}