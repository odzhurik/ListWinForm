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
            dt.Columns.Add("Title");
            dt.Columns.Add("Issue");
            dt.Columns.Add("Periodical");
            dv = new DataView(dt);
            foreach (Newspaper item in list)
            {
                dt.Rows.Add(item.Title, item.IssueNumber, item.Periodical);
            }
            
        }
        public void OutputToTableAuthoredItem(List<AuthoredItem> list, out DataTable dt, out DataView dv)
        {
            dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Authors");
            dt.Columns.Add("Pages");
            dv = new DataView(dt);

            foreach (AuthoredItem book in list)
            {
                StringBuilder authors = new StringBuilder();
                foreach (string author in book.Authors)
                {
                    authors.Append(author + ",");
                }
                dt.Rows.Add(book.Title, authors, book.Pages);
            }
           
        }
        public void OutputToTableMagazine(List<Magazine> list, out DataTable dt, out DataView dv)
        {
            dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Issue");
            dv = new DataView(dt);
            foreach (Magazine magazine in list)
            {
                dt.Rows.Add(magazine.Title, magazine.IssueNumber);
            }
         

        }
    }
}
