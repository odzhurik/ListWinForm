using MVP.Entities;
using MVP.Models.ViewModel;
using MVP.Views;
using System;

namespace MVP.Presenters
{
    public class AddBooksPresenter
    {
        private BookListModel _model;
        private IAddBookView _view;
        public AddBooksPresenter(IAddBookView view)
        {
            _model = new BookListModel();
            _view = view;
        }
        public void InitEvents()
        {
            _view.AddAuthoredItem += new EventHandler<EventArgs>(_view_AddAuthoredItem);
            _view.AddAuthors += new EventHandler<EventArgs>(_view_AddAuthors);
        }
        private void _view_AddAuthors(object sender, EventArgs e)
        {
            _view.AddTextBoxAuthors();
        }
        private void _view_AddAuthoredItem(object sender, EventArgs e)
        {
            _view.GetAuthorsFromTextBox();
            AuthoredItem book = new AuthoredItem();
            book.Title = _view.Title;
            book.Authors = _view.Authors;
            book.Pages = Convert.ToInt32(_view.Pages);
            _model.AddToBookList(book);
            CloseView();
        }
        public void CloseView()
        {
            _view.CloseForm();
        }
    }
}
