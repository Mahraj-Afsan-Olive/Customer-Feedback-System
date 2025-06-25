namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDBwithFeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Message = c.String(),
                        AttachmentPath = c.String(),
                        SubmittedAt = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
