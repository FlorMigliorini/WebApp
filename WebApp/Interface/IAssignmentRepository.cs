using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Interface
{
    public interface IAssignmentRepository 
    {
        //CRUD
        //Create retrive Update Delete

        List<Assignment> GetAllAssignments();

        Assignment GetAssignment(int id);
        bool AddNewAssignment(Assignment assignment);
        bool Remove(int id);

        List<Assignment> UpdateAssignment(int id, Assignment assignment);
    }
}