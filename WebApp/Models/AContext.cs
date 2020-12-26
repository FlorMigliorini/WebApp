using WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class AContext : DbContext
    {
        public AContext() : base("name=AContext") { }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Programmer> Programmers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}