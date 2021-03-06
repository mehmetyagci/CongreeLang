using Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

                if (args.Length % 2 != 0)
                {
                    Console.WriteLine("Arguments are not valid");
                    return;
                }

                for (int index = 0; index < args.Length; index = index + 2)
                {
                    string xmlFilePath = args[index];
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
                        Console.WriteLine($"XML File path is wrong:{xmlFilePath}");
                        return;
                    }
                }

                List<ClientRequestDto> clientRequestDtoList = new List<ClientRequestDto>();
                for (int index = 0; index < args.Length; index = index + 2)
                {
                    string xmlFilePath = args[index];
                    string searchTags = args[index + 1];

                    clientRequestDtoList.Add(new ClientRequestDto
                    {
                        Index = (index / 2) + 1,
                        XmlFilePath = xmlFilePath,
                        SearchTags = searchTags
                    });
                }

                var clientMessageDtoList = await PostsAsync(clientRequestDtoList);
                clientMessageDtoList = clientMessageDtoList.OrderBy(x => x.Index).ToList(); 
                foreach (var clientMessageDto in clientMessageDtoList)
                {
                    foreach (var message in clientMessageDto.Messages)
                    {
                        Console.WriteLine(message);
                    }
                }

                Console.WriteLine("Press any key to close the program");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured. Details:{ex.ToString()}");
            }
        } // end of main

        static async Task<List<ClientMessageDto>> PostsAsync(List<ClientRequestDto> clientRequestDtoList)
        {
            var sw = new Stopwatch();
            sw.Start();

            var resultCollection = new ConcurrentBag<ClientMessageDto>();
            await Task.Run(() =>
            {
                Parallel.ForEach(clientRequestDtoList, (clientRequestDto) =>
                {
                    Console.WriteLine($"Index - {clientRequestDto.Index} PostsAsync Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                    var messsages = CallWebAPIAsync(clientRequestDto).GetAwaiter().GetResult();
                    resultCollection.Add(new ClientMessageDto
                    {
                        Index = clientRequestDto.Index,
                        Messages = messsages
                    });
                });
            });

            sw.Stop();
            Console.WriteLine("PostsAsync Miliseconds: " + sw.ElapsedMilliseconds);
            Console.WriteLine("");
            Console.WriteLine("");

            return resultCollection.ToList();
        }

        private static async Task<List<string>> CallWebAPIAsync(ClientRequestDto clientRequestDto)
        {
            List<string> messages = new List<string>();
            try
            {
                int index = clientRequestDto.Index;
                string xmlFilePath = clientRequestDto.XmlFilePath;
                string searchTags = clientRequestDto.SearchTags;

                messages.Add($"Index - {index} - {xmlFilePath} - {searchTags} Document processing starting ");

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
                    httpClient.Timeout = TimeSpan.FromMinutes(10); // Set HttpClient Timeout to 10 Minutes 
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
                            messages.Add($"Server request succeeded");
                            string responseData = await response.Content.ReadAsStringAsync();
                            //string responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                            AnalysisResponseDto analysisResponseDto = JsonConvert.DeserializeObject<AnalysisResponseDto>(responseData);
                            messages.Add($"Analysis Id: {analysisResponseDto.AnalysisId} ");
                            messages.Add($"Started at {analysisResponseDto.StartDate.ToString("dd.MM.yyyy HH:mm:ss.ffff")}");
                            messages.Add($"Ended at {analysisResponseDto.EndDate.ToString("dd.MM.yyyy HH:mm:ss.ffff")}");
                            messages.Add($"Total Miliseconds: {analysisResponseDto.ElapsedMiliseconds} ms.");

                            messages.Add(Environment.NewLine);
                            foreach (var analysisTagDTO in analysisResponseDto.AnalysisTagDtos)
                            {
                                messages.Add($"Duplicate words and count infos for tag:{analysisTagDTO.Content}");
                                foreach (var analysisResultDto in analysisTagDTO.AnalysisResultDtos)
                                {
                                    messages.Add($"\t {analysisResultDto.Word} - {analysisResultDto.Count}");
                                }
                                messages.Add(Environment.NewLine);
                            }
                        }
                        else
                        {
                            messages.Add($"Server request error. StatusCode:{response.StatusCode}");
                        }
                    }
                }
                messages.Add($"Index - {index} - Document processing ended ");
                messages.Add(Environment.NewLine);
                messages.Add(Environment.NewLine);
            }
            catch (Exception ex)
            {
                messages.Add($"Error occured. Details:{ex.ToString()}");
            }
            return messages;
        }


    } // end of class
} // end of namespace
