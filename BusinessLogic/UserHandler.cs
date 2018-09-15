using DataAccess;
using Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class UserHandler
    {
        public static void Buy(User u, Book book)
        {
            if (BookStoreHandler.Exists(u.bookstore, book))
            {
                if (u.wallet.Money >= book.Price)
                {
                    u.books.Add(book);
                    WalletHandler.SubstractMoney(u.wallet, book.Price);
                    BookStoreHandler.RemoveBook(u.bookstore, book);
                    book.PurchaseDate = DateTime.Now;
                    Book b = book;
                    WorkerWithDB.InsertInBoughtBooks(b, book.author.ID, u.ID, book.PurchaseDate.ToString("yyyy-MM-dd"));
                    HistoryRecorder.RecordPurchase(u, book, book.PurchaseDate.ToString("yyyy-MM-dd"), u.wallet.Money);
                }
                else throw new Exception("User doesnt have enough money");
            }
            else throw new Exception("There is not such book in the shop");
        }

        public static void AddMoney(User u, int amount) //adds some amount of money to users wallet
        {
            if (amount > 0)
            {
                WalletHandler.AddMoney(u.wallet, amount);
                DateTime date = DateTime.Now; //the date when money was added
                HistoryRecorder.RecordBallanceChange(u, amount, "add", date.Date.ToString("yyyy-MM-dd"), u.wallet.Money);
                return;
            }
            throw new Exception("Money should be more or equal to 0");
        }

        public static void RetrieveMoney(User u, int amount) //picks some amount of money from users wallet
        {
            if (amount > 0 && u.wallet.Money - amount >= 0)
            {
                u.wallet.Money -= amount;
                DateTime date = DateTime.Now; //the date when money was retrieved
                HistoryRecorder.RecordBallanceChange(u, amount, "substract", date.Date.ToString("yyyy-MM-dd"), u.wallet.Money);
                return;
            }
            throw new Exception("Money should be more or equal to 0 ,, or you pucked more money");
        }

        public static void AddBookToInventory(User u, Book b)
        {
            u.books.Add(b);
        }

        
        public static void AddBookInShop(User u, Book book) //<FOR ADMINS> adds new book to shop and also in database
        {
            if (u is AdminUser)
                BookStoreHandler.AddBookToDB(u.bookstore, book);
            else throw new Exception("You are not admin");
        }

        public static void ChangeBookName(User u ,Book book, string newname)
        {

            if (u is AdminUser)
            {
                book.Name = newname;
                WorkerWithDB.ChangeBookName(newname, book.ID);
                return;
            }
            throw new Exception("You are not admin");
        } //<FOR ADMINS> changes book name

        public static void RemoveBookFromShop(User u, Book book)
        {
            if (u is AdminUser)
                BookStoreHandler.RemoveBook(u.bookstore, book);
            else throw new Exception("You are not admin");


        } //<FOR ADMINS> removes book from shop and database

        public static void ChangeBookPrice(User u,Book book, int newprice)
        {
            if (u is AdminUser)
            {
                book.Price = newprice;
                WorkerWithDB.ChangeBookPrice(newprice, book.ID);
                return;
            }
            throw new Exception("You are not admin");
        } //<FOR ADMINS> changes book price
    }
}
