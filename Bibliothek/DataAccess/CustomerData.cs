using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bibliothek.DataAccess
{
    public class Customer // BL class
    {
        private CustomerData data = new CustomerData();
        private List<Loan> loans = null;

        public int ID { get { return data.ID; } }
        public string MembershipNumber { get { return data.MembershipNumber; } }
        public string Name { get { return data.Name; } }
        public IEnumerable<Loan> Loans { get { return GetLoans(); } }

        private List<Loan> GetLoans() //Lazy instantiation / virtual proxy pattern
        {
            if (loans == null)
            { // Load loans list from customer data
                loans = new List<Loan>();
                loans.Capacity = data.Loans.Count();
                foreach (LoanData loan in data.Loans)
                {
                    loans.Add(new Loan(loan, this));
                }
            }
            return loans;
        }

        private Loan GetOpenLoan()
        {
            for (int i = GetLoans().Count(); i > -1; i--)
            { // Go through this list backwards, because a loan that has not been checked out yet is likely to be at the end of the list
                if (GetLoans()[i].IsOpen)
                {
                    return GetLoans()[i];
                }
            }
            Loan result = new Loan(new LoanData(), this); //Start a new loan
            GetLoans().Add(result);
            return result;
        }

        public bool BorrowBook(Book book)
        {
            GetOpenLoan().AddBook(book);

            return true;
        }

        public Customer()
        {
            data = new CustomerData();
        }

        public Customer(CustomerData customerData)
        {
            data = customerData;
        }
    }

    public class CustomerData //Parameter object for persistency
    {
        [Key]
        public int ID { get; set; }
        public string MembershipNumber { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public virtual ICollection<LoanData> Loans { get; set; }

        public CustomerData()
        {
            Loans = new List<LoanData>();
        }
    }
}