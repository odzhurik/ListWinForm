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
   public class Remove
    {
        public void RemovePolygraphicItemFromDataViewGrid(DataGridView dataGridView,IGenerateList list,PolygraphicItem item )
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(row.Index);
            }
            list.GetList().Remove(item);
        }
        public void RemoveArticleFromDataGridView(DataGridView dataGridView, IGenerateList list,PolygraphicItem item,AuthoredItem articleToDelete)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.RemoveAt(row.Index);
            }
            PolygraphicItem currentItem = list.GetList().FirstOrDefault(magazineItem => magazineItem.Title == item.Title);
            IArticle itemWithArticles = currentItem as IArticle;
            if (itemWithArticles != null)
            {
                AuthoredItem article = itemWithArticles.Articles.FirstOrDefault(instance => instance.Title == articleToDelete.Title);
                itemWithArticles.Articles.Remove(article);
            }
        }
    }
}
