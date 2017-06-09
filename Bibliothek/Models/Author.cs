using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bibliothek.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [StringLength(2, ErrorMessage = "Please use the 2 character ISO country code")]
        public string Nation { get; set; }
        public bool IsAlive { get; set; }
        public bool HasNobelPrize { get; set; }
        public virtual ICollection<BookInformation> BooksWritten { get; set; }

    }
}