namespace ScheduleUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedIdentityModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeOffViewModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TimeOffViewModels", new[] { "User_Id" });
            DropTable("dbo.TimeOffViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeOffViewModels",
                c => new
                    {
                        EventID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        Note = c.String(),
                        Title = c.String(),
                        RequestLength = c.Time(precision: 7),
                        SubmittedOn = c.DateTime(nullable: false),
                        ActiveSchedule = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateIndex("dbo.TimeOffViewModels", "User_Id");
            AddForeignKey("dbo.TimeOffViewModels", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
