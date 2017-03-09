﻿using BooksWF.Models;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputInstance;
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
    public partial class MainForm : Form
    {
        private ISetItem _setterFromFile;
        public MainForm()
        {
            InitializeComponent();
            _setterFromFile = new SetItem();
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
            AddBookForm bookForm = new AddBookForm(BookList.GetBookList(_setterFromFile));
            bookForm.ShowDialog();
        }

        private void addNewspaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewspaperForm newapaperForm = new AddNewspaperForm(NewspaperList.GetNewspaperList(_setterFromFile));
            newapaperForm.ShowDialog();
        }

        private void addMagazineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMagazineForm magazineForm = new AddMagazineForm(MagazineList.GetMagazineList(_setterFromFile));
            magazineForm.ShowDialog();
        }

        private void bookEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookEditForm form = new BookEditForm("Edit",BookList.GetBookList(_setterFromFile));
            form.ShowDialog();
        }

        private void magazineEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagazineEditForm form = new MagazineEditForm("Edit",MagazineList.GetMagazineList(_setterFromFile));
            form.ShowDialog();
        }

        private void newspaperEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewspaperEditForm form = new NewspaperEditForm("Edit",NewspaperList.GetNewspaperList(_setterFromFile));
            form.ShowDialog();
        }

        private void magazineDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagazineEditForm form = new MagazineEditForm("Delete",MagazineList.GetMagazineList(_setterFromFile));
            form.ShowDialog();
        }

        private void bookDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookEditForm form = new BookEditForm("Delete", BookList.GetBookList(_setterFromFile));
            form.ShowDialog();
        }

        private void newspaperDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewspaperEditForm form = new NewspaperEditForm("Delete",NewspaperList.GetNewspaperList(_setterFromFile));
            form.ShowDialog();
        }

        private void buttonSaveBooksInDB_Click(object sender, EventArgs e)
        {
            DBSave save = new DBSave(BookList.GetBookList(_setterFromFile));
            textBox.Text = save.SaveInDB();
        }

        private void buttonSaveNewspaperInTxtFile_Click(object sender, EventArgs e)
        {
            TextFileSave textFileSave = new TextFileSave(NewspaperList.GetNewspaperList(_setterFromFile),new StringOutputItem());
            textBox.Text = textFileSave.SaveInTextFile();
        }
    }
}