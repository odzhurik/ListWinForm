using BooksWF.Models;
using BooksWF.Models.OutputList;
using BooksWF.Models.OutputLists;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetBookList_Click(object sender, EventArgs e)
        {
            OutputBookList outputBookList = new OutputBookList();
            textBox.Text = outputBookList.Output();

        }

        private void btnGetMagazineList_Click(object sender, EventArgs e)
        {
            MagazineListOutput magazineList = new MagazineListOutput();
            textBox.Text = magazineList.Output();
        }

     
        private void BtnSaveMagazines_Click(object sender, EventArgs e)
        {
            MagazineListOutput magazineList = new MagazineListOutput();
            textBox.Text = magazineList.XmlOutput(); ;
        }

        private void btnNewspaperList_Click(object sender, EventArgs e)
        {
            OutputNewspaperList newspaperList = new OutputNewspaperList();
            textBox.Text = newspaperList.Output();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchOutput searchOutput = new SearchOutput();
            textBox.Text = searchOutput.SearchResultsOutput(textBoxSearch.Text);
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBookForm bookForm = new AddBookForm();
            bookForm.ShowDialog();
        }

        private void addNewspaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewspaperForm newapaperForm = new AddNewspaperForm();
            newapaperForm.ShowDialog();
        }

        private void addMagazineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMagazineForm magazineForm = new AddMagazineForm();
            magazineForm.ShowDialog();
        }

        private void bookEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookEditForm form = new BookEditForm("Edit");
            form.ShowDialog();
        }

        private void magazineEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagazineEditForm form = new MagazineEditForm("Edit");
            form.ShowDialog();
        }

        private void newspaperEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewspaperEditForm form = new NewspaperEditForm("Edit");
            form.ShowDialog();
        }

        private void magazineDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagazineEditForm form = new MagazineEditForm("Delete");
            form.ShowDialog();
        }

        private void bookDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookEditForm form = new BookEditForm("Delete");
            form.ShowDialog();
        }

        private void newspaperDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewspaperEditForm form = new NewspaperEditForm("Delete");
            form.ShowDialog();
        }
    }
}
