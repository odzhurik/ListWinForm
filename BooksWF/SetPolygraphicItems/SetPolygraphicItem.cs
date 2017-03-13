using BooksWF.Models.Instances;
using CardProject.Models;
using System.Collections.Generic;

namespace BooksWF.Models.AddItem
{
    public class SetPolygraphicItem
    {
        public AuthoredItem SetAuthoredItem(string title, List<string> authors, int pages)
        {
            AuthoredItem book = new AuthoredItem();
            book.Title = title;
            book.Authors.AddRange(authors);
            book.Pages = pages;
            return book;

        }
        public Magazine SetMagazine(string title, string issue, List<AuthoredItem> articles)
        {
            Magazine magazine = new Magazine();
            magazine.Title = title;
            magazine.IssueNumber = issue;
            magazine.Articles = articles;
            return magazine;
        }
        public Newspaper SetNewspaper(string title, string issue, string periodical, List<AuthoredItem> articles)
        {
            Newspaper newspaper = new Newspaper();
            newspaper.Title = title;
            newspaper.IssueNumber = issue;
            newspaper.Periodical = periodical;
            newspaper.Articles.AddRange(articles);
            return newspaper;
        }
    }
}
