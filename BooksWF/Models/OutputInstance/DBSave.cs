using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using CardProject.Models;

namespace BooksWF.Models.OutputInstance
{
    public class DBSave
    {
        private IGenerateList _list;
        public DBSave(IGenerateList list)
        {
            _list = list;
        }
        public string SaveInDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
            int countAddedBooks = 0;
            foreach (AuthoredItem book in _list.GetList())
            {
                string sqlExpression = "INSERT INTO Books (Title, Authors, Pages) VALUES ('" + book.Title + "',";

                StringBuilder authors = new StringBuilder();
                foreach (string author in book.Authors)
                {
                    authors.Append(author + ",");
                }
                sqlExpression += "'" + authors + "'," + book.Pages.ToString() + ")";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    if (number != 0)
                    {
                        countAddedBooks++;
                    }
                }
            }
            if (countAddedBooks > 0)
            {
                return "Successfully saved!";
            }
            return "Not saved!";
        }
    }
}
