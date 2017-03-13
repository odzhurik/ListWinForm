using BooksWF.ChooseInstance;
using BooksWF.CreateControl;
using BooksWF.Models;
using BooksWF.Models.EditInstances;
using BooksWF.Models.OutputInstance;
using BooksWF.Models.RemoveItem;
using BooksWF.Presenter.Interfaces;
using BooksWF.SetDataGridView;
using BooksWF.View;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BooksWF
{
    public partial class MagazineEditForm : Form, IEditMagazineView
    {
        private DataTable _dtMagazines;
        private Button _buttonDelete;
        private DataView _dvMagazines;
        private IEditBookView _form;
        private IEditMagazinePresenter _presenter;
        public MagazineEditForm()
        {
            InitializeComponent();
            _form = new BookEditForm();
            dataGridViewMagazines.CellContentClick += EditArticles_CellContentClick;
        }
       
        public event EventHandler<EventArgs> BeginEdit;
        public event EventHandler<EventArgs> EndEdit;
        public event EventHandler<EventArgs> SelectItemToDelete;
        public event EventHandler<EventArgs> ShowArticlesToEdit;
        public event EventHandler<EventArgs> ShowArticlesToDelete;
        public IEditMagazinePresenter MagazinePresenter
        {
            set
            {
                _presenter = value;
            }
        }
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
public void ShowForm()
        {
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
        public void BeginEditItem(Magazine editedItem, EventArgs e)
        {
            DataGridViewCellCancelEventArgs args = e as DataGridViewCellCancelEventArgs;
            if (args != null)
            {
                GetInstanceFromDataGridView select = new GetInstanceFromDataGridView();
                select.GetPolygraphicInstance(dataGridViewMagazines, args.RowIndex, args.ColumnIndex, editedItem);
            }
        }
        public void EndEditItem(Magazine editedItem, EventArgs e)
        {
            DataGridViewCellEventArgs args = e as DataGridViewCellEventArgs;

            if (args != null)
            {
                EditInDataGridView edit = new EditInDataGridView();
                edit.EditPolygraphicItem(dataGridViewMagazines, args.RowIndex, args.ColumnIndex, editedItem);
            }
        }
        public void ShowArticleListToEdit(List<AuthoredItem> list)
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
                selectFromRow.SelectPolygraphicItem(args, item);
            }
        }
        public void ShowArticleListToDelete(List<AuthoredItem> list)
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
           if(EndEdit!=null)
            {
                EndEdit(this, e);
            }
        }
        private void EditArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ShowArticlesToEdit!=null)
            {
                ShowArticlesToEdit(this, e);
            }
            if (ShowArticlesToDelete != null)
            {
                ShowArticlesToDelete(this, e);
            }
        }         
        private void dataGridViewMagazines_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           if(BeginEdit!=null)
            {
                BeginEdit(this, e);
            }
        }
        private void dataGridViewMagazines_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
           if(SelectItemToDelete!=null)
            {
                SelectItemToDelete(this, e);
            }
        }
    }
}
