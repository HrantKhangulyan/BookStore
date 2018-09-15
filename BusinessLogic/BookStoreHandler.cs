using DataAccess;
using Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class BookStoreHandler
    {
        public static void AddBook(BookStore bs ,Book b)
        {
            bs.books.Add(b);
        }

        public static void AddBookToDB(BookStore bs,Book book)
        {
            bs.books.Add(book);
            Book b = book;
            WorkerWithDB.AddBookInSale(b, book.author.ID);
        }

        public static void RemoveBook(BookStore bs,Book book)
        {
            bs.books.Remove(book);
            WorkerWithDB.RemoveBookInSale(book.ID);
        }

        public static void AddUserToDB(BookStore bs,User u) // adds users to list and database
        {
            AddUser(bs, u);
            WorkerWithDB.AddUser(u, u.wallet.Money, (u is AdminUser).ToString().ToLower());
        }

        public static void AddUser(BookStore bs,User u) // just adds users to list 
        {
            if (u is AdminUser)
            {
                bs.admins.Add((AdminUser)u);
            }
            if (u is SimpleUser)
            {
                bs.Simpleusers.Add((SimpleUser)u);
            }
        }

        public static bool Exists(BookStore bs,Book b)
        {
            return bs.books.Contains(b);
        }
    }
}
