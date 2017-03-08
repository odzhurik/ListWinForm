using BooksWF.ChooseInstance;
using BooksWF.CreateControl;
using BooksWF.Models;
using BooksWF.Models.EditInstances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputInstance;
using BooksWF.Models.OutputList;
using BooksWF.Models.RemoveItem;
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
        private IGenerateList _list;
        private Magazine _editedMagazine;
        private BookEditForm _form;
        public MagazineEditForm()
        {
            InitializeComponent();

        }
        public MagazineEditForm(string option, IGenerateList list)
        {
            InitializeComponent();
            _list = list;
            _editedMagazine = new Magazine();
            List<Magazine> magazineList = _list.GetList().ConvertAll(instance => instance as Magazine);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableMagazine(magazineList, out _dtMagazines, out _dvMagazines);
            SetDataToDataGridView setData = new SetDataToDataGridView();
            setData.BindMagazineDataTableWithDataGridView(dataGridViewMagazines, _dtMagazines);
            if (option == "Delete")
            {
                CreateButton createButton = new CreateButton();
                createButton.Create(ref _buttonDelete, this, this.Width - 150, this.Height - 80, _buttonDelete_Click);
                dataGridViewMagazines.CellContentClick += DeleteArticles_CellContentClick;
                for (int i = 0; i < dataGridViewMagazines.ColumnCount - 1; i++)
                {
                    dataGridViewMagazines.Columns[i].ReadOnly = true;
                }

            }
            if (option == "Edit")
            {
                dataGridViewMagazines.CellContentClick += EditArticles_CellContentClick;
            }
        }

        private void DeleteArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectArticles selectArticles = new SelectArticles(_list, new SelectInstanceFromDataGridView());
            selectArticles.SelectArticlesToDeleteInDataGridView(dataGridViewMagazines, e.RowIndex, e.ColumnIndex, ref _form, DataGridViewArticles_RowStateChanged, ButtonDeleteArticle_Click);
        }

        private void ButtonDeleteArticle_Click(object sender, EventArgs e)
        {
            Remove remove = new Remove();
            remove.RemoveArticleFromDataGridView(_form.dataGridViewBooks, _list, _editedMagazine, _form.editedAuthoredItem);
        }

        private void DataGridViewArticles_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromDataGridViewRow select = new SelectFromDataGridViewRow(_list);
            _editedMagazine = select.SelectItemWithArticle(e, ref _form.editedAuthoredItem) as Magazine;
        }

        private void _buttonDelete_Click(object sender, EventArgs e)
        {
            Remove removeItem = new Remove();
            removeItem.RemovePolygraphicItemFromDataViewGrid(dataGridViewMagazines, _list, _editedMagazine);
        }
        private void dataGridViewMagazines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditPolygraphicItem(dataGridViewMagazines, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedMagazine);
        }
        private void EditArticles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectArticles selectArticles = new SelectArticles(_list, new SelectInstanceFromDataGridView());
            selectArticles.SelectArticlesToEditInDataGridView(dataGridViewMagazines, e.RowIndex, e.ColumnIndex, ref _form, DataGridViewBooks_CellBeginEdit, DataGridViewArticles_CellEndEdit);
        }

        private void DataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstanceFromDataGridView select = new SelectInstanceFromDataGridView();
            _editedMagazine = select.SelectItemWithArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), ref _form.editedAuthoredItem) as Magazine;
        }

        private void DataGridViewArticles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditArticle(_form.dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), _editedMagazine, _form.editedAuthoredItem);
        }

        private void dataGridViewMagazines_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstanceFromDataGridView select = new SelectInstanceFromDataGridView();
            _editedMagazine = select.SelectPolygraphicInstance(dataGridViewMagazines, e.RowIndex, e.ColumnIndex, _list.GetList()) as Magazine;
        }

        private void dataGridViewMagazines_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromDataGridViewRow selectFromRow = new SelectFromDataGridViewRow(_list);
            selectFromRow.SelectMagazine(e, ref _editedMagazine);
        }
    }
}
