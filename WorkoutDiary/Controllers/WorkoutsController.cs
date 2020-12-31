﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
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
            //return View(db.Workouts.ToList());
            var workouts = db.Workouts.Include(c => c.WorkoutType).Include(u => u.User);
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
            //ApplicationUser currentUser = db.Users.FirstOrDefault(u => u.Id == currentUserID);
            var workoutTypes = db.WorkoutTypes.ToList();

            var viewModel = new WorkoutViewModel
            {
                CurrentUserId = currentUserID,
                WorkoutTypes = workoutTypes
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
                db.Workouts.Add(workout);
            }
            else
            {
                var workoutInDb = db.Workouts.Single(w => w.Id == workout.Id);

                workoutInDb.Date = workout.Date;
                workoutInDb.User = workout.User;
                workoutInDb.WorkoutTypeId = workout.WorkoutTypeId;
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
        public ActionResult Edit(int? id)
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

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workout);
        }

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
