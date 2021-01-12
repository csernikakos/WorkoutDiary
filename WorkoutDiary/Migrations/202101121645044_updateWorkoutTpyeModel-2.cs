namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWorkoutTpyeModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutTypes", "IconString", c => c.String());
            DropColumn("dbo.Workouts", "IconString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "IconString", c => c.String());
            DropColumn("dbo.WorkoutTypes", "IconString");
        }
    }
}
