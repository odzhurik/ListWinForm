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

namespace BooksWF
{
    public partial class MagazineEditForm : Form
    {
        private DataTable _dtMagazines;
        private DataView _dvMagazines;
       private List<Magazine> _list;
        private Magazine _editedMagazine;
        public MagazineEditForm()
        {
            InitializeComponent();
            SetItem itemSetter = new SetItem();
            _editedMagazine = new Magazine();
            _list = MagazineList.GetMagazineList(itemSetter).GetList().ConvertAll(instance => instance as Magazine);
            _dtMagazines = new DataTable();
            _dtMagazines.Columns.Add("Title");
            _dtMagazines.Columns.Add("Issue");
            _dvMagazines = new DataView(_dtMagazines);          
            foreach (Magazine magazine in _list)
            {
                _dtMagazines.Rows.Add(magazine.Title, magazine.IssueNumber);
               
            }
            dataGridViewMagazines.DataSource = _dtMagazines;
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "Show articles";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;

            checkColumn.Selected = false;
            checkColumn.FillWeight = 10;
            dataGridViewMagazines.Columns.Add(checkColumn);
        }

        private void dataGridViewMagazines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMagazines.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
            {
                string value = dataGridViewMagazines.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                DataGridViewRow row = dataGridViewMagazines.Rows[e.RowIndex];

                Magazine magazine = _list.Find(paper => paper.Title == _editedMagazine.Title);
                magazine.Title = row.Cells[1].Value.ToString();
                magazine.IssueNumber = row.Cells[2].Value.ToString();
               
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
                BookEditForm form = new BookEditForm(listOfArticles);
                form.dataGridViewBooks.CellEndEdit -= form.dataGridViewBooks_CellEndEdit;
                form.dataGridViewBooks.CellEndEdit += DataGridViewArticles_CellEndEdit;
                form.ShowDialog();
                dataGridViewMagazines.CancelEdit();
            }
        }

        private void DataGridViewArticles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            BookEditForm form = gridView.FindForm() as BookEditForm;
            SetItem itemSetter = new SetItem();
            Magazine currentEditedMagazine = MagazineList.GetMagazineList(itemSetter).GetList().Find(magazine => magazine.Title == _editedMagazine.Title) as Magazine;
            currentEditedMagazine.Articles.Clear();
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
                currentEditedMagazine.Articles.Add(article);
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
    }
}
