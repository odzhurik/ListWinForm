using BooksWF.Models.Instances;
using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.ItemsList
{
  public  class SetFromTable
    {
        public void Set(PolygraphicItem item,IGenerateList listOfItems, DataTable dtItems,DataTable dtArticles=null)
        {
            foreach(DataRow row in dtItems.Rows)
            {
                int count = 0;
                if (item is PolygraphicItem)
                {
                    item.Title = (string)row.ItemArray[count++];
                }
                if(item is IAuthoredItem)
                {
                    IAuthoredItem authoredItem = item as IAuthoredItem;
                    string authorString = (string)row.ItemArray[count++];
                    string[] authors = authorString.Split(',');

                    for (int i = 0; i < authors.Length - 1; i++)
                    {
                        authoredItem.Authors.Add(authors[i]);
                    }
                }
                if(item is IPage)
                {
                    IPage itemWithPages = item as IPage;
                    itemWithPages.Pages = Convert.ToInt32(row.ItemArray[count++]);
                }

            }
        }
    }
}
