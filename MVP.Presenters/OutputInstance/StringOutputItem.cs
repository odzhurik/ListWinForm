using MVP.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP.Presenters.OutputInstance
{
    public class StringOutputItem : IStringOutputItem
    {
        
        public virtual StringBuilder ListOutput(List<PolygraphicItem> items)
        {
         
            StringBuilder output = new StringBuilder();
            if(items.Count==0)
            {
                 output.Append("No Polygraphic items");
                output.AppendLine();
                return output;
            }
            if (items.All(instance => instance is PolygraphicItem))
            {
               output.AppendFormat("{0,-40}", "Title");
            }
            if (items.All(instance => instance is IAuthoredItem))
            {
              output.AppendFormat("{0,-10}", "Author");

            }
            if (items.All(instance => instance is IIssueItem))
            {
            output.AppendFormat("{0,-35}", "Issue Number");
            }
            if (items.All(instance => instance is IPeriodicalItem))
            {
               output.AppendFormat("{0,-16}", "Periodical");
            }
            if (items.All(instance => instance is IPage))
            {
               output.AppendFormat("{0, 40}", "Pages");
            }
            output.AppendLine();
            foreach (PolygraphicItem item in items)
            {
                if (item is PolygraphicItem)
                {
                   output.AppendFormat("{0,-40}", item.Title);
                }
                if (item is IAuthoredItem)
                {
                    IAuthoredItem book = item as IAuthoredItem;
                    StringBuilder authors = new StringBuilder();
                    for (int i = 0; i < book.Authors.Count; i++)
                    {
                        if (i == book.Authors.Count - 1)
                        {
                            authors.Append(book.Authors[i] + '.');
                            break;
                        }
                        authors.Append(book.Authors[i] + ',');
                    }
                   output.AppendFormat("{0,-45}", authors);
                }
                if (item is IIssueItem)
                {
                    IIssueItem issueItem = item as IIssueItem;
                  output.AppendFormat("{0,-35}", issueItem.IssueNumber);
                }
                if (item is IPeriodicalItem)
                {
                    IPeriodicalItem periodicalItem = item as IPeriodicalItem;
                   output.AppendFormat("{0,-16}", periodicalItem.Periodical);
                }
                if(item is IPage)
                {
                    IPage itemWithPages = item as IPage;
                output.AppendFormat("{0,-7}", itemWithPages.Pages);
                }
                if (item is IArticle)
                {
                    IArticle articleItem = item as IArticle;
                    List<PolygraphicItem> articles = articleItem.Articles.ConvertAll(instance => (PolygraphicItem)instance);
                    output.AppendLine();
                    output.AppendFormat("{0,13}", "Articles:");
                    output.AppendLine();
                    output.Append(ListOutput(articles));
                    output.Append("----------------------------------");
                    output.AppendLine();
                }
                output.AppendLine();
            }
            return output;
        }
    }
}
