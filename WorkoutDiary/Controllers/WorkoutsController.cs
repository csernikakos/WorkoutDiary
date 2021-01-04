using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkoutDiary.Models;
using WorkoutDiary.ViewModels;

namespace WorkoutDiary.Controllers
{
    public class WorkoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workouts
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var workouts = db.Workouts.Include(c => c.WorkoutType).Include(u => u.User);
            List<DataPoint> dataPoints = new List<DataPoint>();

            var workoutTypes = db.WorkoutTypes;
            foreach(var workoutType in workoutTypes)
            {
                var workoutTypeCount = db.Workouts.Where(w => w.WorkoutTypeId == workoutType.Id && w.User.Id == currentUserId).Count();
                if (workoutTypeCount!=0)
                {
                    var dataPoint = new DataPoint(workoutTypeCount, workoutType.Name);
                    dataPoints.Add(dataPoint);
                }                
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View(workouts);
        }

        // GET: Workouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // GET: Workouts/Create
        public ActionResult Create()
        {

            var currentUserID = User.Identity.GetUserId();
            var workoutTypes = db.WorkoutTypes.ToList();

            var viewModel = new WorkoutViewModel
            {
                CurrentUserId = currentUserID,
                WorkoutTypes = workoutTypes,
                Workout = new Workout
                {
                    Date = DateTime.Now
                }
            };
            
            return View("WorkoutForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Workout workout)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new WorkoutViewModel
                {
                    CurrentUserId = User.Identity.GetUserId(),
                    WorkoutTypes = db.WorkoutTypes.ToList()
                };

                return View("WorkoutForm", viewModel);

            }
            if (workout.Id == 0)
            {
                var currentUserID = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(u => u.Id == currentUserID);
                workout.User = currentUser;
                workout.DateInString = workout.Date.ToShortDateString();
                db.Workouts.Add(workout);
            }
            else
            {
                var workoutInDb = db.Workouts.Single(w => w.Id == workout.Id);
                workoutInDb.Date = workout.Date;
                workoutInDb.User = workout.User;
                workoutInDb.WorkoutTypeId = workout.WorkoutTypeId;
                workoutInDb.DateInString = workout.Date.ToShortDateString();
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Workouts");
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Date")] Workout workout)
        //{
            
        //    var viewModel = new WorkoutViewModel
        //    {
        //        CurrentUserId = User.Identity.GetUserId(),
        //        WorkoutTypes = db.WorkoutTypes.ToList()
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        var currentUserID = User.Identity.GetUserId();
        //        workout.User = db.Users.FirstOrDefault(u => u.Id == currentUserID);


        //        // workout.WorkoutType = db.WorkoutTypes.FirstOrDefault(w=>w.Id==workout.WorkoutTypeId);

        //        workout.WorkoutType = db.WorkoutTypes.FirstOrDefault(w => w.Id == workout.WorkoutTypeId);

        //        db.Workouts.Add(workout);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
                
        //        var currentUserID = User.Identity.GetUserId();
        //        workout.User = db.Users.FirstOrDefault(u => u.Id == currentUserID);
        //        //workout.Date = DateTime.Now;
        //        //workout.WorkoutType = db.WorkoutTypes.FirstOrDefault(w => w.Id == 1);

        //        db.Workouts.Add(workout);
        //        db.SaveChanges();
        //        return View("Create", viewModel);
        //    }
        //   // return RedirectToAction("Index", "Workouts");
        //}

        // GET: Workouts/Edit/5
        public ActionResult Edit(int id)
        {
            var workout = db.Workouts.SingleOrDefault(w => w.Id == id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            var viewModel = new WorkoutViewModel
            {
                Id=id,
                Workout = workout,
                CurrentUserId = User.Identity.GetUserId(),
                WorkoutTypes = db.WorkoutTypes.ToList()
            };
            return View("WorkoutForm",viewModel);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Date")] Workout workout)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(workout).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(workout);
        //}

        // GET: Workouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
