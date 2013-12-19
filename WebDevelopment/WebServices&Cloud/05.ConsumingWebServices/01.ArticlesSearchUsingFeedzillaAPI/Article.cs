using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesSearchUsingFeedzillaAPI
{
    public class Article
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Publish_Date { get; set; }
        public string Source { get; set; }
        public string Source_Url { get; set; }
    }
}
