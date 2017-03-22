using MVP.Entities;
using System;
using System.Windows.Forms;

namespace MVP.Forms.GetItem
{
    public class GetFromDataGridViewRow
    {
        public void GetItem(PolygraphicItem item, DataGridViewRow row)
        {
            int count = 0;
            if (item is IArticle)
            {
                count = 1;
            }
            if (!(item is IArticle))
            {
                count = 0;
            }
            if (item is PolygraphicItem)
            {
                item.Title = row.Cells[count++].Value.ToString();
            }
            if (item is IAuthoredItem)
            {
                IAuthoredItem authoredItem = item as IAuthoredItem;
                string authorString = (string)row.Cells[count++].Value;
                string[] authors = authorString.Split(',');
                authoredItem.Authors.Clear();
                for (int i = 0; i < authors.Length - 1; i++)
                {
                    authoredItem.Authors.Add(authors[i]);
                }
            }
            if (item is IIssueItem)
            {
                IIssueItem issueItem = item as IIssueItem;
                issueItem.IssueNumber = row.Cells[count++].Value.ToString();
            }
            if (item is IPeriodicalItem)
            {
                IPeriodicalItem periodicalItem = item as IPeriodicalItem;
                periodicalItem.Periodical = row.Cells[count++].Value.ToString();
            }
            if (item is IPage)
            {
                IPage itemWithPages = item as IPage;
                itemWithPages.Pages = Convert.ToInt32(row.Cells[count++].Value);
            }
        }

    }
}

