using BooksWF.Models.AddItem;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.Models.GetItem
{
   public class GetItemFromForm
    {
        public void GetAuthoredItem(Form form,Panel panel,TextBox textBoxTitle,TextBox textBoxPages, List<PolygraphicItem> list,List<AuthoredItem>articles)
            {
            SetPolygraphicItem addBook = new SetPolygraphicItem();
            List<string> authors = new List<string>();
            foreach (Control textBox in panel.Controls)
            {
                if (textBox is TextBox)
                {
                    authors.Add(textBox.Text);
                }
            }
            if (list != null)
            {
              list.Add (addBook.SetAuthoredItem(textBoxTitle.Text, authors, Convert.ToInt32(textBoxPages.Text)));
            }
            if(articles!=null)
            {
                articles.Add(addBook.SetAuthoredItem(textBoxTitle.Text, authors, Convert.ToInt32(textBoxPages.Text))as AuthoredItem);
            }
            MessageBox.Show("Successfully added!", "Adding");
            form.Close();
        }
        public void GetMagazine(Form form, TextBox textBoxTitle, TextBox textBoxIssue, List<AuthoredItem> articles, List<PolygraphicItem> list)
        {
            AddMagazine addMagazine = new AddMagazine();
            addMagazine.Add(textBoxTitle.Text, textBoxIssue.Text, articles, list);
            MessageBox.Show("Successfully added!", "Adding");
            form.Close();
        }
    }
}
