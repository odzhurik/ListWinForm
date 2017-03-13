using BooksWF.Models;
using BooksWF.Models.Instances;
using CardProject.Models;
using System.Collections.Generic;

namespace BooksWF.Model
{
    public interface INewspaperListModel
    {
        List<AuthoredItem> ArticlesList { get; }
        AuthoredItem EditedAuthoredItem { get; set; }
        Newspaper EditedNewspaper { get; set; }
        List<Newspaper> LoadNewspaperList();
        Newspaper GetEditedNewspaper();
        AuthoredItem GetEditedArticleInNewspaperList();
        void RemoveFromNewspaperList();
        void RemoveArticleFromNewspaperList();
        void AddToNewspaperList(PolygraphicItem newspaper);
        void AddToArticlesList(AuthoredItem article);
    }
}
