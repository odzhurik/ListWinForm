using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.Instances
{
    public class Newspaper : PolygraphicItem,IIssueItem,IPeriodicalItem,IArticle
    {
        public string Periodical { get; set; }
        public string IssueNumber { get; set; }
        public List<AuthoredItem> Articles { get; set; }
        public Newspaper()
        {
            Articles = new List<AuthoredItem>();
        }

    }
}
