using BooksWF.Model;
using BooksWF.Models.ItemsList;
using BooksWF.Models.OutputList;
using BooksWF.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainPresenter presenter = new MainPresenter(new ReadOnlyPolygraphicItemModel(), new MainForm());
            presenter.ShowMainView();
            Application.Run();
        }
    }
}
