namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntityValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "CustomerName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Feedbacks", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Feedbacks", "Message", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Feedbacks", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Replies", "Message", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Replies", "Message", c => c.String());
            AlterColumn("dbo.Feedbacks", "Status", c => c.String());
            AlterColumn("dbo.Feedbacks", "Message", c => c.String());
            AlterColumn("dbo.Feedbacks", "Email", c => c.String());
            AlterColumn("dbo.Feedbacks", "CustomerName", c => c.String());
        }
    }
}
