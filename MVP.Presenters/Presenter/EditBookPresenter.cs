using MVP.Models.ViewModel;
using MVP.Views;
using System;

namespace MVP.Presenters
{
    public class EditBookPresenter
    {
        private BookListModel _model;
        private IEditBookView _view;
        public EditBookPresenter(IEditBookView view)
        {
            _model = new BookListModel();
            _view = view;
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
        public void CreateEditView()
        {
            _view.BeginEdit += _view_BeginEdit;
            _view.EndEdit += _view_EndEdit;
            LoadBooks();
        }
        public void CreateDeleteView()
        {
            _view.SelectItemToDelete += _view_SelectItemToDelete;
            _view.DeleteItem += _view_DeleteItem;
            LoadBooks();
            _view.CreateDeleteView();
        }
        private void _view_DeleteItem(object sender, EventArgs e)
        {
            _view.RemoveFromDataGridView();
            _model.RemoveFromBookList();
        }
    }
}
