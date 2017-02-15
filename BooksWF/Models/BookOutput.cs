using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProject.Models
{
    internal static class BookOutput
    {
        public static StringBuilder ListOutput(List<Book> books)
        {

            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0,-40} {1,-35}", "Title", "Author");
            output.AppendLine();
            
            foreach (Book book in books)
            {
                output.AppendFormat("{0,-40} {1,-35}", book.Title, book.Author);
                output.AppendLine();

            }
            
            return output;
        }
    }
}
