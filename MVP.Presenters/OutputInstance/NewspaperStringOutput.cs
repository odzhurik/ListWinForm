using MVP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presenters.OutputInstance
{
  public class NewspaperStringOutput
    {
        public StringBuilder ListOutput(List<Newspaper> newspapers)
        {
            StringBuilder output = new StringBuilder();
            if (newspapers.Count == 0)
            {
                output.Append("No Polygraphic items");
                output.AppendLine();
                return output;
            }
            output.AppendFormat("{0,-39} {1,-35}{2,-16}", "Title", "Issue","Periodical");
            output.AppendLine();
            foreach(Newspaper newspaper in newspapers)
            {
                output.AppendFormat("{0,-40}{1,-35}{2,-16}", newspaper.Title, newspaper.IssueNumber, newspaper.Periodical);
                output.AppendLine();
                output.AppendFormat("{0,13}", "Articles:");
                output.AppendLine();
                BookStringOutput outputArticle = new BookStringOutput();
                output.Append(outputArticle.ListOutput(newspaper.Articles));
                output.Append("----------------------------------");
                output.AppendLine();
            }
            return output;
        }
        }
}
