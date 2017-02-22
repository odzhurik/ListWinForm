using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models
{
   public class MagazineList:IGenerateList
    {
       private List<PolygraphicItem> _list;
       private static MagazineList _magazineList;
        protected  MagazineList()
        {
                
        }
        public static MagazineList GetMagazineList()
        {
            if(_magazineList == null)
                _magazineList = new MagazineList();
            return _magazineList;
        }
        public List<PolygraphicItem> GenerateList()
        {
            _list = new List<PolygraphicItem>();
            return ReadFromFile("Magazines.txt");
        }
       public List<PolygraphicItem> ReadFromFile(string path)
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
