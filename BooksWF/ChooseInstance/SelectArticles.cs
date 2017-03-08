﻿using BooksWF.Models;
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
        private SelectInstanceFromDataGridView _selectInstance;
        public SelectArticles(IGenerateList list,SelectInstanceFromDataGridView selectInstance)
        {
            _list = list;
            _selectInstance = selectInstance;
        }
        public void SelectArticlesToEditInDataGridView(DataGridView dataGridView, int rowIndex,int columnIndex, ref BookEditForm form, DataGridViewCellCancelEventHandler CellBeginEdit, DataGridViewCellEventHandler CellEndEdit)
        {
            List<AuthoredItem> listOfArticles = _selectInstance.SelectArticles(dataGridView, rowIndex, columnIndex, _list.GetList());
            form = new BookEditForm(listOfArticles);
            form.dataGridViewBooks.CellBeginEdit += CellBeginEdit;
            form.dataGridViewBooks.CellEndEdit += CellEndEdit;
            form.ShowDialog();
            dataGridView.CancelEdit();
        }
        public void SelectArticlesToDeleteInDataGridView(DataGridView dataGridView, int rowIndex, int columnIndex, ref BookEditForm form,DataGridViewRowStateChangedEventHandler RowStateChanged, EventHandler ButtonClick)
        {
            List<AuthoredItem> listOfArticles = _selectInstance.SelectArticles(dataGridView, rowIndex, columnIndex, _list.GetList());
            form = new BookEditForm(listOfArticles, "Delete");
            form.dataGridViewBooks.RowStateChanged += RowStateChanged;
            form.buttonDelete.Click += ButtonClick;
            form.ShowDialog();
            dataGridView.CancelEdit();
        }
    }
}
