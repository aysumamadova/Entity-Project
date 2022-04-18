using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Project.Models
{
   public class GenreBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public  Book Book { get; set; }
        public int GenreId { get; set; }
        public  Genre Genre { get; set; }
    }
}
