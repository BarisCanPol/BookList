using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Data
{
    public class Author : BaseEntity
    {
        [Required]
        public string AuthorName { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
