namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        WorkoutType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.WorkoutTypes", t => t.WorkoutType_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.WorkoutType_Id);
            
            CreateTable(
                "dbo.WorkoutTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes");
            DropForeignKey("dbo.Workouts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Workouts", new[] { "WorkoutType_Id" });
            DropIndex("dbo.Workouts", new[] { "User_Id" });
            DropTable("dbo.WorkoutTypes");
            DropTable("dbo.Workouts");
        }
    }
}
