using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Assignment
    {
        private ICollection<Programmer> _programmers;

        public Assignment()
        {
            _programmers = new List<Programmer>();
        }

        public int AssignmentID { get; set; }
        public string Job { get; set; }
        public DateTime DeadLineDate { get; set; }
        //public virtual Company Company_Name { get; set; }
        //public virtual Department Department_Type { get; set; }

        public virtual ICollection<Programmer> Programmers
        {
            get { return _programmers; }
            set { _programmers = value; }
        }
    }
}