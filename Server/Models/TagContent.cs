using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class TagContent
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}