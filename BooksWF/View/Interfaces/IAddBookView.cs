using BooksWF.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.View
{
  public interface IAddBookView
    {
        IAddBookPresenter BookPresenter {set; }
        void ShowForm();
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
