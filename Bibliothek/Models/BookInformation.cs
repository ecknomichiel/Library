using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bibliothek.Models
{
    public class BookInformation
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int PublishingYear { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }

    public enum Category
    {
        SciFi,
        Adventure,
        Romance,
        Biography,
        Horses,
        NonFiction
    }
}