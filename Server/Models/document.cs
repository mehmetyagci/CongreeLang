using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string Data { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; internal set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

    }
}
