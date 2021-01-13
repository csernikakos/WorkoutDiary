namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWorkoutType3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutTypes", "hasDistance", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkoutTypes", "hasDuration", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkoutTypes", "hasDuration");
            DropColumn("dbo.WorkoutTypes", "hasDistance");
        }
    }
}
