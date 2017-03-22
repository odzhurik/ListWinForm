using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MVP.Entities;
using System.Configuration;

namespace MVP.Presenters.OutputInstance
{
    public class DBSave
    {
        public string SaveInDB(List<PolygraphicItem>list)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
            int countAddedBooks = 0;
            foreach (AuthoredItem book in list)
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
