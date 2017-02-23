using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
    public class NewspaperList : IGenerateList
    {
        private List<PolygraphicItem> _list;
        private static NewspaperList _newspaperList;
        private static ISetItem _newspaperSetter;
        protected NewspaperList()
        {

        }
        public static NewspaperList GetNewspaperList(ISetItem newspaperSetter)
        {
            _newspaperSetter = newspaperSetter;
            if (_newspaperList == null)
                _newspaperList = new NewspaperList();
            return _newspaperList;
        }
        public List<PolygraphicItem> GenerateList()
        {
            _list = new List<PolygraphicItem>();
            return ReadFromFile("Newspapers.txt");
        }
        public List<PolygraphicItem> ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Newspaper newspaper = new Newspaper();
                    string[] newspaperParts = line.Split('|');
                    _newspaperSetter.SetPolygraphicItem(newspaperParts[0], newspaper);
                    for (int i = 1; i < newspaperParts.Length; i++)
                    {
                        AuthoredItem article = new AuthoredItem();
                        _newspaperSetter.SetPolygraphicItem(newspaperParts[i], article);
                        newspaper.Articles.Add(article);
                    }
                    _list.Add(newspaper);
                }
            }
            return _list;
        }
    }
}
