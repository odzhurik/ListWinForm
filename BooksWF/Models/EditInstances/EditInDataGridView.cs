using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.Models.EditInstances
{
   public class EditInDataGridView
    {
        public void EditPolygraphicItem(DataGridView dataGridView, int rowIndex, int columnIndex, List<PolygraphicItem> list, PolygraphicItem editedItem)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                PolygraphicItem item = list.Find(paper => paper.Title == editedItem.Title);
                GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
                setter.GetItem(item, row);
            }
        }
        public void EditArticle(DataGridView dataGridView, int rowIndex, int columnIndex,List<PolygraphicItem> list,PolygraphicItem editedItem, AuthoredItem editedArticle)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
                PolygraphicItem currentEditedItem = list.Find(newspaper => newspaper.Title == editedItem.Title);
                AuthoredItem currentEditedArticle = new AuthoredItem();
                IArticle itemWithArticle = currentEditedItem as IArticle;
                if (itemWithArticle != null)
                {
                    currentEditedArticle = itemWithArticle.Articles.Find(article => article.Title == editedArticle.Title) as AuthoredItem;
                }
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
                setter.GetItem(currentEditedArticle, row);

            }
        }
    }
}
