using BusinessLogic;
using DataAccess;
using Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    //public static class PresentTest
    //{
    //    public static void F()
    //    {
    //        //BookStore bs = new BookStore();
    //        //    AdminUser admin = new AdminUser(1, "Hrant", "Khangulyan", "log", "pass", 40000, bs);
    //        //    BookStoreHandler.AddUserToDB(bs, admin);
    //        //    SimpleUser simple = new SimpleUser(2, "David", "Khangulyan", "Dlog", "Dpass", 10000, bs);
    //        //    BookStoreHandler.AddUserToDB(bs, simple);

    //        //    Author a1 = new Author(1, "Hov", "Tumanyan");
    //        //    WorkerWithDB.AddAuthor(a1);
    //        //    Author a2 = new Author(2, "Exo", "Charenc");
    //        //    WorkerWithDB.AddAuthor(a2);
    //        //    Author a3 = new Author(3, "Lev", "Tolstoy");
    //        //    WorkerWithDB.AddAuthor(a3);

    //        //    Book b1 = new Book(1, "shunnukatun", 500, a1);
    //        //    Book b2 = new Book(2, "ESIMANUSH", 1100, a2);
    //        //    Book b3 = new Book(3, "Russanbook", 2000, a3);
    //        //    Book b4 = new Book(4, "Hovos book", 2300, a1);
    //        //    Book b5 = new Book(5, "Exos book", 5000, a2);
    //        //    Book b6 = new Book(6, "Levs book", 8000, a3);


    //        //    UserHandler.AddBookInShop(admin, b1);
    //        //    UserHandler.AddBookInShop(admin, b2);
    //        //    UserHandler.AddBookInShop(admin, b3);
    //        //    UserHandler.AddBookInShop(admin, b4);
    //        //    UserHandler.AddBookInShop(admin, b5);
    //        //    UserHandler.AddBookInShop(admin, b6);

    //        //    UserHandler.Buy(admin, b2);
    //        //    UserHandler.Buy(admin, b6);
    //        //    UserHandler.Buy(simple, b1);

    //        //    UserHandler.AddMoney(admin, 15000);
    //        //    UserHandler.AddMoney(simple, 2000);
    //        //    Console.WriteLine(admin.wallet.Money);
    //        //    Console.WriteLine(simple.wallet.Money);
    //        //    UserHandler.RetrieveMoney(admin, 2500);
    //        //    UserHandler.RetrieveMoney(simple, 1000);
    //        //    Console.WriteLine(admin.wallet.Money);
    //        //    Console.WriteLine(simple.wallet.Money);

    //        //--------------------------------------------------------------------

    //        //DataGetter.GetAllDataFromDB(bs);
    //        //Console.WriteLine("\t\t\t\t**********ADMINS**********");
    //        //foreach (var admin in bs.admins)
    //        //{
    //        //    Console.WriteLine(admin.FirstName + " , " + admin.LastName);
    //        //    Console.WriteLine("BOOKS****************");
    //        //    foreach (var book in admin.books)
    //        //    {
    //        //        Console.WriteLine(book.ID + " , " + book.Name + " , " + book.Price + " , " + book.PurchaseDate.ToString().Substring(0,10));
    //        //    }
    //        //}
    //        //Console.WriteLine("\t\t\t\t**********SIMPLES**********");
    //        //foreach (var s in bs.Simpleusers)
    //        //{
    //        //    Console.WriteLine(s.FirstName + " , " + s.LastName);
    //        //    Console.WriteLine("BOOKS****************");
    //        //    foreach (var book in s.books)
    //        //    {
    //        //        Console.WriteLine(book.ID + " , " + book.Name + " , " + book.Price + " , " + book.PurchaseDate.ToString().Substring(0, 10));
    //        //    }
    //        //}
    //    }
    //}
}
