using BooksWF.Models.AddItem;
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
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void linkLabelAddAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int count = Convert.ToInt32(numericUpDownAuthors.Value);
            int space = 30;
            for (int i = 1; i <= count; i++)
            {

                TextBox textBoxAuthor = new TextBox();
                textBoxAuthor.Name = "textBoxAuthor" + i.ToString();
                textBoxAuthor.Text = "Author " + i;
                textBoxAuthor.Location = new Point(textBoxAuthor0.Location.X, textBoxAuthor0.Location.Y + space);
                textBoxAuthor.Visible = true;
                panelAuthors.Controls.Add(textBoxAuthor);
                space += 30;
            }
            panelAuthors.Controls.Remove(linkLabelAddAuthor);
            panelAuthors.Controls.Remove(numericUpDownAuthors);
        }

        public void buttonAddBook_Click(object sender, EventArgs e)
        {
            AddAuthoredItem addBook = new AddAuthoredItem();
            List<string> authors = new List<string>();
            foreach(Control textBox in panelAuthors.Controls)
            {
                if(textBox is TextBox)
                {
                    authors.Add(textBox.Text);
                }
            }
            addBook.Add(textBoxTitle.Text,authors,Convert.ToInt32(textBoxPages.Text));
            MessageBox.Show("Successfully added!","Adding");
            this.Close();
        }
    }
}
