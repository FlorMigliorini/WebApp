using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Interface;
using WebApp.Models;

namespace WebApp.Controllers.WebAPI
{
    public class AssignmentsAPIController : ApiController
    {
       
        private AContext db = new AContext();

        //private IAssignmentRepository assignments;

        //public AssignmentsAPIController(IAssignmentRepository _assignment)
        //{
        //    this.assignments = _assignment;
        //}

        public List<Assignment> assignments = new List<Assignment>
        {
            new Assignment(){AssignmentID = 1, Job = "React",DeadLineDate = DateTime.Parse("2021-01-05")},
            new Assignment(){AssignmentID = 2, Job = "Sprig FrameWork",DeadLineDate = DateTime.Parse("2022-01-10")},
            new Assignment(){AssignmentID = 3, Job = "NodeApp",DeadLineDate = DateTime.Parse("2021-03-11")}

        };

        // GET: api/AssignmentsAPI
        //public IQueryable<Assignment> GetAssignments()
        public IEnumerable<Assignment> Get()
        //public IEnumerable<string> Get()
        {
            return assignments;
            //return db.Assignments;
            // return new string[] { "value1", "value2" };
            //return assignments.GetAllAssignments();
        }

        // GET: api/AssignmentsAPI/5
        [ResponseType(typeof(Assignment))]
        public IHttpActionResult GetAssignment(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // PUT: api/AssignmentsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssignment(int id, Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.AssignmentID)
            {
                return BadRequest();
            }

            db.Entry(assignment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AssignmentsAPI
        [ResponseType(typeof(Assignment))]
        public IHttpActionResult PostAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assignments.Add(assignment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assignment.AssignmentID }, assignment);
        }

        // DELETE: api/AssignmentsAPI/5
        [ResponseType(typeof(Assignment))]
        public IHttpActionResult DeleteAssignment(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }

            db.Assignments.Remove(assignment);
            db.SaveChanges();

            return Ok(assignment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignmentExists(int id)
        {
            return db.Assignments.Count(e => e.AssignmentID == id) > 0;
        }
    }
}