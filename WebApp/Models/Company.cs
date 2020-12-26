using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Company
    {
        private ICollection<Assignment> _assignments;

        public Company()
        {
            _assignments = new List<Assignment>();
        }

        public int CompanyID { get; set; }
        public string Company_Name { get; set; }

        public virtual ICollection<Assignment> Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }
    }
}