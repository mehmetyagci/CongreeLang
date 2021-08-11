using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class Document
    {
        public long Id { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
