using BooksWF.Models.Instances;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    public class Magazine:PolygraphicItem, IIssueItem
    {
        public string IssueNumber { get; set; }
        public List<AuthoredItem> Articles { get; set; }
        public Magazine()
        {
            Articles = new List<AuthoredItem>();
        }
    }
}
