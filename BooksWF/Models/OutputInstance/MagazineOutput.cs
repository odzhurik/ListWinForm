using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    internal  class MagazineOutput:OutputItem
    {
        public override StringBuilder ListOutput(List<PolygraphicItem> items)
        {
            List<Magazine> magazines = items.ConvertAll(instance => (Magazine)instance);
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0,-40} {1,-35}", "Title", "Issue Number");
            output.AppendLine();

            foreach (Magazine magazine in magazines)
            {
                output.AppendFormat("{0,-40} {1,-35}", magazine.Title, magazine.IssueNumber);
                output.AppendLine();

            }

            return output;
        }
    }
}
