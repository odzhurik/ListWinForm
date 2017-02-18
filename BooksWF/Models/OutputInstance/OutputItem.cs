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
            if (items.All(instance => instance is Book))
            {
                output.AppendFormat("{0,-5}", "Author");
            }
            if (items.All(instance => instance is Magazine))
            {
                output.AppendFormat("{0,-35}", "Issue Number");
            }
            if (items.All(instance => instance is Newspaper))
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
                if (item is Book)
                {
                    Book book = item as Book;
                    foreach (string author in book.Authors)
                    {
                        output.AppendFormat("{0,-5},", author);
                    }
                }
                if (item is Magazine)
                {
                    Magazine magazine = item as Magazine;
                    output.AppendFormat("{0,-35}", magazine.IssueNumber);
                }
                if (item is Newspaper)
                {
                    Newspaper newspaper = item as Newspaper;
                    output.AppendFormat("{0,-16}", newspaper.Periodical);
                }
                output.AppendLine();
            }
            return output;
        }


    }
}
