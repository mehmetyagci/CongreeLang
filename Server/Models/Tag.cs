using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string Content { get; set; }

        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public string TagContent { get; set; }
    }
}
