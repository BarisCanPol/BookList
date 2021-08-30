using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Data
{
    public class Genre : BaseEntity
    {
        [Required]
        public string GenreName { get; set; }
        public int? ParentId { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
