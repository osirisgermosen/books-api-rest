using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_library_api_net.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public List<Page> Pages { get; set; }
    }
}
