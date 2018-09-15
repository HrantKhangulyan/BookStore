using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author(int id, string name, string sirname)
        {
            ID = id;
            FirstName = name;
            LastName = sirname;
        }
    }
}
