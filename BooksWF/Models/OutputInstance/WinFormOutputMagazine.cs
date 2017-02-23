using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputInstance
{
    public class WinFormOutputMagazine : WinFormOutputItem
    {
        public override StringBuilder ListOutput(List<PolygraphicItem> items)
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ListOutput(items));
            foreach (Magazine magazine in items)
            {
                output.AppendFormat("{0,-40}{1,-35}", magazine.Title, magazine.IssueNumber);
                output.AppendLine();
                output.AppendFormat("{0,13}", "Articles:");
                output.AppendLine();
                WinFormOutputAuthoredItem articleOutput = new WinFormOutputAuthoredItem();
                List<PolygraphicItem> articles = magazine.Articles.ConvertAll(instance => (PolygraphicItem)instance);
                output.Append(articleOutput.ListOutput(articles));
                output.Append("----------------------------------");
                output.AppendLine();
            }
            return output;
        }
    }
}
