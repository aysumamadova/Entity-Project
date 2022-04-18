using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Project.Models
{
  public  class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publishing { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
    }
}
