using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Data
{
    public class Book : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int TotalPages { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Must be select an Publisher")]
        [ForeignKey("PublisherId")]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Must be select an Author")]
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
