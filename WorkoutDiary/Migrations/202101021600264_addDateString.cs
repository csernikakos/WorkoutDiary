namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "DateInString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "DateInString");
        }
    }
}
