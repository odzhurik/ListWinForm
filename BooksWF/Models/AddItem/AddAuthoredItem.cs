using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.AddItem
{
   public class SetPolygraphicItem
    {
        public PolygraphicItem SetAuthoredItem(string title, List<string> authors, int pages)
        {
            AuthoredItem book = new AuthoredItem();
            book.Title = title;
            book.Authors.AddRange(authors);
            book.Pages = pages;
            return book;

        }
        public void Add(string title, string issue, List<AuthoredItem> articles, List<PolygraphicItem> list)
        {
            Magazine magazine = new Magazine();
            SetItem itemSetter = new SetItem();
            magazine.Title = title;
            magazine.IssueNumber = issue;
            magazine.Articles = articles;
            list.Add(magazine);
        }
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
