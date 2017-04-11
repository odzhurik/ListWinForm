using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Entities
{
    public class Newspaper : PolygraphicItem
    {
        public string Periodical { get; set; }
        public string IssueNumber { get; set; }
        public List<Book> Articles { get; set; }
        public Newspaper()
        {
            Articles = new List<Book>();
        }

    }
}
