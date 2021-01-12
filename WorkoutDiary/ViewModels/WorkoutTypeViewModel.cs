using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutDiary.Models;

namespace WorkoutDiary.ViewModels
{
    public class WorkoutTypeViewModel
    {
        public int? Id { get; set; }

        public WorkoutType WorkoutType;

        public string Title { 
            get {
                if (Id!=0)
                {
                    return "Edit Workout Type";
                }
                else
                {
                    return "New Workout Type";
                }
            } 
        }

        public WorkoutTypeViewModel()
        {
            Id = 0;
        }

        public WorkoutTypeViewModel(WorkoutType workoutType)
        {
            WorkoutType = workoutType;
        }
    }
}