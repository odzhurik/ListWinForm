using BooksWF.Models;
using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputInstance;
using BooksWF.Models.OutputList;
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
        private List<Newspaper> _list;
        private Newspaper _editedNewspaper;
        private BookEditForm _form;
        private Button _deleteButton;
        public NewspaperEditForm()
        {
            InitializeComponent();
        }
        public NewspaperEditForm(string option)
        {
            InitializeComponent();
            _editedNewspaper = new Newspaper();
            SetItem itemSetter = new SetItem();
            _list = NewspaperList.GetNewspaperList(itemSetter).GetList().ConvertAll(instance => instance as Newspaper);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableNewspaper(_list, out _dtNewspapers, out _dvNewspapers);
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
            if (dataGridViewNewspapers.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCell title = dataGridViewNewspapers.Rows[e.RowIndex].Cells["Title"];
                List<AuthoredItem> listOfArticles = new List<AuthoredItem>();
                foreach (Newspaper newspaper in _list)
                {
                    if (newspaper.Title.CompareTo(title.Value.ToString()) == 0)
                    {
                        _editedNewspaper = newspaper;
                        listOfArticles.AddRange(newspaper.Articles);
                    }
                }
                _form = new BookEditForm(listOfArticles,"Delete");
               _form.dataGridViewBooks.RowStateChanged += DataGridViewArticles_RowStateChanged;
                _form.buttonDelete.Click += ButtonDeleteArticle_Click;
                _form.ShowDialog();
                dataGridViewNewspapers.CancelEdit();
            }
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
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            AuthoredItem article = new AuthoredItem();
            setter.Set(article, row);
            foreach (Newspaper newspaper in _list)
            {
                foreach (AuthoredItem articleItem in newspaper.Articles)
                {
                    if (article.Title == articleItem.Title && article.Pages == articleItem.Pages)
                    {
                        _editedNewspaper = newspaper;
                        _form.editedAuthoredItem = article;
                    }
                }
            }
        }

        private void dataGridViewNewspapers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewNewspapers.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridViewNewspapers.Rows[e.RowIndex];
                Newspaper newspaper = _list.Find(paper => paper.Title == _editedNewspaper.Title);
                SetFromTable setter = new SetFromTable();
                setter.Set(newspaper, row);
            }

        }

        private void dataGridViewNewspapers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewNewspapers.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCell title = dataGridViewNewspapers.Rows[e.RowIndex].Cells["Title"];
                List<AuthoredItem> listOfArticles = new List<AuthoredItem>();
                foreach (Newspaper newspaper in _list)
                {
                    if (newspaper.Title.CompareTo(title.Value.ToString()) == 0)
                    {
                        _editedNewspaper = newspaper;
                        listOfArticles.AddRange(newspaper.Articles);
                    }
                }
                _form = new BookEditForm(listOfArticles);
                _form.dataGridViewBooks.CellBeginEdit += DataGridViewBooks_CellBeginEdit;
                _form.dataGridViewBooks.CellEndEdit += DataGridViewBooks_CellEndEdit;
                _form.ShowDialog();
                dataGridViewNewspapers.CancelEdit();

            }
        }

        private void DataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_form.dataGridViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewCell title = _form.dataGridViewBooks.Rows[e.RowIndex].Cells["Title"];
                foreach (Newspaper currentEditedNewspaper in _list)
                {
                    foreach (AuthoredItem article in currentEditedNewspaper.Articles)
                    {
                        if (article.Title.CompareTo(title.Value.ToString()) == 0)
                        {
                            _editedNewspaper = currentEditedNewspaper;
                            _form.editedAuthoredItem = article;
                        }
                    }
                }
            }

        }

        private void DataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_form.dataGridViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                Newspaper currentEditedNewspaper = _list.Find(newspaper => newspaper.Title == _editedNewspaper.Title) as Newspaper;
                AuthoredItem currentEditedArticle = currentEditedNewspaper.Articles.Find(article => article.Title == _form.editedAuthoredItem.Title) as AuthoredItem;
                DataGridViewRow row = _form.dataGridViewBooks.Rows[e.RowIndex];
                SetFromTable setter = new SetFromTable();
                setter.Set(currentEditedArticle, row);

            }
        }

        private void dataGridViewNewspapers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewNewspapers.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewCell title = dataGridViewNewspapers.Rows[e.RowIndex].Cells["Title"];
                Newspaper currentEditedNewspaper = _list.Find(newspaper => newspaper.Title == title.Value.ToString()) as Newspaper;
                _editedNewspaper = currentEditedNewspaper;

            }
        }

        private void dataGridViewNewspapers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            Newspaper newspaper = new Newspaper();
            setter.Set(newspaper, row);
            _editedNewspaper = _list.FirstOrDefault(newspaperItem => newspaperItem.Title == newspaper.Title);
        }
    }
}
