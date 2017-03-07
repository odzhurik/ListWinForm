using BooksWF.ChooseInstance;
using BooksWF.Models;
using BooksWF.Models.EditInstances;
using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputInstance;
using BooksWF.Models.OutputList;
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
        private List<Newspaper> _newspaperList;
        private IGenerateList _list;
        private ISetItem _setterFromFile;
        private Newspaper _editedNewspaper;
        private BookEditForm _form;
        private Button _deleteButton;
        public NewspaperEditForm()
        {
            InitializeComponent();
        }
        public NewspaperEditForm(string option,IGenerateList list,ISetItem setterFromFile)
        {
            InitializeComponent();
            _editedNewspaper = new Newspaper();
            _setterFromFile = setterFromFile;
            _list = list;
            _newspaperList = _list.GetList().ConvertAll(instance => instance as Newspaper);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableNewspaper(_newspaperList, out _dtNewspapers, out _dvNewspapers);
            SetDataToDataGridView setData = new SetDataToDataGridView();
            setData.BindNewspaperDataTableWithDataGridView(dataGridViewNewspapers, _dtNewspapers);
            if (option == "Delete")
            {
                _deleteButton = new Button();
                _deleteButton.Name = "DeleteButton";
                _deleteButton.Text = "Delete";
                _deleteButton.Location = new Point(584, 342);
                _deleteButton.Click += _deleteButton_Click;
                this.Controls.Add(_deleteButton);
                dataGridViewNewspapers.CellContentClick += DataGridViewArticles_CellContentClick;

                for (int i = 0; i < dataGridViewNewspapers.ColumnCount - 1; i++)
                {
                    dataGridViewNewspapers.Columns[i].ReadOnly = true;
                }
            }
            if (option == "Edit")
            {
                dataGridViewNewspapers.CellContentClick += dataGridViewNewspapers_CellContentClick;
            }
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewNewspapers.SelectedRows)
            {
                dataGridViewNewspapers.Rows.RemoveAt(row.Index);
            }
            SetItem itemSetter = new SetItem();
            NewspaperList.GetNewspaperList(itemSetter).GetList().Remove(_editedNewspaper);
        }

        private void DataGridViewArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectInstance select = new SelectInstance();
            SetItem setter = new SetItem();
            List<AuthoredItem> listOfArticles = select.SelectArticles(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, NewspaperList.GetNewspaperList(setter).GetList());
             
                _form = new BookEditForm(listOfArticles, "Delete");
                _form.dataGridViewBooks.RowStateChanged += DataGridViewArticles_RowStateChanged;
                _form.buttonDelete.Click += ButtonDeleteArticle_Click;
                _form.ShowDialog();
                dataGridViewNewspapers.CancelEdit();
            
        }

        private void ButtonDeleteArticle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in _form.dataGridViewBooks.SelectedRows)
            {
                _form.dataGridViewBooks.Rows.RemoveAt(row.Index);
            }
            SetItem itemSetter = new SetItem();

            Newspaper currentNewspaper = NewspaperList.GetNewspaperList(itemSetter).GetList().FirstOrDefault(newspaperItem => newspaperItem.Title == _editedNewspaper.Title) as Newspaper;
            AuthoredItem article = currentNewspaper.Articles.FirstOrDefault(instance => instance.Title == _form.editedAuthoredItem.Title) as AuthoredItem;
            currentNewspaper.Articles.Remove(article);
        }

        private void DataGridViewArticles_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromRow select = new SelectFromRow(_list);
            _editedNewspaper = select.SelectItemWithArticle(e, ref _form.editedAuthoredItem) as Newspaper;
        }

        private void dataGridViewNewspapers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditPolygraphicItem(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedNewspaper);
        }

        private void dataGridViewNewspapers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectArticles selectArticles = new SelectArticles(_list);
            selectArticles.SelectArticlesToDataGridView(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, ref _form, DataGridViewBooks_CellBeginEdit, DataGridViewBooks_CellEndEdit);
        }

        private void DataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstance select = new SelectInstance();
            _editedNewspaper = select.SelectItemWithArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), ref _form.editedAuthoredItem) as Newspaper;

        }

        private void DataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedNewspaper, _form.editedAuthoredItem);
           
        }

        private void dataGridViewNewspapers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstance select = new SelectInstance();
           _editedNewspaper = select.SelectPolygraphicInstance(dataGridViewNewspapers, e.RowIndex, e.ColumnIndex, _list.GetList()) as Newspaper;

        }

        private void dataGridViewNewspapers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromRow select = new SelectFromRow(_list);
            select.SelectNewspaper(e, ref _editedNewspaper);
        }
    }
}
