using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.CreateControl
{
    public class CreateButton
    {
        public void Create(ref Button button,Form form, int locationX,int locationY, EventHandler ButtonClick=null)
        {
            button = new Button();
            button.Name = "Delete";
            button.Text = "Delete";
            if (ButtonClick != null)
            {
                button.Click += ButtonClick;
            }
            button.Location = new Point(locationX, locationY);
            form.Controls.Add(button);
        }
    }
}
