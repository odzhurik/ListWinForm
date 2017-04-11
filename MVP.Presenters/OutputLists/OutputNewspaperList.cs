using MVP.Entities;
using MVP.Presenters.OutputInstance;
using System.Collections.Generic;

namespace MVP.Presenters.OutputList
{
    public class OutputNewspaperList
    {
        public string Output(List<Newspaper>list)
        {
            NewspaperStringOutput output = new NewspaperStringOutput();
            return output.ListOutput(list).ToString();
        }
    }
}
