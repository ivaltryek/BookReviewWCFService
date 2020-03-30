namespace BookReviewService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book_User_Tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Author = c.String(),
                        Category = c.String(),
                        Description = c.String(),
                        Publisher = c.String(),
                        PublishedYear = c.String(),
                        OverrallRating = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserEmail = c.String(),
                        UserType = c.String(),
                        UserPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Books");
        }
    }
}
