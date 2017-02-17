using BooksWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProject.Models
{
    internal  class BookOutput:OutputItem
    {
        public override StringBuilder ListOutput(List<PolygraphicItem> items)
        {
            List<Book> books = items.ConvertAll(instance => (Book)instance);

            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0,-40} {1,-5}", "Title", "Author");
            output.AppendLine();
            
            foreach (Book book in books)
            {
                output.AppendFormat("{0,-40}", book.Title);
                foreach(string author in book.Authors)
                {
                    output.AppendFormat("{0,-5},", author);
                }
                output.AppendLine();

            }
            
            return output;
        }
    }
}
