using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Programmer
    {
        private ICollection<Assignment> _assignments;

        public Programmer()
        {
            _assignments = new List<Assignment>();
        }

        public int ProgrammerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Assignment> Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }
    }
}