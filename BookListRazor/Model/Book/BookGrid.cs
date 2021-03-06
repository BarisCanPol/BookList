using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model.Book
{
    public class BookGrid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string AuthorName { get; set; }
    }
}
