﻿using System.Data;
using System.Windows.Forms;

namespace MVP.Forms.SetDataGridView
{
    public class SetDataTableToDataGridView
    {
        public void BindNewspaperDataTableWithDataGridView(DataGridView dataGridView, DataTable dt )
        {
            dataGridView.DataSource = dt;
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "ShowArticles";
            checkColumn.HeaderText = "Show articles";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.Selected = false;
            checkColumn.FillWeight = 10;
            dataGridView.Columns.Add(checkColumn);
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["Id"].ReadOnly = true;
        }
        public void BindBookDataTableWithDataGridView(DataGridView dataGridView, DataTable dt)
        {
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["Id"].ReadOnly = true;
        }
        public void BindMagazineDataTableWithDataGridView(DataGridView dataGridView, DataTable dt)
        {
            dataGridView.DataSource = dt;
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "ShowArticles";
            checkColumn.HeaderText = "Show articles";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.Selected = false;
            checkColumn.FillWeight = 10;
            dataGridView.Columns.Add(checkColumn);
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView.Columns["Id"].ReadOnly = true;
        }
    }
}
