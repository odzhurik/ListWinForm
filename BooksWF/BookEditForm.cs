using BooksWF.Models;
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
        public BookEditForm()
        {
            InitializeComponent();
            
            SetItem itemSetter = new SetItem();
            List<AuthoredItem> list = BookList.GetBookList(itemSetter).GetList().ConvertAll(instance => instance as AuthoredItem);
            BindListwithDataTable(list);
        }
        public BookEditForm(List<AuthoredItem> articles)
        {
            InitializeComponent();
            BindListwithDataTable(articles);
        }
       private void BindListwithDataTable (List<AuthoredItem>list)
        {
            dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Authors");
            dt.Columns.Add("Pages");
            _dv = new DataView(dt);

            foreach (AuthoredItem book in list)
            {

                string authors = " ";
                foreach (string author in book.Authors)
                {
                    authors += author + ", ";
                }
                dt.Rows.Add(book.Title, authors, book.Pages);
            }
            dataGridViewBooks.DataSource = dt;
        }
        public void dataGridViewBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SetItem itemSetter = new SetItem();
           // string value = dataGridViewBooks[e.ColumnIndex, e.RowIndex].Value.ToString();
            BookList.GetBookList(itemSetter).GetList().Clear();
            foreach (DataRow row in dt.Rows)
            {
                AuthoredItem book = new AuthoredItem();
                int count = 0;
                book.Title = row.ItemArray[count++].ToString();
                string authorString = (string)row.ItemArray[count++];
                string[] authors = authorString.Split(',');

                for (int i = 0; i < authors.Length - 1; i++)
                {

                    book.Authors.Add(authors[i]);
                }
                book.Pages = Convert.ToInt32(row.ItemArray[count++]);
                BookList.GetBookList(itemSetter).GetList().Add(book);

            }

        }


    }
}
