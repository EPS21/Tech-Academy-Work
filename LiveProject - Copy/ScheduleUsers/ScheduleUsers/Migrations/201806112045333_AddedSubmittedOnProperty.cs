namespace ScheduleUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubmittedOnProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "SubmittedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "SubmittedOn");
        }
    }
}
