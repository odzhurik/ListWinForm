using MVP.Entities;
using System;

namespace MVP.Models.ItemSetter
{
    public class SetItem : ISetItem
    {
        public void SetPolygraphicItem(string line, PolygraphicItem item)
        {
            string[] itemsStrings = line.Split('-');
            int count = 0;
            if (item is IAuthoredItem)
            {
                IAuthoredItem authoredItem = item as IAuthoredItem;
                string[] authors = itemsStrings[count].Split(',');
                if (authors.Length == 1)
                {
                    authoredItem.Authors.Add(itemsStrings[count]);
                }
                if (authors.Length > 1)
                {
                    foreach (string author in authors)
                    {
                        authoredItem.Authors.Add(author);
                    }
                }
                count++;
            }
            if (item is PolygraphicItem)
            {
                item.Title = itemsStrings[count++];
            }
            if (item is IIssueItem)
            {
                IIssueItem magazine = item as IIssueItem;
                magazine.IssueNumber = itemsStrings[count++];
            }
            if (item is IPeriodicalItem)
            {
                IPeriodicalItem newspaper = item as IPeriodicalItem;
                newspaper.Periodical = itemsStrings[count++];
            }
            if (item is IPage)
            {
                IPage book = item as IPage;
                book.Pages = Convert.ToInt32(itemsStrings[count++]);
            }

        }
    }
}
