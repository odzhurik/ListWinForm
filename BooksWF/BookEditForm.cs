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
using static System.Windows.Forms.ListView;

namespace BooksWF
{
    public partial class BookEditForm : Form
    {
        public DataTable dt;
        private DataView _dv;
        public AuthoredItem editedAuthoredItem;
        private List<AuthoredItem> _bookList;
        private ISetItem _itemSetterFromFile;
        private IGenerateList _list;
        public Button buttonDelete;
        public BookEditForm()
        {
            InitializeComponent();
        }

        public BookEditForm(string option,IGenerateList list,ISetItem itemSetterFromFile)
        {
            InitializeComponent();

            editedAuthoredItem = new AuthoredItem();
            _itemSetterFromFile = itemSetterFromFile;
            _list = list;
            _bookList = _list.GetList().ConvertAll(instance => instance as AuthoredItem);
            OutputToDataTable outputToDataTable = new OutputToDataTable();
            outputToDataTable.OutputToTableAuthoredItem(_bookList, out dt, out _dv);
            SetDataToDataGridView setData = new SetDataToDataGridView();
            setData.BindAuthoredItemDataTableWithDataGridView(dataGridViewBooks, dt);
            if (option == "Delete")
            {
                buttonDelete = new Button();
                buttonDelete.Name = "ButtonDelete";
                buttonDelete.Text = "Delete";
                buttonDelete.Location = new Point(587, 341);
                buttonDelete.Click += ButtonDelete_Click;
                this.Controls.Add(buttonDelete);
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
                buttonDelete = new Button();
                buttonDelete.Name = "ButtonDelete";
                buttonDelete.Text = "Delete";
                buttonDelete.Location = new Point(587, 341);
                this.Controls.Add(buttonDelete);
                for (int i = 0; i < dataGridViewBooks.ColumnCount - 1; i++)
                {
                    dataGridViewBooks.Columns[i].ReadOnly = true;
                }
            }
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewBooks.SelectedRows)
            {
                dataGridViewBooks.Rows.RemoveAt(row.Index);
            }
            SetItem itemSetter = new SetItem();
            BookList.GetBookList(itemSetter).GetList().Remove(editedAuthoredItem);
        }
        private void dataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditPolygraphicItem(dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList(), editedAuthoredItem);
        }
        private void dataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SelectInstance select = new SelectInstance();
            editedAuthoredItem = select.SelectPolygraphicInstance(dataGridViewBooks, e.RowIndex, e.ColumnIndex, _list.GetList()) as AuthoredItem;
           
        }
        private void dataGridViewBooks_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SelectFromRow selectFromRow = new SelectFromRow(_list);
            selectFromRow.SelectBook(e, ref editedAuthoredItem);
        }
    }
}
