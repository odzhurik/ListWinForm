using MVP.Entities;
using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IAddMagazineView
    {
        void ShowForm();
        void CloseForm();
        string Title { get; set; }
        string Issue { get; set; }
        List<AuthoredItem> Articles { get; set; }
        void CreateArticlesForm(EventHandler AddAuthors, EventHandler AddArticles);
        IAddBookView Form { get; set; }
    }
}
