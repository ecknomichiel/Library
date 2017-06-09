using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliothek.DataAccess;

namespace Bibliothek.Models
{
    public class Loan //Business logic class
    {
        private LoanData data;
        private Customer customer;
        public int ID { get { return data.ID; } }
        public DateTime Start { get { return data.Start; } }
        public DateTime End { get { return data.End; } }
        public bool IsReturned { get { return data.IsReturned; } }
        public CustomerData Customer { get { return data.Customer; } }
        public ICollection<Book> Books { get { return data.Books; } }

        public Loan()
        {
            data = new LoanData();
            customer = new Customer(data.Customer);
        }

        public Loan(LoanData loanData, Customer customer = null) //When loading from database
        {
            data = loanData;
            if (customer == null)
            {
                this.customer = new Customer(data.Customer);
            }
            else
            {
                this.customer = customer;
            }
        }

        public bool IsOpen { get; set; }

        internal void AddBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}