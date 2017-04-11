using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MVP.Entities;
using System.Configuration;
using MVP.Models.DAL;

namespace MVP.Presenters.OutputInstance
{
    public class DBSave
    {
        private DatabaseOperation _databaseOperation;
        private readonly string _connectionString;
        public DBSave(DatabaseOperation databaseOperation)
        {
            _databaseOperation = databaseOperation;
            _connectionString= ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
        }
        public string SaveInDB(List<Book> list)
        {
            int countAddedBooks = 0;
            foreach (Book book in list)
            {
               if(_databaseOperation.AddBookToDb(_connectionString, "Books",book))
                {
                    countAddedBooks++;
                }
            }
            if(countAddedBooks>0)
            {
                return "Successfuly saved!";
            }

            return "Not saved!";
        }
    }
}
