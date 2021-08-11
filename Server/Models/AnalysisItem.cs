using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class AnalysisItem
    {
        public long Id { get; set; }

        public long AnalysisId { get; set; }
        public Analysis Analysis { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }

        public string Word { get; set; }
        public int Count { get; set; }
    }
}
