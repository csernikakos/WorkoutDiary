using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;
using WorkoutDiary.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace WorkoutDiary.Controllers.Api
{
    public class WorkoutsController : ApiController
    {
        private ApplicationDbContext _context;
        public WorkoutsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/Workouts
        public IEnumerable<Workout> Get()
        {
            var currentUserId = User.Identity.GetUserId();
            var workoutsQuery = _context.Workouts.Include(m => m.WorkoutType).Include(w=>w.User).Where(u=>u.User.Id==currentUserId);

            return workoutsQuery.ToList();

            //return new string[] { "value1", "value2" };
        }

        // GET: api/Workouts/5
       
        public IHttpActionResult Get(int id)
        {
            var workout = _context.Workouts.Include(w => w.WorkoutType).Include(u => u.User).SingleOrDefault(c=>c.Id==id);
            if (workout==null)
            {
                return NotFound();
            }
            return Ok(workout);
        }

        // POST: api/Workouts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Workouts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Workouts/5
        public void Delete(int id)
        {
        }
    }
}
