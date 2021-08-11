using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class TagDto
    {
        public string Content { get; set; }

        public List<AnalysisResultDto> AnalysisResultDtos { get; set; } = new List<AnalysisResultDto>();
    }
}