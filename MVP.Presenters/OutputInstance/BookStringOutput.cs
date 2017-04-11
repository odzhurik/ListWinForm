using MVP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Presenters.OutputInstance
{
    public class BookStringOutput
    {
        public StringBuilder ListOutput(List<Book> books)
        {
            StringBuilder output = new StringBuilder();
            if (books.Count == 0)
            {
                output.Append("No Polygraphic items");
                output.AppendLine();
                return output;
            }
            output.AppendFormat("{0,-39} {1,-10}{2,38}", "Title", "Author", "Pages");
            output.AppendLine();
            foreach (Book book in books)
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
                output.AppendFormat("{0,-43}{1,-5}", authors,book.Pages);
                output.AppendLine();
            }
            return output;
        }
    }
}
