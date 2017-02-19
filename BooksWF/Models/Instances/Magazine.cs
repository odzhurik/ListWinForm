using BooksWF.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    internal class Magazine:PolygraphicItem, IIssueItem
    {
        public string IssueNumber { get; set; }
    }
}
