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
    [Authorize(Roles = "CanManageWorkoutTypes")]
    public class WorkoutTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkoutTypes
        public ActionResult Index()
        {
            return View(db.WorkoutTypes.ToList());
        }

        // GET: WorkoutTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutType workoutType = db.WorkoutTypes.Find(id);
            if (workoutType == null)
            {
                return HttpNotFound();
            }
            return View(workoutType);
        }

        // GET: WorkoutTypes/Create
        public ActionResult Create()
        {
            var viewModel = new WorkoutTypeViewModel();
            return View("WorkoutTypeForm", viewModel);
        }

        // POST: WorkoutTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WorkoutType workoutType)
        {
            if (ModelState.IsValid)
            {
                db.WorkoutTypes.Add(workoutType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workoutType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(WorkoutType workoutType)
        {
            //var viewModel = new WorkoutTypeViewModel {
                
            //};
            //if (!ModelState.IsValid)
            //{
            //    return View("WorkoutTypeForm", viewModel);
            //}
            if (workoutType.Id==0)
            {

                // Workout counter for Heatmap colors
                var workoutTypes = db.WorkoutTypes;
                int numberOfWorkoutTypes = db.WorkoutTypes.Count();
                List<int> workoutTypeCounters = new List<int>();
                foreach (var wt in workoutTypes)
                {
                    workoutTypeCounters.Add(wt.WorkoutTypeCounter);
                }
                var missingCounters = Enumerable.Range(1, numberOfWorkoutTypes).Except(workoutTypeCounters);

                if (missingCounters.Count()==0)
                {
                    workoutType.WorkoutTypeCounter = numberOfWorkoutTypes + 1;
                }
                else
                {
                    workoutType.WorkoutTypeCounter = missingCounters.First();
                }

                db.WorkoutTypes.Add(workoutType);
            }
            else
            {
                var workoutTypeInDb = db.WorkoutTypes.Single(w => w.Id == workoutType.Id);
                workoutTypeInDb.Name = workoutType.Name;
                workoutTypeInDb.IconString = workoutType.IconString;
                workoutTypeInDb.hasDistance = workoutType.hasDistance;
                workoutTypeInDb.hasDuration = workoutType.hasDuration;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "WorkoutTypes");
        }


        // GET: WorkoutTypes/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutType workoutType = db.WorkoutTypes.SingleOrDefault(w=>w.Id==id);
            if (workoutType == null)
            {
                return HttpNotFound();
            }
            var viewModel = new WorkoutTypeViewModel {
                Id = id,
                WorkoutType = workoutType
            };
            return View("WorkoutTypeForm", viewModel);
            //return View(workoutType);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        // POST: WorkoutTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WorkoutType workoutType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workoutType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workoutType);
        }



        // GET: WorkoutTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutType workoutType = db.WorkoutTypes.Find(id);
            if (workoutType == null)
            {
                return HttpNotFound();
            }
            return View(workoutType);
        }

        // POST: WorkoutTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkoutType workoutType = db.WorkoutTypes.Find(id);
            db.WorkoutTypes.Remove(workoutType);
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
