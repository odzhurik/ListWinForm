using MVP.Entities;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MVP.Forms
{
    public class OutputToDataTable
    {
        public void OutputToTableNewspaper(List<Newspaper> list, out DataTable dt, out DataView dv)
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Title");
            dt.Columns.Add("Issue");
            dt.Columns.Add("Periodical");
            dv = new DataView(dt);
            foreach (Newspaper item in list)
            {
                dt.Rows.Add(item.ID,item.Title, item.IssueNumber, item.Periodical);
            }
        }
        public void OutputToTableBook(List<Book> list, out DataTable dt, out DataView dv)
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Title");
            dt.Columns.Add("Authors");
            dt.Columns.Add("Pages");
            dv = new DataView(dt);
            foreach (Book book in list)
            {
                StringBuilder authors = new StringBuilder();
                for(int i=0;i<book.Authors.Count;i++)
                {
                    if(book.Authors[i]=="")
                    {
                        break;
                    }
                    if(i==book.Authors.Count-1)
                    {
                        authors.Append(book.Authors[i]);
                        break;
                    }
                    authors.Append(book.Authors[i] + ",");
                }
                dt.Rows.Add(book.ID,book.Title, authors, book.Pages);
            }
        }
        public void OutputToTableMagazine(List<Magazine> list, out DataTable dt, out DataView dv)
        {
            dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Title");
            dt.Columns.Add("Issue");
            dv = new DataView(dt);
            foreach (Magazine magazine in list)
            {
                dt.Rows.Add(magazine.ID,magazine.Title, magazine.IssueNumber);
            }
        }
    }
}
