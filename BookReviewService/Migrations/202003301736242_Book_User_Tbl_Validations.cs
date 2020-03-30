namespace BookReviewService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book_User_Tbl_Validations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Publisher", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "PublishedYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "OverrallRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserType", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserPassword", c => c.String());
            AlterColumn("dbo.Users", "UserType", c => c.String());
            AlterColumn("dbo.Users", "UserEmail", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Books", "OverrallRating", c => c.String());
            AlterColumn("dbo.Books", "PublishedYear", c => c.String());
            AlterColumn("dbo.Books", "Publisher", c => c.String());
            AlterColumn("dbo.Books", "Description", c => c.String());
            AlterColumn("dbo.Books", "Category", c => c.String());
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "BookName", c => c.String());
        }
    }
}
