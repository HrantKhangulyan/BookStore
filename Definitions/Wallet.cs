using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class Wallet
    {
        public int Money { get; set; }

        public Wallet(int m)
        {
            Money = m;
        }
    }
}