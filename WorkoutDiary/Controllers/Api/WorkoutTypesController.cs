using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WorkoutDiary.Models;

namespace WorkoutDiary.Controllers.Api
{
    public class WorkoutTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public WorkoutTypesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: WorkoutTypes
        public IEnumerable<WorkoutType> Get()
        {
            var workoutTypesQuery = _context.WorkoutTypes;

            return workoutTypesQuery.ToList();
        }

        public IHttpActionResult Delete(int id)
        {
            var WorkoutTypeInDb = _context.WorkoutTypes.SingleOrDefault(w => w.Id == id);
            if (WorkoutTypeInDb==null)
            {
                return NotFound();
            }
            _context.WorkoutTypes.Remove(WorkoutTypeInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}