using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_library_api_net.DTOs
{
    public class PageDto
    {
        public int Id { get; set; }
        public string Chapter { get; set; }
        public string Topic { get; set; }
        public int PageNumber { get; set; }
        public string Content { get; set; }
    }
}
