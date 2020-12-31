using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutDiary.Models;

namespace WorkoutDiary.ViewModels
{
    public class WorkoutViewModel
    {
        public IEnumerable<WorkoutType> WorkoutTypes { get; set; }

        
        public int WorkoutTypeId { get; set; }

        public DateTime WorkoutDate { get; set; }

        public Workout Workout { get; set; }

        public string CurrentUserId { get; set; }

        //public WorkoutViewModel()
        //{

        //}

        //public WorkoutViewModel(string userID)
        //{
        //    CurrentUserId = userID;
        //}

    }
}