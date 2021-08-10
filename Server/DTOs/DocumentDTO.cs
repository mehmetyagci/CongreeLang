using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTOs
{
    public class DocumentDTO
    {
        public long Id { get; set; }
        public string Data { get; set; }
        public DateTime StartDate { get; set; }
    }
}
