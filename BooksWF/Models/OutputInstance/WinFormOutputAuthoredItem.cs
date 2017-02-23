using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputInstance
{
  public  class WinFormOutputAuthoredItem:WinFormOutputItem
    {
        public override StringBuilder ListOutput(List<PolygraphicItem> items)
        {
            StringBuilder output = new StringBuilder();
            output.Append( base.ListOutput(items));
            foreach (AuthoredItem book in items)
            {
                output.AppendFormat("{0,-40}", book.Title);
                StringBuilder authors = new StringBuilder();
                for (int i = 0; i < book.Authors.Count; i++)
                {
                    if (i == book.Authors.Count - 1)
                    {
                        authors.Append(book.Authors[i] + '.');
                        break;
                    }
                    authors.Append(book.Authors[i] + ',');
                }
                output.AppendFormat("{0,-40}{1,-7}", authors,book.Pages);
                output.AppendLine();
            }
            return output;
        }
    }
}
