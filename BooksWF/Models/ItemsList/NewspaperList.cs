using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System.Collections.Generic;
using System.IO;

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

            if (_newspaperList == null)
            {
                _newspaperList = new NewspaperList();
                _newspaperList.SetList(newspaperSetter);
            }
            return _newspaperList;
        }
        public List<PolygraphicItem> GetList()
        {
            return _list;
        }
        public void SetList(ISetItem newspaperSetter)
        {
            _newspaperSetter = newspaperSetter;
            _list = new List<PolygraphicItem>();
             _list= ReadFromFile("Newspapers.txt");
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
