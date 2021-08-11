using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Analysis
    {
        public long Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double ElapsedMiliseconds { get; set; }


        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public List<AnalysisItem> AnalysisItems { get; set; } = new List<AnalysisItem>();
    }
}
