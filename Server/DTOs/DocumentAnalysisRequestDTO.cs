using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTOs
{
    public class DocumentAnalysisRequestDTO
    {
        /// <summary>
        /// XML Data 
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Comma separated Tags
        /// Example: "p;li;"
        /// </summary>
        public string Tags { get; set; }
    }
}
