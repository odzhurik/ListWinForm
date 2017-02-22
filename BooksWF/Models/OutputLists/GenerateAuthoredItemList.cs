using CardProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
   public abstract  class GenerateAuthoredItemList:IGenerateList
    {
        protected List<PolygraphicItem> _list;
        public abstract List<PolygraphicItem> GenerateList();
        public   List<PolygraphicItem> ReadFromFile(string path)
        {
            _list = new List<PolygraphicItem>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    AuthoredItem authoredItem = new AuthoredItem();
                    SetAuthoredItem(line, ref authoredItem);
                    _list.Add(authoredItem);
                }
            }
            return _list;
        }
        private void SetAuthoredItem(string line, ref AuthoredItem book)
        {
            int index = line.IndexOf('-');
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
                    index = author.IndexOf('-');
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
