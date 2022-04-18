using Entity_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Project.DAL
{
   public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5C2LVGI\SQLEXPRESS01;Database=Library2;Trusted_Connection=True;");
        }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        //public DbSet<Genre> Genres { get; set; }
        //public DbSet<GenreBook> GenreBooks { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
