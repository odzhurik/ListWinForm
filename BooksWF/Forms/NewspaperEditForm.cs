using BooksWF.ChooseInstance;
using BooksWF.CreateControl;
using BooksWF.Models;
using BooksWF.Models.EditInstances;
using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputInstance;
using BooksWF.Models.OutputList;
using BooksWF.Models.RemoveItem;
using BooksWF.Models.Search;
using BooksWF.SetDataGridView;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF
{
    public partial class NewspaperEditForm : Form
    {
        private DataTable _dtNewspapers;
        private DataView _dvNewspapers;
        private IGenerateList _list;
        private Newspaper _editedNewspaper;
        private BookEditForm _form;
        private Button _deleteButton;
        public NewspaperEditForm()
        {
            InitializeComponent();
        }
        public NewspaperEditForm(string option, IGenerateList list)
        {
            InitializeComponent();
            _editedNewspaper = new Newspaper();
            _list = list;
            List<Newspaper> newspaperList = _list.GetList().ConvertAll(instance => instance as Newspaper);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableNewspaper(newspaperList, out _dtNewspapers, out _dvNewspapers);
            SetDataTableToDataGridView setData = new SetDataTableToDataGridView();
            setData.BindNewspaperDataTableWithDataGridView(dataGridViewNewspapers, _dtNewspapers);
            if (option == "Delete")
            {
                CreateButton createButton = new CreateButton();
                createButton.Create(ref _deleteButton, this, this.Width - 100, this.Height-70, _deleteButton_Click);
                dataGridViewNewspapers.CellContentClick += DeleteArticles_CellContentClick;
                for (int i = 0; i < dataGridViewNewspapers.ColumnCount - 1; i++)
                {
                    dataGridViewNewspapers.Columns[i].ReadOnly = true;
                }
            }
            if (option == "Edit")
            {
                dataGridViewNewspapers.CellContentClick += EditArticles_CellContentClick;
            }
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            Remove removeItem = new Remove();
            removeItem.RemovePolygraphicItemFromDataViewGrid(dataGridViewNewspapers, _list, _editedNewspaper);
        }

        private void DeleteArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetListOfArticlesToForm selectArticles = new GetListOfArticlesToForm(_list, new GetInstanceFromDataGridView());
            selectArticles.SelectArticlesToDeleteInDataGridView(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, ref _form, DataGridViewArticles_RowStateChanged, ButtonDeleteArticle_Click);
        }

        private void ButtonDeleteArticle_Click(object sender, EventArgs e)
        {
            Remove remove = new Remove();
            remove.RemoveArticleFromDataGridView(_form.dataGridViewBooks, _list, _editedNewspaper, _form.editedAuthoredItem);
        }

        private void DataGridViewArticles_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromDataGridViewRow select = new SelectFromDataGridViewRow(_list);
            _editedNewspaper = select.SelectItemWithArticle(e, ref _form.editedAuthoredItem) as Newspaper;
        }

        private void dataGridViewNewspapers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EditInDataGridView edit = new EditInDataGridView();
            edit.EditPolygraphicItem(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedNewspaper);
        }

        private void EditArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetListOfArticlesToForm selectArticles = new GetListOfArticlesToForm(_list, new GetInstanceFromDataGridView());
            selectArticles.SelectArticlesToEditInDataGridView(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, ref _form, DataGridViewBooks_CellBeginEdit, DataGridViewBooks_CellEndEdit);
        }

        private void DataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            GetInstanceFromDataGridView select = new GetInstanceFromDataGridView();
            _editedNewspaper = select.GetItemWithArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), ref _form.editedAuthoredItem) as Newspaper;
        }

        private void DataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EditInDataGridView edit = new EditInDataGridView();
            edit.EditArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedNewspaper, _form.editedAuthoredItem);
        }

        private void dataGridViewNewspapers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            GetInstanceFromDataGridView select = new GetInstanceFromDataGridView();
            _editedNewspaper = select.GetPolygraphicInstance(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, _list.GetList()) as Newspaper;
        }

        private void dataGridViewNewspapers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromDataGridViewRow select = new SelectFromDataGridViewRow(_list);
            select.SelectNewspaper(e, ref _editedNewspaper);
        }
    }
}
