using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bibliothek.Models;
using System.Data.Entity;

namespace Bibliothek.DataAccess
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() : base("LibraryDB") { }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookInformation> BookInformations { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanTaker> LoanTakers { get; set; }
        /*
        protected override OnModelCreating(DbModelBuilder modelBuilder)
        {
            //One to many
            modelBuilder.Entity<Book>()
                .HasRequired<BookInformation>(book => book.BookInformation)
                .WithMany(bi => bi.Books)
                //.HasForeignKey(book => book.BookInformationID)
                ;
            //Many to many
            modelBuilder.Entity<Book>()
                .HasMany(book => book.Loans)
                .WithMany(loan => loan.Books)
                .Map(booksLoans => {
                    booksLoans.MapLeftKey("BookRefId");
                    booksLoans.MapRightKey("LoanRefId");
                    booksLoans.ToTable("BookLoan");
                });
        } */
    }
}