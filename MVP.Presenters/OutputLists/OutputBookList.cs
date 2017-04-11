using MVP.Entities;
using MVP.Presenters.OutputInstance;
using System.Collections.Generic;

namespace MVP.Presenters.OutputList
{
    public class OutputBookList
    {
        public string Output(List<Book> list)
        {
            BookStringOutput output = new BookStringOutput();
            return output.ListOutput(list).ToString();
        }
    }
}
