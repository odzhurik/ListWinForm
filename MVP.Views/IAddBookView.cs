using System;
using System.Collections.Generic;

namespace MVP.Views
{
    public interface IAddBookView
    {
        void ShowBookForm();
        void ShowArticleForm();
        void CloseForm();
        string Title { get; set; }
        List<string> Authors { get; set; }
        string Pages { get; set; }
        void AddTextBoxAuthors();
        void GetAuthorsFromTextBox();
        event EventHandler<EventArgs> AddAuthoredItem;
        event EventHandler<EventArgs> AddAuthors;
    }
}
