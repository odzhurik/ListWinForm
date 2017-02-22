using BooksWF.Models;
using BooksWF.Models.OutputList;
using BooksWF.Models.SaveInstance;
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

        private void btnNewspaperList_Click(object sender, EventArgs e)
        {
            OutputNewspaperList newspaperList = new OutputNewspaperList();
            textBox.Text = newspaperList.Output();
        }

        private void BtnArticleList_Click(object sender, EventArgs e)
        {
            OutputArticleList articleList = new OutputArticleList();
            textBox.Text = articleList.Output();
        }

        private void BtnSaveMagazines_Click(object sender, EventArgs e)
        {
            MagazineListOutput magazineList = new MagazineListOutput();
             magazineList.SaveInXml();
            textBox.Text = "Успешно сохранено";
        }
    }
}
