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
using static System.Windows.Forms.ListView;

namespace BooksWF
{
    public partial class BookEditForm : Form
    {
        public DataTable dt;
        private DataView _dv;
        public AuthoredItem editedAuthoredItem;
        private IGenerateList _list;
        public Button buttonDelete;
        public BookEditForm()
        {
            InitializeComponent();
        }

        public BookEditForm(string option,IGenerateList list)
            {
            InitializeComponent();

            editedAuthoredItem = new AuthoredItem();
            _list = list;
            List<AuthoredItem> bookList = _list.GetList().ConvertAll(instance => instance as AuthoredItem);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableAuthoredItem(bookList, out dt, out _dv);
            SetDataToDataGridView setData = new SetDataToDataGridView();
            setData.BindAuthoredItemDataTableWithDataGridView(dataGridViewBooks, dt);
            if (option == "Delete")
            {
                CreateButton createButton = new CreateButton();
                createButton.Create(ref buttonDelete, this, this.Width - 100, this.Height - 68, ButtonDelete_Click);
                dataGridViewBooks.RowStateChanged += dataGridViewBooks_RowStateChanged;
                for (int i = 0; i < dataGridViewBooks.ColumnCount - 1; i++)
                {
                    dataGridViewBooks.Columns[i].ReadOnly = true;
                }
            }
            if (option == "Edit")
            {
                dataGridViewBooks.CellBeginEdit += dataGridViewBooks_CellBeginEdit;
                dataGridViewBooks.CellEndEdit += dataGridViewBooks_CellEndEdit;
            }
        }
        public BookEditForm(List<AuthoredItem> articles, string option = " ")
        {
            InitializeComponent();
            editedAuthoredItem = new AuthoredItem();
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableAuthoredItem(articles, out dt, out _dv);
            SetDataToDataGridView setData = new SetDataToDataGridView();
            setData.BindAuthoredItemDataTableWithDataGridView(dataGridViewBooks, dt);
            if (option == "Delete")
            {
                CreateButton createButton = new CreateButton();
                createButton.Create(ref buttonDelete, this, this.Width - 100, this.Height - 68);
                for (int i = 0; i < dataGridViewBooks.ColumnCount - 1; i++)
                {
                    dataGridViewBooks.Columns[i].ReadOnly = true;
                }
            }
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Remove removeItem = new Remove();
            removeItem.RemovePolygraphicItemFromDataViewGrid(dataGridViewBooks, _list, editedAuthoredItem);
        }
        private void dataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditPolygraphicItem(dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), editedAuthoredItem);
        }
        private void dataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstanceFromDataGridView select = new SelectInstanceFromDataGridView();
            editedAuthoredItem = select.SelectPolygraphicInstance(dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList()) as AuthoredItem;
           
        }
        private void dataGridViewBooks_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromDataGridViewRow selectFromRow = new SelectFromDataGridViewRow(_list);
            selectFromRow.SelectBook(e, ref editedAuthoredItem);
        }
    }
}
