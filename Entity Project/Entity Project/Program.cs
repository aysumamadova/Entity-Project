using Entity_Project.DAL;
using Entity_Project.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Reqem daxil edin\n1.Kitab yaradin\n2.Idye gore kitabigetirmek\n3.Kitab almaq\n4.Satilan sonuncu kitabin melumatlari\n5.Kitab silme" );
            int i = Convert.ToInt32(Console.ReadLine());
           
                if (i == 1)
                {
                    CreateBook();
                }
                else if (i == 2)
                {
                    GetBook();
                }
                else if (i == 3)
                {
                    BuyBook();
                }
                else if (i == 4)
                {
                    Purchase();

                } 
                else if (i == 5)
                {
                  RemoveBook();
                }

        }





        /// <summary>
        /// Yeni kitab yaratmaq
        /// </summary>
        /// <returns></returns>
        public static async Task CreateBook()
        {
            string bookName = string.Empty;
            Console.WriteLine( "Kitabin adini daxil edin");
            bookName = Console.ReadLine();

            string Publishing = string.Empty;
            Console.WriteLine("Nesiryyatin adini daxil edin");
            Publishing = Console.ReadLine(); 

            string AuthorName = string.Empty;
            Console.WriteLine("Yazici adini daxil edin");
            AuthorName = Console.ReadLine(); 

            string GenreName = string.Empty;
            Console.WriteLine("Janr adini daxil edin");
            GenreName = Console.ReadLine();

            Console.WriteLine("Senhife sayini daxil edin");
            int PageCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Stok sayini daxil edin");
            int StockCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Qiymeti  daxil edin");
            double Price = Convert.ToDouble(Console.ReadLine());

            using (AppDbContext db=new AppDbContext())
            {
                Book book = new Book
                {
                    Name = bookName,
                    Publishing = Publishing,
                    PageCount = PageCount,
                    StockCount = StockCount,
                    Price = Price,
                    AuthorName = AuthorName,
                    GenreName = GenreName
                };
                db.Books.Add(book);
                db.SaveChanges();

            };
            Console.WriteLine("Kitab elave edilid");
        }





        /// <summary>
        /// Id sine gore kitab melumatlarina baxma
        /// </summary>
        public static void GetBook()
        {
            using (AppDbContext db = new AppDbContext())
            {
                Console.WriteLine("Kitab Idsimi daxil edin");
                int idd = Convert.ToInt32(Console.ReadLine());
                Book book = db.Books.Find(idd);
                Console.WriteLine($"Name:{book.Name} GenreName:{book.GenreName} AuthorName:{book.AuthorName} PageCount:{book.PageCount} Publishing:{book.Publishing} StockCount{book.StockCount} Price{book.Price}");
            }
        }
       

        /// <summary>
        /// Id e gore kitab alirsan. Stokdan bitene qeder
        /// </summary>
        /// <returns></returns>
        public static async Task BuyBook()
        {
            Console.WriteLine("Kitab Idsimi daxil edin");
            int BookId = Convert.ToInt32(Console.ReadLine());
            using (AppDbContext db = new AppDbContext())
            {
                Purchase purchase = new Purchase()
                {
                    BookId = BookId
                };
                db.Purchases.Add(purchase);

                var result = db.Books.SingleOrDefault(b => b.Id == BookId);
                if (result != null)
                {
                    result.StockCount += -1;
                    db.SaveChanges();
                }

                db.SaveChanges();
            }
            Console.WriteLine("Kitab alindi");
        }



        /// <summary>
        /// /Sonuncu satilan kitabi qaytarir
        /// </summary>
        /// <returns></returns>
        public static async Task Purchase()
        {
            using (AppDbContext db = new AppDbContext())
            {
                Purchase purchase = db.Purchases.First();
                var result = db.Books.SingleOrDefault(p => p.Id == purchase.BookId);
                Console.WriteLine($"Name:{result.Name} GenreName:{result.GenreName} AuthorName:{result.AuthorName}  Price{result.Price}");
            }
        }
        static void RemoveBook()
        {
            Console.WriteLine("Kitab Idsimi daxil edin");
            int BookId = Convert.ToInt32(Console.ReadLine());
            using (AppDbContext db = new AppDbContext())
            {
                if (!db.Books.Any(p => p.Id == BookId)) return;
                Book book = db.Books.SingleOrDefault(p => p.Id == BookId);
                
                db.Remove(book);
                db.SaveChanges();
            }
            Console.WriteLine("Kitab silindi");
        }
       

    }
}
