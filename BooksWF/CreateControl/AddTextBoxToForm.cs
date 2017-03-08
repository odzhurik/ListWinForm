using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.CreateControl
{
   public class AddTextBoxToForm
    {
        public void Add(NumericUpDown numericUpDownAuthors,Panel panel,TextBox textBoxAuthor0, LinkLabel linkLabelAddAuthor)
        {
            int count = Convert.ToInt32(numericUpDownAuthors.Value);
            int space = 30;
            for (int i = 1; i <= count; i++)
            {
                TextBox textBoxAuthor;
                CreateTextBox createTextBox = new CreateTextBox();
                createTextBox.Create(out textBoxAuthor, "Author" + i.ToString(), panel, textBoxAuthor0.Location.X, textBoxAuthor0.Location.Y + space);
                space += 30;
            }
            panel.Controls.Remove(linkLabelAddAuthor);
            panel.Controls.Remove(numericUpDownAuthors);
        }
    }
}
