namespace w1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 40),
                        E1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        E2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        E3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WrittenExam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Discript1 = c.String(),
                        Discript2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropTable("dbo.Suggestions");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
        }
    }
}
