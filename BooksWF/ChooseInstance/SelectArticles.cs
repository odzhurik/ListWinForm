using BooksWF.Models;
using BooksWF.Models.OutputList;
using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF.ChooseInstance
{
  public  class SelectArticles
    {
        private IGenerateList _list;
        public SelectArticles(IGenerateList list)
        {
            _list = list;
        }
        public void SelectArticlesToDataGridView(DataGridView dataGridView, int rowIndex,int columnIndex, ref BookEditForm form, DataGridViewCellCancelEventHandler cellBeginEdit, DataGridViewCellEventHandler cellEndEdit)
        {
            SelectInstance select = new SelectInstance();
            List<AuthoredItem> listOfArticles = select.SelectArticles(dataGridView, rowIndex, columnIndex, _list.GetList());
            form = new BookEditForm(listOfArticles);
            form.dataGridViewBooks.CellBeginEdit += cellBeginEdit;
            form.dataGridViewBooks.CellEndEdit += cellEndEdit;
            form.ShowDialog();
            dataGridView.CancelEdit();
        }
    }
}
