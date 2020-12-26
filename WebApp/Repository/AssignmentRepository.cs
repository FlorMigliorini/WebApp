using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Interface;
using WebApp.Models;

namespace WebApp.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        public List<Assignment> assignments = new List<Assignment>()
        {
            new Assignment(){AssignmentID = 1, Job = "React",DeadLineDate = DateTime.Parse("2021-01-05")},
            new Assignment(){AssignmentID = 2, Job = "Sprig FrameWork",DeadLineDate = DateTime.Parse("2022-01-10")},
            new Assignment(){AssignmentID = 3, Job = "NodeApp",DeadLineDate = DateTime.Parse("2021-03-11")}
        };

        public bool AddNewAssignment(Assignment assignment)
        {
            assignments.Add(assignment);
            return true;
        }

        public List<Assignment> GetAllAssignments()
        {
            return assignments;
        }
        public Assignment GetAssignment(int id)
        {
            var assignment = assignments.FirstOrDefault(x => x.AssignmentID == id);
            return assignment;
        }

        public bool Remove(int id)
        {
            var assignment = GetAssignment(id);
            if(assignment == null)
            {
                return false;
            }
            assignments.Remove(assignment);
            return true;
        }
        public List<Assignment>UpdateAssignment(int id, Assignment assignment)
        {
            if (this.Remove(id))
            {
                this.AddNewAssignment(assignment);
                return assignments;
            }
            return assignments;
        }
    }
}