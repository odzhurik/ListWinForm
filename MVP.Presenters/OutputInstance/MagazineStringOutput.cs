using MVP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presenters.OutputInstance
{
    public class MagazineStringOutput
    {
        public StringBuilder ListOutput(List<Magazine> magazines)
        {
            StringBuilder output = new StringBuilder();
            if (magazines.Count == 0)
            {
                output.Append("No Polygraphic items");
                output.AppendLine();
                return output;
            }
            output.AppendFormat("{0,-39} {1,-35}", "Title", "Issue");
            output.AppendLine();
            foreach (Magazine magazine in magazines)
            {
                output.AppendFormat("{0,-40}{1,-35}", magazine.Title, magazine.IssueNumber);
                output.AppendLine();
                output.AppendFormat("{0,13}", "Articles:");
                output.AppendLine();
                BookStringOutput outputArticle = new BookStringOutput();
                output.Append(outputArticle.ListOutput(magazine.Articles));
                output.Append("----------------------------------");
                output.AppendLine();
            }
            return output;
        }
    }
}
