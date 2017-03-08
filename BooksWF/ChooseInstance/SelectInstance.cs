using BooksWF.Models;
using BooksWF.Models.Instances;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.ChooseInstance
{
   public class SelectInstanceFromDataGridView
    {
        public List<AuthoredItem> SelectArticles(DataGridView dataGridView, int rowIndex,int columnIndex, List<PolygraphicItem> list)
        {
            List<AuthoredItem> listOfArticles = new List<AuthoredItem>();
            if(dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewCheckBoxCell)
            {
                DataGridViewCell title = dataGridView.Rows[rowIndex].Cells["Title"];
            
                foreach(PolygraphicItem item in list)
                {
                    if(item.Title.CompareTo(title.Value.ToString())==0)
                    {
                        if (item is IArticle)
                        {
                            IArticle itemWithArticles = item as IArticle;
                            listOfArticles.AddRange(itemWithArticles.Articles);
                        }
                       
                       
                    }
                }
            }
           return listOfArticles;
        }
        public PolygraphicItem SelectItemWithArticle(DataGridView dataGridView, int rowIndex, int columnIndex, List<PolygraphicItem> list,  ref AuthoredItem editedArticle)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
               DataGridViewCell title = dataGridView.Rows[rowIndex].Cells["Title"];
                foreach (PolygraphicItem currentEditedItem in list)
                {
                    if (currentEditedItem is IArticle)
                    {
                        IArticle itemWithArticle = currentEditedItem as IArticle;
                        foreach (AuthoredItem article in itemWithArticle.Articles)
                        {
                            if (article.Title.CompareTo(title.Value.ToString()) == 0)
                            {
                                editedArticle = article;
                                return currentEditedItem;
                                
                            }
                        }
                    }
                        }
            }
            return null;
            
        }
        
        public PolygraphicItem SelectPolygraphicInstance(DataGridView dataGridView, int rowIndex, int columnIndex, List<PolygraphicItem> list)
        {
            if (dataGridView.Rows[rowIndex].Cells[columnIndex] is DataGridViewTextBoxCell)
            {
                DataGridViewCell title = dataGridView.Rows[rowIndex].Cells["Title"];
                if (list.All(instance=> (instance is IPeriodicalItem) && (instance is IIssueItem)))
                {
                    Newspaper currentEditedNewspaper = list.Find(newspaper => newspaper.Title == title.Value.ToString()) as Newspaper;
                    return currentEditedNewspaper;
                }
                if (list.All(instance => (instance is IIssueItem) && !(instance is IPeriodicalItem)))
                {
                    Magazine currentEditedMagazine = list.Find(magazine => magazine.Title == title.Value.ToString()) as Magazine;
                     return currentEditedMagazine;
                }
                if (list.All(instance => (instance is IAuthoredItem) && (instance is IPage)))
                {
                    AuthoredItem currentEditedBook = list.Find(book => book.Title == title.Value.ToString()) as AuthoredItem;
                    return currentEditedBook;
                }

            }
            return null;
        }
    }
}
