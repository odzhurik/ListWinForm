using BooksWF.Models.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputInstance
{
    internal class NewspaperOutput : OutputItem
    {
        public override StringBuilder ListOutput(List<PolygraphicItem> items)
        {
            StringBuilder output = new StringBuilder();
            List<Newspaper> newspapers = items.ConvertAll(instance => (Newspaper)instance);
            output.AppendFormat("{0,-40} {1,-35} {2, -16}", "Title", "Issue Number", "Periodical");
            output.AppendLine();

            foreach (Newspaper newspaper in newspapers)
            {
                output.AppendFormat("{0,-40} {1,-35} {2,-16}", newspaper.Title, newspaper.IssueNumber, newspaper.Periodical);
                output.AppendLine();
            }

            return output;
        }
    }
}
