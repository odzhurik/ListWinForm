﻿using CardProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.ItemsList
{
   public interface ISetItem
    {
       void SetPolygraphicItem(string line, PolygraphicItem item);
    }
}
