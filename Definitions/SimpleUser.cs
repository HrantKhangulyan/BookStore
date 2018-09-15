using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class SimpleUser : User
    {
        public SimpleUser(int id, string fn, string ln, string log, string pass, int money, string number, string email, BookStore bs) :
            base(id, fn, ln, log, pass, money, number, email, bs)
        { }

        public SimpleUser(int id, string fn, string ln, string log, string pass, int money, BookStore bs) : base(id, fn, ln, log, pass, money, bs) { }
    }
}
