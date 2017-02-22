using BooksWF.Models.Instances;
using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    public class NewspaperList:IGenerateList
    {
        private List<PolygraphicItem> _list;
        private static NewspaperList _newspaperList;
        protected NewspaperList()
        {

        }
        public static NewspaperList GetNewspaperList()
        {
            if (_newspaperList == null)
                _newspaperList = new NewspaperList();
            return _newspaperList;
        }
        public List<PolygraphicItem> GenerateList()
        {
            _list = new List<PolygraphicItem>();
            return ReadFromFile("Newspapers.txt");
        }
        public  List<PolygraphicItem> ReadFromFile(string path)
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
            return _list;
        }
    }
}
