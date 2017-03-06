using BooksWF.Models;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
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
        private List<AuthoredItem> _list;
        public Button buttonDelete;
        public BookEditForm(string option)
        {
            if(option=="Delete")
            {
                InitializeComponent();
                buttonDelete = new Button();
                buttonDelete.Name = "ButtonDelete";
                buttonDelete.Text = "Delete";
                buttonDelete.Location=new Point(587,341);
                buttonDelete.Click += ButtonDelete_Click;
                this.Controls.Add(buttonDelete);
                editedAuthoredItem = new AuthoredItem();
                SetItem itemSetter = new SetItem();
                _list = BookList.GetBookList(itemSetter).GetList().ConvertAll(instance => instance as AuthoredItem);
                BindListwithDataTable(_list);
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

        public BookEditForm(string option, List<AuthoredItem>articles)
        {
            if(option=="Delete")
            {
                InitializeComponent();
                buttonDelete = new Button();
                buttonDelete.Name = "ButtonDelete";
                buttonDelete.Text = "Delete";
                buttonDelete.Location = new Point(587, 341);
                this.Controls.Add(buttonDelete);
                editedAuthoredItem = new AuthoredItem();
                BindListwithDataTable(articles);
                for (int i = 0; i < dataGridViewBooks.ColumnCount - 1; i++)
                {
                    dataGridViewBooks.Columns[i].ReadOnly = true;
                }
            }
                   
        }
        public BookEditForm()
        {
            InitializeComponent();
            editedAuthoredItem = new AuthoredItem();
            SetItem itemSetter = new SetItem();
            _list = BookList.GetBookList(itemSetter).GetList().ConvertAll(instance => instance as AuthoredItem);
            BindListwithDataTable(_list);
        }
        public BookEditForm(List<AuthoredItem> articles)
        {
            InitializeComponent();
            editedAuthoredItem = new AuthoredItem();
            BindListwithDataTable(articles);
        }
        private void BindListwithDataTable(List<AuthoredItem> list)
        {
            dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Authors");
            dt.Columns.Add("Pages");
            _dv = new DataView(dt);

            foreach (AuthoredItem book in list)
            {

                StringBuilder authors = new StringBuilder();
                foreach (string author in book.Authors)
                {
                    authors.Append(author + ",");
                }
                dt.Rows.Add(book.Title, authors, book.Pages);
            }
            dataGridViewBooks.DataSource = dt;
        }
        public void dataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridViewBooks.Rows[e.RowIndex];
                AuthoredItem book = _list.Find(paper => paper.Title == editedAuthoredItem.Title);
                SetFromTable setter = new SetFromTable();
                setter.Set(book, row);
            }
        }

        public void dataGridViewBooks_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewCell title = dataGridViewBooks.Rows[e.RowIndex].Cells["Title"];
                AuthoredItem currentEditedAuthoredItem = _list.Find(book => book.Title == title.Value.ToString()) as AuthoredItem;
                editedAuthoredItem = currentEditedAuthoredItem;

            }
        }

        public void dataGridViewBooks_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            AuthoredItem book = new AuthoredItem();
            setter.Set(book, row);
            editedAuthoredItem = _list.FirstOrDefault(bookItem => bookItem.Title == book.Title);
        }
    }
}
