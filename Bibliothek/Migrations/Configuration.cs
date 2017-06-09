namespace Bibliothek.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bibliothek.DataAccess;
    using System.Data.SqlClient;

    internal sealed class Configuration : DbMigrationsConfiguration<Bibliothek.DataAccess.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bibliothek.DataAccess.LibraryDbContext context)
        {
            #region Instantiating
            Book book = new BookData(){ID = 1, 
                Condition = "Mint", IsRented = true, Loans = new List<LoanData>() };
            Author author = new Author(){ ID=1,
                BooksWritten = new List<BookInformationData>(), HasNobelPrize = true, 
                IsAlive = false, Name = "John Doe", Nation = "se"};
            BookInformationData bookInformation = new BookInformationData(){ID = 1, 
                Title = "Sample Title", 
                Description = "Sample Description", Category = Category.Horses, Position = "A1", 
                PublishingYear = 1111, ISBN = "123-456-789", Authors = new List<Author>(), Books = new List<Book>()};
            LoanData loan = new LoanData(){ID=1, 
                Start = DateTime.Now, End = DateTime.Now.AddMonths(3), IsReturned  = false, Books = new List<Book>()};
            CustomerData loanTaker = new CustomerData(){ID = 1, 
                Name = "Some Loner", MembershipNumber = "12", Contact = "somewhere@client.com", Loans = new List<LoanData>() };
            #endregion
            #region Mapping
            book.BookInformation = bookInformation;
            bookInformation.Books.Add(book);
            bookInformation.Authors.Add(author);
            author.BooksWritten.Add(bookInformation);
            book.Loans.Add(loan);
            loan.Books.Add(book);
            loan.Customer = loanTaker;
            loanTaker.Loans.Add(loan);
            #endregion
            #region Add to database
            context.LoanTakers.AddOrUpdate(loanTaker);
      /*      context.Database.ExecuteSqlCommand("Book_Insert @condition, @isrented, @BookInformationId", 
                new SqlParameter {ParameterName = "@condition", Value = book.Condition},
                new SqlParameter { ParameterName = "@isrented", Value = book.IsRented },
                new SqlParameter { ParameterName = "@BookInformationId", Value = book.BookInformation.ID });*/
            #endregion
        }
    }
}
