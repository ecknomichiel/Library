using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliothek.DataAccess
{
    

    public class LoanData //Parameter object for datapersistency
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public bool IsReturned { get; set; }
        public virtual CustomerData Customer { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}