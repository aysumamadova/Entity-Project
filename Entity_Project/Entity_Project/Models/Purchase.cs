using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Project.Models
{
  public  class Purchase
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
