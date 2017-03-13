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
        private IStringOutputItem _stringOutput;
        public TextFileSave(IStringOutputItem stringOutput)
        {
           _stringOutput = stringOutput;
        }
        public string SaveInTextFile(List<PolygraphicItem>list)
        {
            using (StreamWriter sr = new StreamWriter("SavedNewspapers.txt"))
            {
                sr.WriteLine(_stringOutput.ListOutput(list));
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
