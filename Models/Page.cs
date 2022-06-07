using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace books_library_api_net.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Chapter { get; set; }
        public string Topic { get; set; }
        public int PageNumber { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }

        [NotMapped]
        public string Content { get; set; }
    }
}
