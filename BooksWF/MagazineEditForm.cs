using BooksWF.Models;
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
    public partial class MagazineEditForm : Form
    {
        private DataTable _dtMagazines;
        private Button _buttonDelete;
        private DataView _dvMagazines;
        private List<Magazine> _list;
        private Magazine _editedMagazine;
        private BookEditForm _form;
        public MagazineEditForm()
        {
            InitializeComponent();

        }
        public MagazineEditForm(string option)
        {
            InitializeComponent();
            SetItem itemSetter = new SetItem();
            _editedMagazine = new Magazine();
            _list = MagazineList.GetMagazineList(itemSetter).GetList().ConvertAll(instance => instance as Magazine);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableMagazine(_list, out _dtMagazines, out _dvMagazines);
            SetDataToDataGridView setData = new SetDataToDataGridView();
            setData.BindMagazineDataTableWithDataGridView(dataGridViewMagazines, _dtMagazines);
            if (option == "Delete")
            {
                dataGridViewMagazines.CellContentClick += dataGridViewArticles_CellContentClick;
                _buttonDelete = new Button();
                _buttonDelete.Name = "Delete";
                _buttonDelete.Text = "Delete";
                _buttonDelete.Click += _buttonDelete_Click;
                _buttonDelete.Location = new Point(578, 338);
                this.Controls.Add(_buttonDelete);
                for (int i = 0; i < dataGridViewMagazines.ColumnCount - 1; i++)
                {
                    dataGridViewMagazines.Columns[i].ReadOnly = true;
                }
            }
            if(option=="Edit")
            {
                dataGridViewMagazines.CellContentClick += dataGridViewMagazines_CellContentClick;
            }
        }

        private void dataGridViewArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMagazines.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCell title = dataGridViewMagazines.Rows[e.RowIndex].Cells["Title"];
                List<AuthoredItem> listOfArticles = new List<AuthoredItem>();
                foreach (Magazine magazine in _list)
                {
                    if (magazine.Title.CompareTo(title.Value.ToString()) == 0)
                    {
                        _editedMagazine = magazine;
                        listOfArticles.AddRange(magazine.Articles);
                    }
                }
                _form = new BookEditForm(listOfArticles, "Delete");
                _form.dataGridViewBooks.RowStateChanged += DataGridViewArticles_RowStateChanged;
                _form.buttonDelete.Click += ButtonDeleteArticle_Click;
                _form.ShowDialog();
                dataGridViewMagazines.CancelEdit();
            }
        }

        private void ButtonDeleteArticle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in _form.dataGridViewBooks.SelectedRows)
            {
                _form.dataGridViewBooks.Rows.RemoveAt(row.Index);
            }
            SetItem itemSetter = new SetItem();

            Magazine currentMagazine = MagazineList.GetMagazineList(itemSetter).GetList().FirstOrDefault(magazineItem => magazineItem.Title == _editedMagazine.Title) as Magazine;
            AuthoredItem article = currentMagazine.Articles.FirstOrDefault(instance => instance.Title == _form.editedAuthoredItem.Title) as AuthoredItem;
            currentMagazine.Articles.Remove(article);
        }

        private void DataGridViewArticles_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            AuthoredItem article = new AuthoredItem();
            setter.Set(article, row);
            foreach (Magazine magazine in _list)
            {
                foreach (AuthoredItem articleItem in magazine.Articles)
                {
                    if (article.Title == articleItem.Title && article.Pages == articleItem.Pages)
                    {
                        _editedMagazine = magazine;
                        _form.editedAuthoredItem = article;
                    }
                }
            }
        }

        private void _buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewMagazines.SelectedRows)
            {
                dataGridViewMagazines.Rows.RemoveAt(row.Index);
            }
            SetItem itemSetter = new SetItem();
            MagazineList.GetMagazineList(itemSetter).GetList().Remove(_editedMagazine);
        }
        private void dataGridViewMagazines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMagazines.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridViewMagazines.Rows[e.RowIndex];
                Magazine magazine = _list.Find(paper => paper.Title == _editedMagazine.Title);
                SetFromTable setter = new SetFromTable();
                setter.Set(magazine, row);

            }
        }
        private void dataGridViewMagazines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMagazines.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCell title = dataGridViewMagazines.Rows[e.RowIndex].Cells["Title"];
                List<AuthoredItem> listOfArticles = new List<AuthoredItem>();
                foreach (Magazine magazine in _list)
                {
                    if (magazine.Title.CompareTo(title.Value.ToString()) == 0)
                    {
                        _editedMagazine = magazine;
                        listOfArticles.AddRange(magazine.Articles);
                    }
                }
                _form = new BookEditForm(listOfArticles);
                _form.dataGridViewBooks.CellBeginEdit += DataGridViewBooks_CellBeginEdit;
                _form.dataGridViewBooks.CellEndEdit += DataGridViewArticles_CellEndEdit;
                _form.ShowDialog();
                dataGridViewMagazines.CancelEdit();
            }
        }

        private void DataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_form.dataGridViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewCell title = _form.dataGridViewBooks.Rows[e.RowIndex].Cells["Title"];
                foreach (Magazine currentEditedMagazine in _list)
                {
                    foreach (AuthoredItem article in currentEditedMagazine.Articles)
                    {
                        if (article.Title.CompareTo(title.Value.ToString()) == 0)
                        {
                            _editedMagazine = currentEditedMagazine;
                            _form.editedAuthoredItem = article;
                        }
                    }
                }
            }
        }

        private void DataGridViewArticles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_form.dataGridViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                Magazine currentEditedMagazine = _list.Find(magazine => magazine.Title == _editedMagazine.Title) as Magazine;
                AuthoredItem currentEditedArticle = currentEditedMagazine.Articles.Find(article => article.Title == _form.editedAuthoredItem.Title) as AuthoredItem;
                DataGridViewRow row = _form.dataGridViewBooks.Rows[e.RowIndex];
                SetFromTable setter = new SetFromTable();
                setter.Set(currentEditedArticle, row);
            }
        }

        private void dataGridViewMagazines_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewMagazines.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewCell title = dataGridViewMagazines.Rows[e.RowIndex].Cells["Title"];
                Magazine currentEditedMagazine = _list.Find(magazine => magazine.Title == title.Value.ToString()) as Magazine;
                _editedMagazine = currentEditedMagazine;
            }
        }

        private void dataGridViewMagazines_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            Magazine magazine = new Magazine();
            setter.Set(magazine, row);
            _editedMagazine = _list.FirstOrDefault(magazineItem => magazineItem.Title == magazine.Title);
        }
    }
}
