using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputInstance
{
   public class TextFileSave
    {
        private IGenerateList _list;
        private IStringOutputItem _stringOutput;
        public TextFileSave(IGenerateList list,IStringOutputItem stringOutput)
        {
            _list = list;
            _stringOutput = stringOutput;
        }
        public string SaveInTextFile()
        {
            using (StreamWriter sr = new StreamWriter("SavedNewspapers.txt"))
            {
                sr.WriteLine(_stringOutput.ListOutput(_list.GetList()));
            }
            FileInfo f = new FileInfo("SavedNewspapers.txt");
            if(f.Length>0)
            {
                return "Successfully saved!";
            }
            return "Not saved";
        }
    }
}
