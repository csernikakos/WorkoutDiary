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
        [Display(Name = "Workout Type Name")]
        public string Name { get; set; }

        public int WorkoutTypeCounter { get; set; }

        [Display(Name = "Workout Icon")]
        public string IconString { get; set; }

        public bool hasDistance { get; set; }
        public bool hasDuration { get; set; }
    }
}