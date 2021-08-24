using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Book : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
