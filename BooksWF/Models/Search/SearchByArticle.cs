using BooksWF.Models.Instances;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.Search
{
   public class SearchByArticle
    {
        public PolygraphicItem Search(AuthoredItem article, List<PolygraphicItem> list)
        {
            foreach (PolygraphicItem item in list)
            {
                if (item is IArticle)
                {
                    IArticle itemWithArticles = item as IArticle;
                    foreach (AuthoredItem articleItem in itemWithArticles.Articles)
                    {
                        if (article.Title == articleItem.Title)
                        {
                            return item;
                        }
                    }
                }

            }
            return null;
        }
    }
}
