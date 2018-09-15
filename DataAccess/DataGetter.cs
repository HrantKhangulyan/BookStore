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
    public static class DataGetter
    {
        public static void GetAllDataFromDB(BookStore bs)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                List<User> users = new List<User>(); // users will be added here
                string getallusersQuerry = $"select * from Users"; //gets all users from Users table
                SqlCommand getallusers = new SqlCommand(getallusersQuerry, connection);
                //reader for Users table
                SqlDataReader reader = getallusers.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["ID"];
                        string firstname = (string)reader["FirstName"];
                        string lasttname = (string)reader["LastName"];
                        string login = (string)reader["Login"];
                        string password = (string)reader["PassWord"];
                        string phonenumber = (string)reader["PhoneNumber"];
                        string email = (string)reader["Email"];
                        int money = (int)reader["Money"];

                        if ((string)reader["IsAdmin"] == "true")
                        {
                            AdminUser a = new AdminUser(id, firstname, lasttname, login, password, money, phonenumber, email, bs);
                            bs.admins.Add(a);
                            users.Add(a);
                        }
                        if ((string)reader["IsAdmin"] == "false")
                        {
                            SimpleUser a = new SimpleUser(id, firstname, lasttname, login, password, money, phonenumber, email, bs);
                            bs.Simpleusers.Add(a);
                            users.Add(a);
                        }
                    }
                }
                //finish reading Users table
                reader.Close();
                //----------------------------------------------------------------------------------------------------

                List<Author> authors = new List<Author>(); //authors from database will be added here
                string getallauthorsQuerry = $"select * from Authors";
                SqlCommand getauthors = new SqlCommand(getallauthorsQuerry, connection);
                SqlDataReader authorreader = getauthors.ExecuteReader(); //reader for author table

                if (authorreader.HasRows)
                {
                    while (authorreader.Read())
                    {
                        int id = (int)authorreader["ID"];
                        string firstname = (string)authorreader["FirstName"];
                        string lastname = (string)authorreader["LastName"];
                        authors.Add(new Author(id, firstname, lastname));
                    }
                }

                //finish reading Author table
                authorreader.Close();
                //-----------------------------------------------------------------------------------------------------

                string getbooksinsaleQuerry = $"select * from BooksInSale";
                SqlCommand getbooksinsale = new SqlCommand(getbooksinsaleQuerry, connection); //get books that are not sold yet in order to add them in bookstore
                SqlDataReader bookreader1 = getbooksinsale.ExecuteReader(); //start reading BooksInSale table

                if (bookreader1.HasRows)
                {
                    while (bookreader1.Read())
                    {
                        int id = (int)bookreader1["ID"];
                        string name = (string)bookreader1["Name"];
                        int price = (int)bookreader1["Price"];
                        int authorID = (int)bookreader1["AuthorID"];

                        Author currentbookAuthor = null;

                        foreach (var item in authors) //searching the author of the current book
                        {
                            if (item.ID == authorID)
                            {
                                currentbookAuthor = item;
                                break;
                            }
                        }

                        bs.books.Add(new Book(id, name, price, currentbookAuthor));
                    }
                }

                //finish reading BooksInSale table
                bookreader1.Close();
                //-------------------------------------------------------------------------------------------------

                string getsoldbooksQuerry = $"select * from BoughtBooks";
                SqlCommand getsoldbooks = new SqlCommand(getsoldbooksQuerry, connection);
                SqlDataReader bookreader2 = getsoldbooks.ExecuteReader();

                if (bookreader2.HasRows)
                {
                    while (bookreader2.Read())
                    {
                        int id = (int)bookreader2["ID"];
                        string name = (string)bookreader2["Name"];
                        int price = (int)bookreader2["Price"];
                        int authorID = (int)bookreader2["AuthorID"];
                        int ownerID = (int)bookreader2["OwnerID"];
                        DateTime date = (DateTime)bookreader2["PurchaseDate"];

                        Author currentbookAuthor = null;

                        foreach (var item in authors) //searching the author of the current book
                        {
                            if (item.ID == authorID)
                            {
                                currentbookAuthor = item;
                                break;
                            }
                        }

                        User CurrntBookOwner = null;

                        foreach (var item in users) //searching the owner of the current book
                        {
                            if (item.ID == ownerID)
                            {
                                CurrntBookOwner = item;
                                break;
                            }
                        }

                        Book book = new Book(id, name, price, currentbookAuthor);
                        book.PurchaseDate = date;
                        CurrntBookOwner.books.Add(book); //adds book to users inventory
                    }
                }

                //finish reading BoughtBooks table
                bookreader2.Close();
            }
        }
    }
}
