namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWorkoutType2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkoutTypes", "WorkoutTypeCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkoutTypes", "WorkoutTypeCounter", c => c.Int());
        }
    }
}
