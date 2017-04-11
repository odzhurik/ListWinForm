using MVP.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MVP.Presenters.Search
{
    public class SearchByAuthor
    {
        private Book SearchInBooks(string author, Book book)
        {
            foreach (string bookAuthor in book.Authors)
            {
                if (bookAuthor.CompareTo(author) == 0)
                {
                    return book;
                }
            }

            return null;
        }
        public List<PolygraphicItem> Search(string author, List<PolygraphicItem> list)
        {
            List<PolygraphicItem> resultList = new List<PolygraphicItem>();
            list.ForEach(x =>
            {
                if (x is Book)
                {
                    Book book = x as Book;
                    Book result = SearchInBooks(author, book);
                    if (result != null)
                    {
                        resultList.Add(result);
                    }
                }
                if (x is Magazine)
                {
                    Magazine magazine = x as Magazine;
                    Magazine result = SearchInMagazines(author, magazine);
                    if (result != null)
                    {
                        resultList.Add(result);
                    }
                }
                if (x is Newspaper)
                {
                    Newspaper newspaper = x as Newspaper;
                    Newspaper result = SearchInNewspapers(author, newspaper);
                    if(result!=null)
                    {
                        resultList.Add(result);
                    }
                }
            }
            );
            return resultList;
        }
        private Newspaper SearchInNewspapers(string author, Newspaper newspaper)
        {
            foreach (Book article in newspaper.Articles)
            {
                foreach (string articleAuthor in article.Authors)
                {
                    if (articleAuthor.CompareTo(author) == 0)
                    {
                        return newspaper;
                    }
                }
            }

            return null;
        }
        private Magazine SearchInMagazines(string author, Magazine item)
        {
            foreach (Book article in item.Articles)
            {
                foreach (string articleAuthor in article.Authors)
                {
                    if (articleAuthor.CompareTo(author) == 0)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

    }
}
