namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updapdsa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkoutTypes", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkoutTypes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
