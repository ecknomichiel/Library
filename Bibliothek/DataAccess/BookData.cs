using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliothek.DataAccess
{
    public class BookData
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Condition { get; set; }
        public bool IsRented { get; set; }
       // [ForeignKey("BookInformation")]
     //   public int BookInformationID { get; set; }
        public virtual BookInformationData BookInformation { get; set; }
        public virtual ICollection<LoanData> Loans { get; set; }
    }
}