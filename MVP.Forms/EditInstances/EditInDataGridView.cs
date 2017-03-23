using MVP.Entities;
using MVP.Forms.GetItem;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MVP.Forms.EditInstances
{
    public class EditInDataGridView
    {
        public void EditPolygraphicItem(DataGridView dataGridView, int rowIndex, int columnIndex, PolygraphicItem editedItem)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell || dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                GetFromDataGridViewRow setter = new GetFromDataGridViewRow();
                setter.GetItem(editedItem, row);
            }
        }
        public void EditArticle(DataGridView dataGridView, int rowIndex, int columnIndex, List<PolygraphicItem> list, PolygraphicItem editedItem, AuthoredItem editedArticle)
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
