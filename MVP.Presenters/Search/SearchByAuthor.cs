using MVP.Entities;
using System.Collections.Generic;

namespace MVP.Presenters.Search
{
    public class SearchByAuthor
    {
        private List<PolygraphicItem> _list;
        public SearchByAuthor(List<PolygraphicItem> list)
        {
            _list = list;
        }
       public List<PolygraphicItem> Search(string author)
        {
            List<PolygraphicItem> resultList = new List<PolygraphicItem>();
            foreach(PolygraphicItem item in _list)
            {
                if(item is IAuthoredItem)
                {
                    IAuthoredItem itemWithAuthor = item as IAuthoredItem;
                    AuthorSearch(author, item, itemWithAuthor, resultList);
                }
                if(item is IArticle)
                {
                    IArticle articles = item as IArticle;
                    foreach (IAuthoredItem article in articles.Articles)
                    {
                        AuthorSearch(author, item, article, resultList);
                    }
                }
            }
            return resultList;
        }
        private void AuthorSearch(string author,PolygraphicItem item, IAuthoredItem itemWithAuthor, List<PolygraphicItem> list)
        {
            foreach(string authorInList in itemWithAuthor.Authors)
            {
                if(authorInList.CompareTo(author)==0)
                {
                    list.Add(item);
                }
            }
        }
    }
}
