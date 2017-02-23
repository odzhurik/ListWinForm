using BooksWF.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputInstance
{
  public  class WinFormOutputNewspaper:WinFormOutputItem
    {
        public override StringBuilder ListOutput(List<PolygraphicItem> items)
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ListOutput(items));
            foreach(Newspaper newspaper in items)
            {
                output.AppendFormat("{0,-40}{1,-35}{2,-16}", newspaper.Title,newspaper.IssueNumber,newspaper.Periodical);
                output.AppendLine();
                output.AppendFormat("{0,13}", "Articles:");
                output.AppendLine();
                List<PolygraphicItem> articles = newspaper.Articles.ConvertAll(instance => (PolygraphicItem)instance);
                WinFormOutputAuthoredItem articleOutput = new WinFormOutputAuthoredItem();
                output.Append(articleOutput.ListOutput(articles));
                output.Append("----------------------------------");
                output.AppendLine();
            }
            return output;
        }
    }
}
