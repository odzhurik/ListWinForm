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
    public partial class MagazineEditForm : Form, IEditMagazineView
    {
        private DataTable _dtMagazines;
        private Button _buttonDelete;
        private DataView _dvMagazines;
        private IEditBookView _form;
        private EditMagazinePresenter _presenter;
        public event EventHandler<EventArgs> EndEdit;
        public event EventHandler<EventArgs> SelectItemToDelete;
        public event EventHandler<EventArgs> ShowArticlesToEdit;
        public event EventHandler<EventArgs> ShowArticlesToDelete;
        public IEditBookView ArticleForm
        {
            get
            {
                return _form;
            }
            set
            {
                _form = value;
            }
        }
        public MagazineEditForm()
        {
            InitializeComponent();
            _form = new BookEditForm();
            dataGridViewMagazines.CellContentClick += EditArticles_CellContentClick;
            _presenter = new EditMagazinePresenter(this);
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
        public void InitDataTable(List<Magazine> magazineList)
        {
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableMagazine(magazineList, out _dtMagazines, out _dvMagazines);
        }
        public void InitDataGridView()
        {
            SetDataTableToDataGridView setData = new SetDataTableToDataGridView();
            setData.BindMagazineDataTableWithDataGridView(dataGridViewMagazines, _dtMagazines);
        }
        public void EndEditItem(Magazine editedItem, EventArgs e)
        {
            DataGridViewCellEventArgs args = e as DataGridViewCellEventArgs;

            if (args != null)
            {
                EditInDataGridView edit = new EditInDataGridView();
                edit.EditMagazine(dataGridViewMagazines, args.RowIndex, args.ColumnIndex, editedItem);
            }
        }
        public void ShowArticleListToEdit(List<Book> list)
        {
            GetListOfArticlesToForm selectArticles = new GetListOfArticlesToForm();
            selectArticles.SelectArticlesToEditInDataGridView(dataGridViewMagazines, ref _form, list);
        }
        public void CreateDeleteView()
        {
            CreateButton createButton = new CreateButton();
            createButton.Create(ref _buttonDelete, this, this.Width - 150, this.Height - 80, _buttonDelete_Click);
            for (int i = 0; i < dataGridViewMagazines.ColumnCount - 1; i++)
            {
                dataGridViewMagazines.Columns[i].ReadOnly = true;
            }
        }
        public void SelectMagazineToDelete(Magazine item, EventArgs e)
        {
            DataGridViewRowStateChangedEventArgs args = e as DataGridViewRowStateChangedEventArgs;
            if (args != null)
            {
                SelectFromDataGridViewRow selectFromRow = new SelectFromDataGridViewRow();
                selectFromRow.SelectMagazine(args, item);
            }
        }
        public void ShowArticleListToDelete(List<Book> list)
        {
            GetListOfArticlesToForm selectArticles = new GetListOfArticlesToForm();
            selectArticles.SelectArticlesToDeleteInDataGridView(dataGridViewMagazines, ref _form, list);
        }
        public void RemoveFromDataGridView()
        {
            RemoveFromDataGrirdView removeItem = new RemoveFromDataGrirdView();
            removeItem.RemovePolygraphicItemFromDataViewGrid(dataGridViewMagazines);
        }
        private void _buttonDelete_Click(object sender, EventArgs e)
        {
            _presenter.RemoveMagazine();
        }
        private void dataGridViewMagazines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (EndEdit != null)
            {
                EndEdit(this, e);
            }
        }
        private void EditArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ShowArticlesToEdit != null)
            {
                ShowArticlesToEdit(this, e);
            }
            if (ShowArticlesToDelete != null)
            {
                ShowArticlesToDelete(this, e);
            }
        }
        private void dataGridViewMagazines_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (SelectItemToDelete != null)
            {
                SelectItemToDelete(this, e);
            }
        }
    }
}
