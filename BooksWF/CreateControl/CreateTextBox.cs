using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.CreateControl
{
  public  class CreateTextBox
    {
        public void Create(out TextBox textBoxAuthor,string name, Panel panel, int locationX, int locationY)
        {
            textBoxAuthor = new TextBox();
            textBoxAuthor.Name = name;
            textBoxAuthor.Text = name;
            textBoxAuthor.Location = new Point(locationX,locationY);
            textBoxAuthor.Visible = true;
            panel.Controls.Add(textBoxAuthor);
        }
    }
}
