using BooksWF.ChooseInstance;
using BooksWF.Models;
using BooksWF.Models.EditInstances;
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
        private List<Magazine> _magazineList;
        private IGenerateList _list;
        private ISetItem _setterFromFile;
        private Magazine _editedMagazine;
        private BookEditForm _form;
        public MagazineEditForm()
        {
            InitializeComponent();

        }
        public MagazineEditForm(string option,IGenerateList list,ISetItem setterFRomFile)
        {
            InitializeComponent();
            _setterFromFile = setterFRomFile;
            _list = list;
            _editedMagazine = new Magazine();
            _magazineList = _list.GetList().ConvertAll(instance => instance as Magazine);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableMagazine(_magazineList, out _dtMagazines, out _dvMagazines);
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
                foreach (Magazine magazine in _magazineList)
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
            SelectFromRow select = new SelectFromRow(_list);
            _editedMagazine = select.SelectItemWithArticle(e, ref _form.editedAuthoredItem) as Magazine;
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
            Edit edit = new Edit();
            edit.EditPolygraphicItem(dataGridViewMagazines, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedMagazine);
        }
        private void dataGridViewMagazines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectArticles selectArticles = new SelectArticles(_list);
            selectArticles.SelectArticlesToDataGridView(dataGridViewMagazines, e.RowIndex, e.ColumnIndex, ref _form, DataGridViewBooks_CellBeginEdit, DataGridViewArticles_CellEndEdit);
               }

        private void DataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstance select = new SelectInstance();
          _editedMagazine = select.SelectItemWithArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), ref _form.editedAuthoredItem) as Magazine;
                   }

        private void DataGridViewArticles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedMagazine, _form.editedAuthoredItem);
        }

        private void dataGridViewMagazines_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstance select = new SelectInstance();
           _editedMagazine= select.SelectPolygraphicInstance(dataGridViewMagazines, e.RowIndex, e.ColumnIndex, _list.GetList()) as Magazine;
        }

        private void dataGridViewMagazines_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromRow selectFromRow = new SelectFromRow(_list);
            selectFromRow.SelectMagazine(e, ref _editedMagazine);
        }
    }
}
