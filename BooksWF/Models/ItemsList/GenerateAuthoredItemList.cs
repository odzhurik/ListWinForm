using CardProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
    public class GenerateAuthoredItemList
    {
        public void SetAuthoredItem(string line, AuthoredItem book)
        {
            string[] itemsStrings = line.Split('-');
            string[] authors = itemsStrings[0].Split(',');
            book.Pages = Convert.ToInt32(itemsStrings[2]);
            book.Title = itemsStrings[1];
            if (authors.Length == 1)
            {
                book.Authors.Add(itemsStrings[0]);

            }
            if (authors.Length > 1)
            {
                foreach (string author in authors)
                {
                    int index = author.IndexOf('-');
                    if (index != -1)
                    {
                        book.Title = author.Substring(index + 1);
                        book.Authors.Add(author.Substring(0, index));
                        break;
                    }
                    book.Authors.Add(author);
                }
            }
        }
    }
}
