namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "Timestamp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "Timestamp");
        }
    }
}
