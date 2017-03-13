using BooksWF.Models.Instances;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.Models.RemoveItem
{
    public class RemoveFromDataGrirdView
    {
        public void RemovePolygraphicItemFromDataViewGrid(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(row.Index);
            }
          
        }
       
    }
}
