using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Entities
{
    public class Magazine:PolygraphicItem, IIssueItem,IArticle
    {
        public string IssueNumber { get; set; }
        public List<AuthoredItem> Articles { get; set; }
        public Magazine()
        {
            Articles = new List<AuthoredItem>();
        }
    }
}
