using BooksWF.Models;
using BooksWF.Models.Instances;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using BooksWF.Models.Search;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.SetDataGridView
{
    public class SelectFromDataGridViewRow
    {
        private IGenerateList _list;
        public SelectFromDataGridViewRow(IGenerateList list)
        {
            _list = list;
        }
        public void SelectNewspaper(DataGridViewRowStateChangedEventArgs e, ref Newspaper editedNewspaper)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            Newspaper newspaper = new Newspaper();
            setter.Set(newspaper, row);
            editedNewspaper = _list.GetList().FirstOrDefault(newspaperItem => newspaperItem.Title == newspaper.Title) as Newspaper;
        }
        public void SelectBook(DataGridViewRowStateChangedEventArgs e, ref AuthoredItem editedBook)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            AuthoredItem book = new AuthoredItem();
            setter.Set(book, row);
            editedBook = _list.GetList().FirstOrDefault(bookItem => bookItem.Title == book.Title) as AuthoredItem;
        }
        public void SelectMagazine(DataGridViewRowStateChangedEventArgs e, ref Magazine editedMagazine)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            Magazine magazine = new Magazine();
            setter.Set(magazine, row);
            editedMagazine = _list.GetList().FirstOrDefault(magazineItem => magazineItem.Title == magazine.Title) as Magazine;
        }
        public PolygraphicItem SelectItemWithArticle(DataGridViewRowStateChangedEventArgs e, ref AuthoredItem selectedArticle)
        {
            SelectArticle(e, ref selectedArticle);
            SearchByArticle search = new SearchByArticle();
            PolygraphicItem item = search.Search(selectedArticle, _list.GetList()) as Newspaper;
            if (item != null)
            {
                return item;
            }
            item = search.Search(selectedArticle, _list.GetList()) as Magazine;
            if (item != null)
            {
                return item;
            }
            return null;
        }
        private void SelectArticle(DataGridViewRowStateChangedEventArgs e, ref AuthoredItem selectedArticle)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            DataGridViewRow row = e.Row;
            SetFromTable setter = new SetFromTable();
            setter.Set(selectedArticle, row);

        }
    }
}
