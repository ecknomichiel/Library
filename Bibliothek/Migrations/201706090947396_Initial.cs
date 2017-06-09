namespace Bibliothek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nation = c.String(maxLength: 2),
                        IsAlive = c.Boolean(nullable: false),
                        HasNobelPrize = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ISBN = c.String(),
                        Category = c.Int(nullable: false),
                        Description = c.String(),
                        Position = c.String(),
                        PublishingYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Condition = c.String(nullable: false),
                        IsRented = c.Boolean(nullable: false),
                        BookInformation_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookInformations", t => t.BookInformation_ID)
                .Index(t => t.BookInformation_ID);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        LoanTaker_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoanTakers", t => t.LoanTaker_ID)
                .Index(t => t.LoanTaker_ID);
            
            CreateTable(
                "dbo.LoanTakers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MembershipNumber = c.String(),
                        Name = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookInformationAuthors",
                c => new
                    {
                        BookInformation_ID = c.Int(nullable: false),
                        Author_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookInformation_ID, t.Author_ID })
                .ForeignKey("dbo.BookInformations", t => t.BookInformation_ID, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.BookInformation_ID)
                .Index(t => t.Author_ID);
            
            CreateTable(
                "dbo.LoanBooks",
                c => new
                    {
                        Loan_ID = c.Int(nullable: false),
                        Book_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Loan_ID, t.Book_ID })
                .ForeignKey("dbo.Loans", t => t.Loan_ID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_ID, cascadeDelete: true)
                .Index(t => t.Loan_ID)
                .Index(t => t.Book_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanTaker_ID", "dbo.LoanTakers");
            DropForeignKey("dbo.LoanBooks", "Book_ID", "dbo.Books");
            DropForeignKey("dbo.LoanBooks", "Loan_ID", "dbo.Loans");
            DropForeignKey("dbo.Books", "BookInformation_ID", "dbo.BookInformations");
            DropForeignKey("dbo.BookInformationAuthors", "Author_ID", "dbo.Authors");
            DropForeignKey("dbo.BookInformationAuthors", "BookInformation_ID", "dbo.BookInformations");
            DropIndex("dbo.LoanBooks", new[] { "Book_ID" });
            DropIndex("dbo.LoanBooks", new[] { "Loan_ID" });
            DropIndex("dbo.BookInformationAuthors", new[] { "Author_ID" });
            DropIndex("dbo.BookInformationAuthors", new[] { "BookInformation_ID" });
            DropIndex("dbo.Loans", new[] { "LoanTaker_ID" });
            DropIndex("dbo.Books", new[] { "BookInformation_ID" });
            DropTable("dbo.LoanBooks");
            DropTable("dbo.BookInformationAuthors");
            DropTable("dbo.LoanTakers");
            DropTable("dbo.Loans");
            DropTable("dbo.Books");
            DropTable("dbo.BookInformations");
            DropTable("dbo.Authors");
        }
    }
}
