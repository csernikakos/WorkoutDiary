namespace WorkoutDiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Workouts", name: "WorkoutType_Id", newName: "WorkoutTypeId");
            RenameIndex(table: "dbo.Workouts", name: "IX_WorkoutType_Id", newName: "IX_WorkoutTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Workouts", name: "IX_WorkoutTypeId", newName: "IX_WorkoutType_Id");
            RenameColumn(table: "dbo.Workouts", name: "WorkoutTypeId", newName: "WorkoutType_Id");
        }
    }
}
