using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WorkoutDiary.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Workout> Workouts{ get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }


        public ApplicationDbContext()
            : base("WorkoutDiaryDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}