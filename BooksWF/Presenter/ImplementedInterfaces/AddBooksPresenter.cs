using BooksWF.Model;
using BooksWF.Models.AddItem;
using BooksWF.View;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
  public class AddBooksPresenter:IAddBookPresenter
    {
        private IBookListModel _model;
        private IAddBookView _view;
        public AddBooksPresenter(IBookListModel model,IAddBookView view)
        {
            _model = model;
            _view = view;
            _view.BookPresenter = this;
            _view.AddAuthoredItem += _view_AddAuthoredItem;
            _view.AddAuthors += _view_AddAuthors;
        }
        private void _view_AddAuthors(object sender, EventArgs e)
        {
            _view.AddTextBoxAuthors();
        }
        private void _view_AddAuthoredItem(object sender, EventArgs e)
        {
            SetPolygraphicItem addBook = new SetPolygraphicItem();
            _view.GetAuthorsFromTextBox();
            AuthoredItem item = addBook.SetAuthoredItem(_view.Title, _view.Authors, Convert.ToInt32(_view.Pages));
            _model.AddToBookList(item);
            CloseView();
        }
        public void ShowView()
        {
            _view.ShowForm();
        }
        public void CloseView()
        {
            _view.CloseForm();
        }
    }
}
