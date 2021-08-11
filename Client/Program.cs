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

namespace Client
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
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
            if (ReferenceEquals(fi, null))
            {
                Console.WriteLine("XML File path is wrong");
                return;
            }

            string searchTags = args[1];

            Console.WriteLine($"Document processing started at {DateTime.Now.ToLongTimeString().ToString()}");
            await CallWebAPIAsync(xmlFilePath, searchTags);
            Console.WriteLine($"Document processing ended at {DateTime.Now.ToLongTimeString().ToString()}");
            Console.WriteLine("Press any key to close the program");
            Console.ReadLine();

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
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://localhost:44369/api/DocumentAnalysis"))
                {
                    var contentList = new List<string>();
                    contentList.Add($"data={xmlString}");
                    contentList.Add($"tags={searchTags}");
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    string rep = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("response:" + response);
                    Console.WriteLine("rep:" + rep);

                }
            }
        }

    } // end of class
} // end of namespace
