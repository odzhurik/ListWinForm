using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    internal class MagazineListOutput
    {
        private List<Magazine> _list;
        private List<Magazine> GenerateList()
        {
            _list = new List<Magazine>();

            using (StreamReader sr = new StreamReader("Magazines.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Magazine magazine = new Magazine();
                    int index = line.IndexOf('-');
                    magazine.Title = line.Substring(0, index);
                    magazine.IssueNumber = line.Substring(index + 1);
                    _list.Add(magazine);
                }
            }
            return _list;
        }
        public string Output()
        {
            return MagazineOutput.ListOutput(GenerateList()).ToString();
        }
    }
}
