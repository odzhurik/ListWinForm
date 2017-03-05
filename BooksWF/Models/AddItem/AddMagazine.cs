using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.AddItem
{
   public class AddMagazine
    {
        public void Add(string title,string issue,List<AuthoredItem> articles)
        {
            Magazine magazine = new Magazine();
            SetItem itemSetter = new SetItem();
            magazine.Title = title;
            magazine.IssueNumber = issue;
            magazine.Articles = articles;
            MagazineList.GetMagazineList(itemSetter).AddItem(magazine);
        }
    }
}
