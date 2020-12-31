using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WorkoutDiary.Models
{
    public class WorkoutType
    {
        public int Id { get; set; }

        
        [StringLength(255)]
        [Display(Name = "Workout")]
        public string Name { get; set; }
    }
}