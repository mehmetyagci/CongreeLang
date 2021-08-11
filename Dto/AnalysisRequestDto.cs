using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class AnalysisRequestDto
    {
        /// <summary>
        /// XML Data 
        /// </summary>
        [Required(ErrorMessage = "XML data is required.")]
        [MinLength(10, ErrorMessage = "XML data is too short.")]
        public string Data { get; set; }

        /// <summary>
        /// Comma separated Tags
        /// Example: "p;li;"
        /// </summary>
        [Required(ErrorMessage = "Comma (;) separated tag or tags info required.")]
        [MinLength(1, ErrorMessage = "Tags info is too short.")]
        public string Tags { get; set; }
    }
}
