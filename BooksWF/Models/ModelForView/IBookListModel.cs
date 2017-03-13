using BooksWF.Models;
using CardProject.Models;
using System.Collections.Generic;

namespace BooksWF.Model
{
    public interface IBookListModel
    {
        AuthoredItem EditedAuthoredItem { get; set; }
        List<AuthoredItem> LoadBookList();
        AuthoredItem GetEditedBook();
        void RemoveFromBookList();
        void AddToBookList(PolygraphicItem book);

    }
}
