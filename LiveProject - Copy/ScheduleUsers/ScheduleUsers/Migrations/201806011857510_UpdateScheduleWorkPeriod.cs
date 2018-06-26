namespace ScheduleUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateScheduleWorkPeriod : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Schedules", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.WorkPeriods", name: "Schedule_Id", newName: "ScheduleId");
            RenameIndex(table: "dbo.Schedules", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.WorkPeriods", name: "IX_Schedule_Id", newName: "IX_ScheduleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WorkPeriods", name: "IX_ScheduleId", newName: "IX_Schedule_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.WorkPeriods", name: "ScheduleId", newName: "Schedule_Id");
            RenameColumn(table: "dbo.Schedules", name: "UserId", newName: "User_Id");
        }
    }
}
