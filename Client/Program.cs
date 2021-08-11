using Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using Newtonsoft.Json;
namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                if (args == null || args.Length == 0)
                {
                    Console.WriteLine("args is required");
                    return;
                }

                if (args.Length != 2)
                {
                    Console.WriteLine("Two arguments are required");
                    return;
                }

                string xmlFilePath = args[0];
                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(xmlFilePath);
                }
                catch (ArgumentException) { }
                catch (System.IO.PathTooLongException) { }
                catch (NotSupportedException) { }
                if (ReferenceEquals(fi, null) || !fi.Exists)
                {
                    Console.WriteLine("XML File path is wrong");
                    return;
                }

                string searchTags = args[1];

                Console.WriteLine($"Document processing starting ");
                await CallWebAPIAsync(xmlFilePath, searchTags);
                Console.WriteLine($"Document processing ended ");
                Console.WriteLine("Press any key to close the program");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        } // end of main

        private static async Task CallWebAPIAsync(string xmlFilePath, string searchTags)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(xmlFilePath))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            string xmlString = sb.ToString();

            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(10); // Set httpClient Timeout to 10 Minutes 
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:44369/api/Analysis"))
                {
                    var contentList = new List<string>();
                    contentList.Add($"data={xmlString}");
                    contentList.Add($"tags={searchTags}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    //Console.WriteLine("response:" + response);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Server request succeeded");
                        string responseData = await response.Content.ReadAsStringAsync();
                        AnalysisResponseDto analysisResponseDto = JsonConvert.DeserializeObject<AnalysisResponseDto>(responseData);
                        Console.WriteLine($"Analysis Id: {analysisResponseDto.AnalysisId} ");
                        Console.WriteLine($"Started at {analysisResponseDto.StartDate.ToString("dd.MM.yyyy HH:mm:ss.ffff")}");
                        Console.WriteLine($"Ended at {analysisResponseDto.EndDate.ToString("dd.MM.yyyy HH:mm:ss.ffff")}");
                        Console.WriteLine($"Total Miliseconds: {analysisResponseDto.ElapsedMiliseconds} ms.");

                        Console.WriteLine();
                        foreach (var analysisTagDTO in analysisResponseDto.AnalysisTagDtos)
                        {
                            Console.WriteLine($"Duplicate words and count infos for tag:{analysisTagDTO.Content}");
                            foreach (var analysisResultDto in analysisTagDTO.AnalysisResultDtos)
                            {
                                Console.WriteLine($"\t {analysisResultDto.Word} - {analysisResultDto.Count}");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Server request error.StatusCode:{response.StatusCode}");
                    }
                }
            }
        }

    } // end of class
} // end of namespace
