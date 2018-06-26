namespace ScheduleUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedSubmittedProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Submitted", c => c.DateTime());
            DropColumn("dbo.Events", "SubmittedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "SubmittedOn", c => c.DateTime());
            DropColumn("dbo.Events", "Submitted");
        }
    }
}
