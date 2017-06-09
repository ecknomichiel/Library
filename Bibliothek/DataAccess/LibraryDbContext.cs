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
        public DbSet<BookData> Books { get; set; }
        public DbSet<BookInformationData> BookInformations { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<LoanData> Loans { get; set; }
        public DbSet<CustomerData> LoanTakers { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Book>().MapToStoredProcedures();
        } 
    }
}