﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWF.Models.OutputInstance
{
   public interface IStringOutputItem
    {
        StringBuilder ListOutput(List<PolygraphicItem> items);
    }
}
