namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateWorkoutnewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "Description", c => c.String());
            AddColumn("dbo.Workouts", "TimeInterval", c => c.DateTime(nullable: false));
            AddColumn("dbo.Workouts", "Distance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "Distance");
            DropColumn("dbo.Workouts", "TimeInterval");
            DropColumn("dbo.Workouts", "Description");
        }
    }
}
