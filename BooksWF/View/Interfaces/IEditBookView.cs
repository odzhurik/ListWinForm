using BooksWF.Presenter;
using BooksWF.Presenter.Interfaces;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.View
{
    public interface IEditBookView
    {
        IEditBookPresenter BookPresenter { set; }
        void ShowForm();
        event EventHandler<EventArgs> BeginEdit;
        event EventHandler<EventArgs> EndEdit;
        event EventHandler<EventArgs> SelectItemToDelete;
        event EventHandler<EventArgs> DeleteItem;
        void BeginEditItem(AuthoredItem editedItem, EventArgs e);
        void InitDataTable(List<AuthoredItem> bookList);
        void InitDataGridView();
        void EndEditItem(AuthoredItem editedItem, EventArgs e);
        void SelectBookToDelete(AuthoredItem item, EventArgs e);
        void CreateDeleteView();
        void RemoveFromDataGridView();
    }
}
