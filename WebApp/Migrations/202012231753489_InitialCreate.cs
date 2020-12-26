namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        Job = c.String(),
                        DeadLineDate = c.DateTime(nullable: false),
                        Company_CompanyID = c.Int(),
                        Department_DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.AssignmentID)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID)
                .Index(t => t.Company_CompanyID)
                .Index(t => t.Department_DepartmentID);
            
            CreateTable(
                "dbo.Programmers",
                c => new
                    {
                        ProgrammerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.ProgrammerID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Department_Type = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.ProgrammerAssignments",
                c => new
                    {
                        Programmer_ProgrammerID = c.Int(nullable: false),
                        Assignment_AssignmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Programmer_ProgrammerID, t.Assignment_AssignmentID })
                .ForeignKey("dbo.Programmers", t => t.Programmer_ProgrammerID, cascadeDelete: true)
                .ForeignKey("dbo.Assignments", t => t.Assignment_AssignmentID, cascadeDelete: true)
                .Index(t => t.Programmer_ProgrammerID)
                .Index(t => t.Assignment_AssignmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Assignments", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.ProgrammerAssignments", "Assignment_AssignmentID", "dbo.Assignments");
            DropForeignKey("dbo.ProgrammerAssignments", "Programmer_ProgrammerID", "dbo.Programmers");
            DropIndex("dbo.ProgrammerAssignments", new[] { "Assignment_AssignmentID" });
            DropIndex("dbo.ProgrammerAssignments", new[] { "Programmer_ProgrammerID" });
            DropIndex("dbo.Assignments", new[] { "Department_DepartmentID" });
            DropIndex("dbo.Assignments", new[] { "Company_CompanyID" });
            DropTable("dbo.ProgrammerAssignments");
            DropTable("dbo.Departments");
            DropTable("dbo.Companies");
            DropTable("dbo.Programmers");
            DropTable("dbo.Assignments");
        }
    }
}
