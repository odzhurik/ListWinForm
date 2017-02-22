using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    public class ArticleList:GenerateAuthoredItemList
    {
        private static ArticleList _articleList;
        protected ArticleList()
        {

        }
        public static ArticleList GetArticleList()
        {
            if (_articleList == null)
                _articleList = new ArticleList();
            return _articleList;
        }
        public override List<PolygraphicItem> GenerateList()
        {
            return ReadFromFile("Articles.txt");
        }
    }
}
