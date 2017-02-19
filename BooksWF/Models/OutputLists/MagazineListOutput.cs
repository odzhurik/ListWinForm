using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BooksWF.Models.OutputList
{
    internal class MagazineListOutput : OutputList
    {

        protected override List<PolygraphicItem> GenerateList()
        {
            _list = new List<PolygraphicItem>();
            return ReadFromFile("Magazines.txt");
        }

        protected override List<PolygraphicItem> ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
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

    }
}
