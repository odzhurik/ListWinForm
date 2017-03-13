using BooksWF.Models;
using CardProject.Models;
using System.Collections.Generic;

namespace BooksWF.Model
{
    public interface IMagazineListModel
    {
        List<AuthoredItem> ArticlesList { get; }
        AuthoredItem EditedAuthoredItem { get; set; }
        Magazine EditedMagazine { get; set; }
        List<Magazine> LoadMagazineList();
        Magazine GetEditedMagazine();
        AuthoredItem GetEditedArticleInMagazineList();
        void RemoveFromMagazineList();
        void RemoveArticleFromMagazineList();
        void AddToMagazineList(PolygraphicItem magazine);
        void AddToArticlesList(AuthoredItem article);
    }

    }
