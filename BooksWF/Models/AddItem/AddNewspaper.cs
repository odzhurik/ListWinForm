using BooksWF.Models.Instances;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.AddItem
{
   public class AddNewspaper
    {
        public void Add(string title, string issue, string periodical, List<AuthoredItem> articles)
        {
            Newspaper newspaper = new Newspaper();
            SetItem itemSetter = new SetItem();
            newspaper.Title = title;
            newspaper.IssueNumber = issue;
            newspaper.Periodical = periodical;
            newspaper.Articles.AddRange(articles);
            NewspaperList.GetNewspaperList(itemSetter).AddItem(newspaper);
        }
    }
}
