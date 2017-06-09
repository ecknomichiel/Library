using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliothek.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Condition { get; set; }
        public bool IsRented { get; set; }
       // [ForeignKey("BookInformation")]
     //   public int BookInformationID { get; set; }
        public virtual BookInformation BookInformation { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}