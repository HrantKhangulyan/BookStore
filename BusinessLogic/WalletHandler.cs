using Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class WalletHandler
    {
        public static void AddMoney(Wallet w,int amount) //adds money in wallet
        {
            w.Money += amount;
        }

        public static void SubstractMoney(Wallet w,int amount) //substracts money from wallet
        {
            w.Money -= amount;
        }
    }
}
