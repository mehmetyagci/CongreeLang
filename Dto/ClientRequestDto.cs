using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ClientRequestDto
    {
        public int Index { get; set; }

        public string XmlFilePath { get; set; }

        public string SearchTags { get; set; }
    }
}
