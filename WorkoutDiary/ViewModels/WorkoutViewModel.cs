using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkoutDiary.Models;

namespace WorkoutDiary.ViewModels
{
    public class WorkoutViewModel
    {
        public int? Id { get; set; }

        public IEnumerable<WorkoutType> WorkoutTypes { get; set; }

        public Workout Workout { get; set; }

        public string CurrentUserId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Workout";
                }
                else
                {
                    return "New Workout";
                }
            }
        }


        public WorkoutViewModel()
        {
            Id = 0;
        }

        public WorkoutViewModel(Workout workout)
        {
            Workout = workout;
        }

    }
}