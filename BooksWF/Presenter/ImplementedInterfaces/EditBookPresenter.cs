using BooksWF.Model;
using BooksWF.Presenter.Interfaces;
using BooksWF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter
{
    public class EditBookPresenter:IEditBookPresenter 
    {
        private IBookListModel _model;
        private IEditBookView _view;
        public EditBookPresenter(IBookListModel model, IEditBookView view)
        {
            _model = model;
            _view = view;
            _view.BookPresenter = this;
        }

        private void _view_SelectItemToDelete(object sender, EventArgs e)
        {
            _view.SelectBookToDelete(_model.EditedAuthoredItem, e);
        }
        private void _view_EndEdit(object sender, EventArgs e)
        {
            _view.EndEditItem(_model.GetEditedBook(), e);
        }
        private void _view_BeginEdit(object sender, EventArgs e)
        {
            _view.BeginEditItem(_model.EditedAuthoredItem, e);
        }
        public void LoadBooks()
        {
            _view.InitDataTable(_model.LoadBookList());
            _view.InitDataGridView();
        }
        public void ShowEditView()
        {
            _view.BeginEdit += _view_BeginEdit;
            _view.EndEdit += _view_EndEdit;
            LoadBooks();
            _view.ShowForm();
        }
        public void ShowDeleteView()
        {
            _view.SelectItemToDelete += _view_SelectItemToDelete;
            _view.DeleteItem += _view_DeleteItem;
             LoadBooks();
            _view.CreateDeleteView();
            _view.ShowForm();
        }

        private void _view_DeleteItem(object sender, EventArgs e)
        {
            _view.RemoveFromDataGridView();
            _model.RemoveFromBookList();
        }
    }
}
