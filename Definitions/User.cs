using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Wallet wallet; //users wallet
        public List<Book> books; //list of his books
        public BookStore bookstore; //the bookstore where he is a customer

        public User(int ID, string fn, string ln, string log, string pass, int money, string pnumber, string email, BookStore bs)
        {
            this.ID = ID;
            FirstName = fn;
            LastName = ln;
            Login = log;
            PassWord = pass;
            PhoneNumber = pnumber;
            Email = email;
            bookstore = bs;
            wallet = new Wallet(money);
            books = new List<Book>();
        }

        public User(int id, string fn, string ln, string log, string pass, int money, BookStore bs) : this(id, fn, ln, log, pass, money, "---", "---", bs) { }
    }
}
