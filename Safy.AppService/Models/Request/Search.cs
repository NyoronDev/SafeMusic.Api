using System;
using System.Collections.Generic;
using System.Text;

namespace Safy.AppService.Models.Request
{
    public class Search
    {
        public string Query { get; set; }
        public string Type { get; set; }
        public string Market { get; set; }
        public int Limit { get; set; }
        public int OffSet { get; set; }
        public string IncludeExternal { get; set; }
    }
}
