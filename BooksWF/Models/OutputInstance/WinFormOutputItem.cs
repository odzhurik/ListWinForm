using BooksWF.Models.Instances;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    public class WinFormOutputItem
    {
        public virtual StringBuilder  ListOutput(List<PolygraphicItem> items)
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
            if (items.All(instance => instance is IPage))
            {
                output.AppendFormat("{0, 38}", "Pages");
            }
            output.AppendLine();
           
            return output;
        }
    }
}
