using MVP.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Models.DAL
{
    public class DatabaseOperation
    {
        public bool AddBookToDb(string connectionString, string databaseName, Book book, int foreignKey = 0, string foreignKeyName = "")
        {
            StringBuilder authors = new StringBuilder();
            int countAddedBooks = 0;
            for (int i = 0; i < book.Authors.Count; i++)
            {
                if (i == book.Authors.Count - 1)
                {
                    authors.Append(book.Authors[i]);
                    break;
                }
                authors.Append(book.Authors[i] + ",");
            }
            string sql = "INSERT INTO " + databaseName + "(Title, Authors, Pages";
            if (!String.IsNullOrEmpty(foreignKeyName))
            {
                sql += ", " + foreignKeyName;
            }
            sql += ") VALUES(" + "'" + book.Title + "'" + ", ";
            sql += "'" + authors + "'," + book.Pages.ToString();
            if (foreignKey != 0)
            {
                sql += ", " + foreignKey;
            }
            sql += ")";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();
                if (number != 0)
                {
                    countAddedBooks++;
                }
            }
            if (countAddedBooks > 0)
            {
                return true;
            }
            return false;
        }
        public int AddMagazineToDb(string connectionString, string databaseName, Magazine magazine)
        {
            string sql = "INSERT INTO " + databaseName + "(Title, Issue) VALUES(" + "'" + magazine.Title + "'" + ", " + "'" + magazine.IssueNumber + "'" + ')';
            int magazineId = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();
                command.Parameters.Clear();
                command.CommandText = "SELECT @@IDENTITY";
                magazineId = Convert.ToInt32(command.ExecuteScalar());
            }
            return magazineId;
        }
        public int AddNewspaperToDb(string connectionString, string databaseName, Newspaper newspaper)
        {
            int newspaperId = 0;
            string sql = "INSERT INTO " + databaseName + "(Title, Issue, Periodical) VALUES(" + "'" + newspaper.Title + "'" + ", '" + newspaper.IssueNumber + "', '" + newspaper.Periodical + "'" + ')';
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();
                command.Parameters.Clear();
                command.CommandText = "SELECT @@IDENTITY";
                newspaperId = Convert.ToInt32(command.ExecuteScalar());
            }
            return newspaperId;
        }
        public void RemoveFromDb(string connectionString, string databaseName, string idName, int idValue)
        {
            string sql = "DELETE FROM " + databaseName + " WHERE " + idName + "=" + idValue;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();
            }
        }
        public void UpdateBookModel(string connectionString, string databaseName, Book book, string foreignKeyName = "", int foreignKeyValue = 0)
        {
            string sql = "UPDATE " + databaseName + " SET Title=" + "'" + book.Title + "'," + "Authors=";
            string authors = "";
            for (int i = 0; i < book.Authors.Count; i++)
            {
                if (i == book.Authors.Count - 1)
                {
                    authors += book.Authors[i];
                    break;
                }
                authors += book.Authors[i] + ',';
            }
            sql += "'" + authors + "', Pages=" + book.Pages;
            if (!String.IsNullOrEmpty(foreignKeyName))
            {
                sql += ", " + foreignKeyName + "=" + foreignKeyValue;
            }
            sql += " WHERE Id=" + book.ID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();

            }
        }
        public void UpdateMagazineModel(string connectionString, string databaseName, Magazine magazine)
        {
            string sql = "UPDATE " + databaseName + " SET Title=" + "'" + magazine.Title + "'," + "Issue='" + magazine.IssueNumber + "'" + " WHERE Id=" + magazine.ID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();
            }
        }
        public void UpdateNewspaperModel(string connectionString, string databaseName, Newspaper newspaper)
        {
            string sql = "UPDATE " + databaseName + " SET Title=" + "'" + newspaper.Title + "'," + "Issue='" + newspaper.IssueNumber + "',Periodical='" + newspaper.Periodical + "' WHERE Id=" + newspaper.ID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int number = command.ExecuteNonQuery();
            }
        }
        public List<Book> GetBooks(string connectionString, string databaseName, string foreignKeyName = "", int foreignKeyValue = 0)
        {
            List<Book> books = new List<Book>();
            string sql = "SELECT * FROM " + databaseName;
            if (!String.IsNullOrEmpty(foreignKeyName))
            {
                sql += " WHERE " + foreignKeyName + "=" + foreignKeyValue;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Book book = new Book();
                    book.ID = Convert.ToInt32(dr[0]);
                    book.Title = Convert.ToString(dr[1]);
                    string author = Convert.ToString(dr[2]);
                    String[] authorsArray = author.Split(',');

                    if (authorsArray.Length >= 2)
                    {
                        if (String.IsNullOrEmpty(authorsArray[1]))
                        {
                            book.Authors.Add(authorsArray[0]);
                        }
                        if (!String.IsNullOrEmpty(authorsArray[1]))
                        {
                            book.Authors.AddRange(authorsArray);
                        }
                    }
                    if (authorsArray.Length < 2)
                    {
                        book.Authors.Add(authorsArray[0]);
                    }
                    book.Pages = Convert.ToInt32(dr[3]);
                    books.Add(book);
                }
                dr.Close();
            }
            return books;
        }
        public List<Magazine> GetMagazines(string connectionString, string databaseName, string databaseArticlesName)
        {
            List<Magazine> magazines = new List<Magazine>();
            string sql = "SELECT * FROM " + databaseName;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Magazine magazine = new Magazine();
                    magazine.ID = Convert.ToInt32(dr[0]);
                    magazine.Title = Convert.ToString(dr[1]);
                    magazine.IssueNumber = Convert.ToString(dr[2]);
                    magazine.Articles = GetBooks(connectionString, databaseArticlesName, "MagazineId", magazine.ID);
                    magazines.Add(magazine);
                }
                dr.Close();
            }
            return magazines;
        }
        public List<Newspaper> GetNewspapers(string connectionString, string databaseName, string databaseArticlesName)
        {
            List<Newspaper> newspapers = new List<Newspaper>();
            string sql = "SELECT * FROM " + databaseName;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Newspaper newspaper = new Newspaper();
                    newspaper.ID = Convert.ToInt32(dr[0]);
                    newspaper.Title = Convert.ToString(dr[1]);
                    newspaper.IssueNumber = Convert.ToString(dr[2]);
                    newspaper.Periodical = Convert.ToString(dr[3]);
                    newspaper.Articles = GetBooks(connectionString, databaseArticlesName, "NewspaperId", newspaper.ID);
                    newspapers.Add(newspaper);
                }
                dr.Close();
            }
            return newspapers;
        }
    }
}

