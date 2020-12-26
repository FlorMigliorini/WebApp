using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Department
    {
        private ICollection<Assignment> _assignments;
        public Department()
        {
            _assignments = new List<Assignment>();
        }

        public int DepartmentID { get; set; }
        public string Department_Type { get; set; }

        public virtual ICollection<Assignment> Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }
    }
}