using BooksWF.Models.Instances;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    internal class OutputItem
    {
        public StringBuilder ListOutput(List<PolygraphicItem> items)
        {
            StringBuilder output = new StringBuilder();
            if (items.All(instance => instance is PolygraphicItem))
            {
                output.AppendFormat("{0,-40}", "Title");
            }
            if (items.All(instance => instance is IAuthoredItem))
            {
                output.AppendFormat("{0,-5}", "Author");
            }
            if (items.All(instance => instance is IIssueItem))
            {
                output.AppendFormat("{0,-35}", "Issue Number");
            }
            if (items.All(instance => instance is IPeriodicalItem))
            {
                output.AppendFormat("{0,-16}", "Periodical");
            }
            output.AppendLine();
            foreach (var item in items)
            {
                if (item is PolygraphicItem)
                {
                    output.AppendFormat("{0,-40}", item.Title);
                }
                if (item is IAuthoredItem)
                {
                    IAuthoredItem book = item as IAuthoredItem;
                    foreach (string author in book.Authors)
                    {
                        output.AppendFormat("{0,-5},", author);
                    }
                }
                if (item is IIssueItem)
                {
                    IIssueItem magazine = item as IIssueItem;
                    output.AppendFormat("{0,-35}", magazine.IssueNumber);
                }
                if (item is IPeriodicalItem)
                {
                    IPeriodicalItem newspaper = item as IPeriodicalItem;
                    output.AppendFormat("{0,-16}", newspaper.Periodical);
                }
                output.AppendLine();
            }
            return output;
        }


    }
}
