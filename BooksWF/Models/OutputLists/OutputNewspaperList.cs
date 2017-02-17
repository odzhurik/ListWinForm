using BooksWF.Models.Instances;
using BooksWF.Models.OutputInstance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputList
{
    internal class OutputNewspaperList : OutputList
    {
        protected override List<PolygraphicItem> GenerateList()
        {
            _list = new List<PolygraphicItem>();
            ReadFromFile("Newspapers.txt");
            return _list;
        }
        protected override void ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Newspaper newspaper = new Newspaper();
                    string[] strings = line.Split('-');
                    newspaper.Title = strings[0];
                    newspaper.IssueNumber = strings[1];
                    newspaper.Periodical = strings[2];
                    _list.Add(newspaper);
                }
            }
        }
        public override string Output()
        {
            NewspaperOutput newspaperOutput = new NewspaperOutput();
            return newspaperOutput.ListOutput(GenerateList()).ToString();
        }
    }
}
