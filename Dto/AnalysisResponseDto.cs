using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto
{
    public class AnalysisResponseDto
    {
        public long AnalysisId { get; set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public double ElapsedMiliseconds { get; set; }

        public List<TagDto> AnalysisTagDtos { get; set; } = new List<TagDto>();
    }
}
