namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTimeInterval : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workouts", "TimeInterval", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "TimeInterval", c => c.DateTime(nullable: false));
        }
    }
}
