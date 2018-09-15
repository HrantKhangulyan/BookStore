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
    public static class WorkerWithDB
    {
        public static void InsertInBoughtBooks(Book b, int authorID, int buyerID, string date)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string insert = $"insert into BoughtBooks values ({b.ID},'{b.Name}',{b.Price},{authorID},{buyerID},'{date}')";
                SqlCommand command = new SqlCommand(insert, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void ChangeBookName(string newname, int bookID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string update = $"update BooksInSale set Name = {newname} where ID = {bookID})";
                SqlCommand command = new SqlCommand(update, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void ChangeBookPrice(int newprice, int bookID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string update = $"update BooksInSale set Price = {newprice} where ID = {bookID})";
                SqlCommand command = new SqlCommand(update, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void AddBookInSale(Book b, int authorID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string insert = $"insert into BooksInSale values ({b.ID},'{b.Name}',{b.Price},{authorID})";
                SqlCommand command = new SqlCommand(insert, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void RemoveBookInSale(int bookID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string delete = $"delete from BooksInSale where ID = {bookID}";
                SqlCommand command = new SqlCommand(delete, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void AddUser(User u, int money, string isadmin)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string insert = $"insert into Users values ({u.ID},'{u.FirstName}','{u.LastName}','{u.Login}','{u.PassWord}','{u.PhoneNumber}','{u.Email}',{money},'{isadmin}')";
                SqlCommand command = new SqlCommand(insert, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void AddAuthor(Author a)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                string insert = $"insert into Authors values ({a.ID},'{a.FirstName}','{a.LastName}')";
                SqlCommand command = new SqlCommand(insert, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
