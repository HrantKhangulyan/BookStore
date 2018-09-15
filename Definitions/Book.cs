using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class Book
    {
        public int ID { get; set; }
        public Author author;
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate;

        public Book(int id, string name, int price, Author a)
        {
            ID = id;
            Name = name;
            Price = price;
            author = a;
        }
    }
}
