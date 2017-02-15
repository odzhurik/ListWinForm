using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    internal static class MagazineOutput
    {
        public static StringBuilder ListOutput(List<Magazine> books)
        {

            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0,-40} {1,-35}", "Title", "Issue Number");
            output.AppendLine();

            foreach (Magazine magazine in books)
            {
                output.AppendFormat("{0,-40} {1,-35}", magazine.Title, magazine.IssueNumber);
                output.AppendLine();

            }

            return output;
        }
    }
}
