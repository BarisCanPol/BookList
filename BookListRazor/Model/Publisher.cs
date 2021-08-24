﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Publisher : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Book { get; set; }
        
    }
}
