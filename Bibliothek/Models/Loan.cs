using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliothek.Models
{
    public class Loan
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public bool IsReturned { get; set; }
     //   [ForeignKey("LoanTaker")]
        public virtual LoanTaker LoanTaker { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}