namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReplyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        RepliedAt = c.DateTime(nullable: false),
                        FeedbackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feedbacks", t => t.FeedbackId, cascadeDelete: true)
                .Index(t => t.FeedbackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "FeedbackId", "dbo.Feedbacks");
            DropIndex("dbo.Replies", new[] { "FeedbackId" });
            DropTable("dbo.Replies");
        }
    }
}
