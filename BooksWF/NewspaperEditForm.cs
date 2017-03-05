using BooksWF.Models;
using BooksWF.Models.Instances;
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

namespace BooksWF
{
    public partial class NewspaperEditForm : Form
    {
        private DataTable _dtNewspapers;
        private DataView _dvNewspapers;
        private List<Newspaper> _list;
        private Newspaper _editedNewspaper;
        public NewspaperEditForm()
        {
            InitializeComponent();
            _editedNewspaper = new Newspaper();
            SetItem itemSetter = new SetItem();
            _list = NewspaperList.GetNewspaperList(itemSetter).GetList().ConvertAll(instance => instance as Newspaper);
            _dtNewspapers = new DataTable();
            _dtNewspapers.Columns.Add("Title");
            _dtNewspapers.Columns.Add("Issue");
            _dtNewspapers.Columns.Add("Periodical");
            _dvNewspapers = new DataView(_dtNewspapers);
            foreach (Newspaper newspaper in _list)
            {
                _dtNewspapers.Rows.Add(newspaper.Title, newspaper.IssueNumber, newspaper.Periodical);

            }
            dataGridViewNewspapers.DataSource = _dtNewspapers;

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "Show articles";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;

            checkColumn.Selected = false;
            checkColumn.FillWeight = 10;
            dataGridViewNewspapers.Columns.Add(checkColumn);
        }

        private void dataGridViewNewspapers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewNewspapers.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                string value = dataGridViewNewspapers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                DataGridViewRow row = dataGridViewNewspapers.Rows[e.RowIndex];

                Newspaper newspaper = _list.Find(paper => paper.Title == _editedNewspaper.Title);
                newspaper.Title = row.Cells[1].Value.ToString();
                newspaper.IssueNumber = row.Cells[2].Value.ToString();
                newspaper.Periodical = row.Cells[3].Value.ToString();
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
                BookEditForm form = new BookEditForm(listOfArticles);
                form.dataGridViewBooks.CellEndEdit -= form.dataGridViewBooks_CellEndEdit;
                form.dataGridViewBooks.CellEndEdit += DataGridViewArticles_CellEndEdit;
                form.ShowDialog();
                dataGridViewNewspapers.CancelEdit();

            }
        }

        private void DataGridViewArticles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            BookEditForm form = gridView.FindForm() as BookEditForm;
            SetItem itemSetter = new SetItem();
            Newspaper currentEditedNewspaper = _list.Find(newspaper => newspaper.Title == _editedNewspaper.Title) as Newspaper;
            currentEditedNewspaper.Articles.Clear();
            foreach (DataRow row in form.dt.Rows)
            {
                AuthoredItem article = new AuthoredItem();
                int count = 0;
                article.Title = row.ItemArray[count++].ToString();
                string authorString = (string)row.ItemArray[count++];
                string[] authors = authorString.Split(',');

                for (int i = 0; i < authors.Length - 1; i++)
                {

                    article.Authors.Add(authors[i]);
                }
                article.Pages = Convert.ToInt32(row.ItemArray[count++]);
                currentEditedNewspaper.Articles.Add(article);
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
    }
}
