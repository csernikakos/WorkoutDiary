using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WorkoutDiary.Models
{
    public class Workout
    {
        public int Id { get; set; }
        
        public WorkoutType WorkoutType { get; set; }

        [Display(Name ="Workout tpye")]
        public int WorkoutTypeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }
            
    }
}