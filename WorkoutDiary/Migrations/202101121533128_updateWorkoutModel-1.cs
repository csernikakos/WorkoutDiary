namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWorkoutModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "IconString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "IconString");
        }
    }
}
