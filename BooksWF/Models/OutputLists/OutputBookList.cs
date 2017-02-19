﻿using BooksWF.Models;
using BooksWF.Models.OutputList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProject.Models
{
    internal class OutputBookList : OutputList
    {
        protected override List<PolygraphicItem> GenerateList()
        {
            _list = new List<PolygraphicItem>();
            return ReadFromFile("Books.txt");
        }

        protected override List<PolygraphicItem> ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Book book = new Book();
                    SetBook(line, ref book);
                    _list.Add(book);
                }
            }
            return _list;
        }
        private void SetBook(string line, ref Book book)
        {
            int index = line.IndexOf('-');
            string[] authors = line.Split(',');

            if (authors.Length == 1)
            {
                book.Authors.Add(line.Substring(0, index));
                book.Title = line.Substring(index + 1);
            }
            if (authors.Length > 1)
            {
                foreach (string author in authors)
                {
                    index = author.IndexOf('-');
                    if (index != -1)
                    {
                        book.Title = author.Substring(index + 1);
                        book.Authors.Add(author.Substring(0, index));
                        break;
                    }
                    book.Authors.Add(author);
                }
            }
        }
    }
}
