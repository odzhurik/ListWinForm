using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Entities
{
    public class Magazine:PolygraphicItem
    {
        public string IssueNumber { get; set; }
        public List<Book> Articles { get; set; }
        public Magazine()
        {
            Articles = new List<Book>();
        }
    }
}
