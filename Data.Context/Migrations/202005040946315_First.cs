namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Pseudo = c.String(),
                        Gender = c.Int(nullable: false),
                        Chance = c.Int(nullable: false),
                        Alive = c.Boolean(nullable: false),
                        IdCorporation = c.Int(),
                        IdGrade = c.Int(),
                        IdEthnic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCharactere)
                .ForeignKey("dbo.Corporations", t => t.IdCorporation)
                .ForeignKey("dbo.Ethnics", t => t.IdEthnic, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.IdGrade)
                .Index(t => t.IdCorporation)
                .Index(t => t.IdGrade)
                .Index(t => t.IdEthnic);
            
            CreateTable(
                "dbo.Corporations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsGang = c.Boolean(nullable: false),
                        Color = c.String(),
                        Grade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.Grade_Id)
                .Index(t => t.Grade_Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Quantity = c.Int(nullable: false),
                        Ressource = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ethnics",
                c => new
                    {
                        IdEthnic = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdEthnic);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Factor = c.Int(nullable: false),
                        IdFeature = c.Int(nullable: false),
                        IdSpecialAbility = c.Int(),
                        SpecialAbility_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.IdFeature, cascadeDelete: true)
                .ForeignKey("dbo.SpecialAbilities", t => t.SpecialAbility_Id)
                .Index(t => t.IdFeature)
                .Index(t => t.SpecialAbility_Id);
            
            CreateTable(
                "dbo.SpecialAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Protections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "SpecialAbility_Id", "dbo.SpecialAbilities");
            DropForeignKey("dbo.Skills", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.Characters", "IdGrade", "dbo.Grades");
            DropForeignKey("dbo.Characters", "IdEthnic", "dbo.Ethnics");
            DropForeignKey("dbo.Characters", "IdCorporation", "dbo.Corporations");
            DropForeignKey("dbo.Corporations", "Grade_Id", "dbo.Grades");
            DropIndex("dbo.Skills", new[] { "SpecialAbility_Id" });
            DropIndex("dbo.Skills", new[] { "IdFeature" });
            DropIndex("dbo.Corporations", new[] { "Grade_Id" });
            DropIndex("dbo.Characters", new[] { "IdEthnic" });
            DropIndex("dbo.Characters", new[] { "IdGrade" });
            DropIndex("dbo.Characters", new[] { "IdCorporation" });
            DropTable("dbo.Protections");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.Skills");
            DropTable("dbo.Features");
            DropTable("dbo.Ethnics");
            DropTable("dbo.Grades");
            DropTable("dbo.Corporations");
            DropTable("dbo.Characters");
        }
    }
}
