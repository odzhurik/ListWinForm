using MVP.Entities;
using System;
using System.Windows.Forms;

namespace MVP.Forms.GetItem
{
    public class GetFromDataGridViewRow
    {
        public void GetBook(Book book, DataGridViewRow row)
        {
            int count = 0;
            book.ID = Convert.ToInt32(row.Cells[count++].Value);
            book.Title = row.Cells[count++].Value.ToString();
            string authorString = (string)row.Cells[count++].Value;
            string[] authors = authorString.Split(',');
            book.Authors.Clear();
            for (int i = 0; i < authors.Length; i++)
            {
                if(String.IsNullOrEmpty(authors[i]))
                {
                    break;
                }
                book.Authors.Add(authors[i]);
            }
            book.Pages = Convert.ToInt32(row.Cells[count++].Value);
        }
        public void GetMagazine(Magazine magazine, DataGridViewRow row)
        {
            int count = 1;
            magazine.ID = Convert.ToInt32(row.Cells[count++].Value);
            magazine.Title = row.Cells[count++].Value.ToString();
            magazine.IssueNumber = row.Cells[count++].Value.ToString();
        }
        public void GetNewspaper(Newspaper newspaper, DataGridViewRow row)
        {
            int count = 1;
            newspaper.ID = Convert.ToInt32(row.Cells[count++].Value);
            newspaper.Title = row.Cells[count++].Value.ToString();
            newspaper.IssueNumber = row.Cells[count++].Value.ToString();
            newspaper.Periodical = row.Cells[count++].Value.ToString();
        }
    }
}

