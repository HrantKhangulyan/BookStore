using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class BookStore
    {
        public List<Book> books;
        public List<AdminUser> admins;
        public List<SimpleUser> Simpleusers;

        public BookStore()
        {
            books = new List<Book>();
            admins = new List<AdminUser>();
            Simpleusers = new List<SimpleUser>();
        }
    }
}