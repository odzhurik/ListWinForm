using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Presenter.Interfaces
{
   public interface IEditMagazinePresenter
    {
        void ShowEditView();
        void ShowDeleteView();
        void RemoveMagazine();
        void LoadMagazines();
    }
}
