namespace WebApp.Migrations
{
    using WebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Models.AContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApp.Models.AContext";
        }

        protected override void Seed(WebApp.Models.AContext context)
        {
            var departments = new List<Department>
            {
                new Department{DepartmentID=9090, Department_Type="Back-end"},
                new Department{DepartmentID=9085, Department_Type="Front-end"},
            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var companies = new List<Company>
{
                new Company(){CompanyID=1050,Company_Name="Google", 
                Assignments = context.Assignments.Where(s => s.Job.Contains("React")).ToList()},
                new Company{CompanyID=4022,Company_Name="Hubspot",
                Assignments = context.Assignments.Where(s => s.Job.Contains("NodeApp ")).ToList()},
                new Company{CompanyID=4041,Company_Name="Accenture",},
                new Company{CompanyID=1045,Company_Name="Delloite",},
                new Company{CompanyID=1059,Company_Name="Tik Tok",},
                new Company{CompanyID=4025,Company_Name="OpenMind",},

                

        };
            companies.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();

            var programmers = new List<Programmer>
            {
                new Programmer(){ProgrammerID=1, Name="Ciara", Surname="Kelly",
                Assignments = context.Assignments.Where(s => s.Programmers.ToString().Contains("Name")).ToList()},
                new Programmer(){ProgrammerID=2, Name="Eamon", Surname="Byrne"},
                new Programmer(){ProgrammerID=3, Name="Brian", Surname="Walsh"},
                new Programmer(){ProgrammerID=4, Name="Aoife", Surname="O'Connor"},
                new Programmer(){ProgrammerID=5, Name="Fiona", Surname="McCarthy"}
            };

            programmers.ForEach(s => context.Programmers.AddOrUpdate(s));
            context.SaveChanges();

            var assignments = new List<Assignment> {
                new Assignment(){AssignmentID = 1, Job = "React",DeadLineDate = DateTime.Parse("2021-01-05")},
                new Assignment(){AssignmentID = 2, Job = "Sprig FrameWork",DeadLineDate = DateTime.Parse("2022-01-10")},
                new Assignment(){AssignmentID = 3, Job = "NodeApp",DeadLineDate = DateTime.Parse("2021-03-11")}

             
            };

            assignments.ForEach(s => context.Assignments.AddOrUpdate(s));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
