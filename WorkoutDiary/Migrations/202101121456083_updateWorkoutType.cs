namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWorkoutType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutTypes", "WorkoutTypeCounter", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkoutTypes", "WorkoutTypeCounter");
        }
    }
}
