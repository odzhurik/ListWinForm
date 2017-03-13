using BooksWF.View;
using CardProject.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BooksWF.ChooseInstance
{
    public  class GetListOfArticlesToForm
    {
        public void SelectArticlesToEditInDataGridView(DataGridView dataGridView, ref IEditBookView form,List<AuthoredItem>list)
        {
            form.InitDataTable(list);
            form.InitDataGridView();
            form.ShowForm();
            dataGridView.CancelEdit();
        }
        public void SelectArticlesToDeleteInDataGridView(DataGridView dataGridView, ref IEditBookView form,List<AuthoredItem>list)
        {
            form.InitDataTable(list);
            form.InitDataGridView();
            form.CreateDeleteView();
            form.ShowForm();
            dataGridView.CancelEdit();
        }
    }
}
