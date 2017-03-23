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
    public partial class NewspaperEditForm : Form, IEditNewspaperView
    {
        private DataTable _dtNewspapers;
        private DataView _dvNewspapers;
        private IEditBookView _form;
        private Button _deleteButton;
        private EditNewspaperPresenter _presenter;
        public event EventHandler<EventArgs> BeginEdit;
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
        public NewspaperEditForm()
        {
            InitializeComponent();
            dataGridViewNewspapers.CellContentClick += EditArticles_CellContentClick;
            dataGridViewNewspapers.RowStateChanged += dataGridViewNewspapers_RowStateChanged;
            _form = new BookEditForm();
            _presenter = new EditNewspaperPresenter(this);
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
        public void InitDataTable(List<Newspaper> newspaperList)
        {
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableNewspaper(newspaperList, out _dtNewspapers, out _dvNewspapers);
        }
        public void InitDataGridView()
        {
            SetDataTableToDataGridView setData = new SetDataTableToDataGridView();
            setData.BindNewspaperDataTableWithDataGridView(dataGridViewNewspapers, _dtNewspapers);
        }
        public void BeginEditItem(Newspaper editedItem, EventArgs e)
        {
            DataGridViewCellCancelEventArgs args = e as DataGridViewCellCancelEventArgs;
            if (args != null)
            {
                GetInstanceFromDataGridView select = new GetInstanceFromDataGridView();
                select.GetPolygraphicInstance(dataGridViewNewspapers, args.RowIndex, args.ColumnIndex, editedItem);
            }
        }
        public void EndEditItem(Newspaper editedItem, EventArgs e)
        {
            DataGridViewCellEventArgs args = e as DataGridViewCellEventArgs;

            if (args != null)
            {
                EditInDataGridView edit = new EditInDataGridView();
                edit.EditPolygraphicItem(dataGridViewNewspapers, args.RowIndex, args.ColumnIndex, editedItem);
            }
        }
        public void ShowArticleListToDelete(List<AuthoredItem> list)
        {
            GetListOfArticlesToForm selectArticles = new GetListOfArticlesToForm();
            selectArticles.SelectArticlesToDeleteInDataGridView(dataGridViewNewspapers, ref _form, list);
        }
        public void ShowArticleListToEdit(List<AuthoredItem> list)
        {
            GetListOfArticlesToForm selectArticles = new GetListOfArticlesToForm();
            selectArticles.SelectArticlesToEditInDataGridView(dataGridViewNewspapers, ref _form, list);
        }
        public void CreateDeleteView()
        {
            CreateButton createButton = new CreateButton();
            createButton.Create(ref _deleteButton, this, this.Width - 100, this.Height - 70, _deleteButton_Click);
            for (int i = 0; i < dataGridViewNewspapers.ColumnCount - 1; i++)
            {
                dataGridViewNewspapers.Columns[i].ReadOnly = true;
            }
        }
        public void SelectNewspaperToDelete(Newspaper item, EventArgs e)
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
            RemoveFromDataGrirdView removeItem = new RemoveFromDataGrirdView();
            removeItem.RemovePolygraphicItemFromDataViewGrid(dataGridViewNewspapers);
        }
        private void _deleteButton_Click(object sender, EventArgs e)
        {
            _presenter.RemoveNewspaper();
        }
        private void dataGridViewNewspapers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
        private void dataGridViewNewspapers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (BeginEdit != null)
            {
                BeginEdit(this, e);
            }
        }
        private void dataGridViewNewspapers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (SelectItemToDelete != null)
            {
                SelectItemToDelete(this, e);
            }
        }
    }
}
