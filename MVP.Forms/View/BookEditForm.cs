using MVP.Entities;
using MVP.Forms.CreateControl;
using MVP.Forms.EditInstances;
using MVP.Forms.GetItem;
using MVP.Forms.RemoveItem;
using MVP.Forms.SetDataGridView;
using MVP.Presenters;
using MVP.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MVP.Forms
{
    public partial class BookEditForm : Form, IEditBookView
    {
        public DataTable dt;
        private DataView _dv;
        public Button buttonDelete;
        private EditBookPresenter _presenter;
        public event EventHandler<EventArgs> BeginEdit;
        public event EventHandler<EventArgs> EndEdit;
        public event EventHandler<EventArgs> SelectItemToDelete;
        public event EventHandler<EventArgs> DeleteItem;
        public BookEditForm()
        {
            InitializeComponent();
            dataGridViewBooks.CellBeginEdit += dataGridViewBooks_CellBeginEdit;
            dataGridViewBooks.CellEndEdit += dataGridViewBooks_CellEndEdit;
            dataGridViewBooks.RowStateChanged += dataGridViewBooks_RowStateChanged;
            _presenter = new EditBookPresenter(this);
        }
        public void ShowEditForm()
        {
            _presenter.CreateEditView();
            this.ShowDialog();
        }
        public void ShowDeleteForm()
        {
            _presenter.CreateDeleteView();
            this.ShowDialog();
        }
        public void ShowForm()
        {
            this.ShowDialog();
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (DeleteItem != null)
            {
                DeleteItem(this, e);
            }
        }
        private void dataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (EndEdit != null)
            {
                EndEdit(this, e);
            }
        }
        private void dataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (BeginEdit != null)
            {
                BeginEdit(this, e);
            }
        }
        private void dataGridViewBooks_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (SelectItemToDelete != null)
            {
                SelectItemToDelete(this, e);
            }
        }
        public void BeginEditItem(AuthoredItem editedItem, EventArgs e)
        {
            DataGridViewCellCancelEventArgs args = e as DataGridViewCellCancelEventArgs;
            if (args != null)
            {
                GetInstanceFromDataGridView select = new GetInstanceFromDataGridView();
                select.GetPolygraphicInstance(dataGridViewBooks, args.RowIndex, args.ColumnIndex, editedItem);
            }
        }
        public void EndEditItem(AuthoredItem editedItem, EventArgs e)
        {
            DataGridViewCellEventArgs args = e as DataGridViewCellEventArgs;
            if (args != null)
            {
                EditInDataGridView edit = new EditInDataGridView();
                edit.EditPolygraphicItem(dataGridViewBooks, args.RowIndex, args.ColumnIndex, editedItem);
            }
        }
        public void InitDataTable(List<AuthoredItem> bookList)
        {
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableAuthoredItem(bookList, out dt, out _dv);
        }
        public void InitDataGridView()
        {
            SetDataTableToDataGridView setData = new SetDataTableToDataGridView();
            setData.BindAuthoredItemDataTableWithDataGridView(dataGridViewBooks, dt);
        }
        public void CreateDeleteView()
        {
            CreateButton createButton = new CreateButton();
            createButton.Create(ref buttonDelete, this, this.Width - 100, this.Height - 68, ButtonDelete_Click);
            for (int i = 0; i < dataGridViewBooks.ColumnCount - 1; i++)
            {
                dataGridViewBooks.Columns[i].ReadOnly = true;
            }
        }
        public void SelectBookToDelete(AuthoredItem item, EventArgs e)
        {
            DataGridViewRowStateChangedEventArgs args = e as DataGridViewRowStateChangedEventArgs;
            if (args != null)
            {
                SelectFromDataGridViewRow selectFromRow = new SelectFromDataGridViewRow();
                selectFromRow.SelectPolygraphicItem(args, item);
            }
        }
        public void RemoveFromDataGridView()
        {
            RemoveFromDataGrirdView remove = new RemoveFromDataGrirdView();
            remove.RemovePolygraphicItemFromDataViewGrid(dataGridViewBooks);
        }
    }
}
