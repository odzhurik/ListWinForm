﻿using BooksWF.Presenter;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.View
{
    public interface IAddMagazineView
    {
        IAddMagazinePresenter MagazinePresenter { set; }
        void ShowForm();
        void CloseForm();
        string Title { get; set; }
        string Issue { get; set; }
        List<AuthoredItem> Articles { get; set; }
        void CreateArticlesForm(EventHandler AddAuthors, EventHandler AddArticles);
        IAddBookView Form { get; set; }
    }
}