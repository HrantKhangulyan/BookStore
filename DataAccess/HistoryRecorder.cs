using Definitions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class HistoryRecorder
    {
        public static void RecordPurchase(User u, Book book, string date, int usermoney)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string insert = $"insert into PurchaseHistory values ({book.ID},{u.ID},'{date}')";
                string update = $"update Users set Money = {usermoney} where id = {u.ID}";
                SqlCommand command = new SqlCommand(insert, connection);
                SqlCommand comman2 = new SqlCommand(update, connection);
                command.ExecuteNonQuery();
                comman2.ExecuteNonQuery();
            }
        }


        public static void RecordBallanceChange(User u, int amount, string addorsubstract, string date, int usermoney) //records history of changing users ballance by themselves. addorsubstract shows wheater money is added or substracted
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string insert = string.Empty;
                switch (addorsubstract)
                {
                    case ("add"):
                        string status1 = "Added";
                        insert = $"insert into BallanceChangingHistory values ({u.ID},'{status1}',{amount},{usermoney},'{date}')";
                        break;

                    case ("substract"):
                        string status2 = "Substracted";
                        insert = $"insert into BallanceChangingHistory values ({u.ID},'{status2}',{amount},{usermoney},'{date}')";
                        break;
                }
                string update = $"update Users set Money = {usermoney} where id = {u.ID}";
                SqlCommand command = new SqlCommand(insert, connection);
                SqlCommand comman2 = new SqlCommand(update, connection);
                command.ExecuteNonQuery();
                comman2.ExecuteNonQuery();
            }
        }
    }
}
