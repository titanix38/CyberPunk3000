namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                        IdCity = c.Int(nullable: false),
                        Safety = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.IdCity, cascadeDelete: true)
                .Index(t => t.IdCity);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Pseudo = c.String(),
                        IdGender = c.Int(nullable: false),
                        Chance = c.Int(nullable: false),
                        Alive = c.Boolean(nullable: false),
                        IdCorporation = c.Int(),
                        IdGrade = c.Int(),
                        IdEthnic = c.Int(nullable: false),
                        IdArea = c.Int(),
                    })
                .PrimaryKey(t => t.IdCharactere)
                .ForeignKey("dbo.Areas", t => t.IdArea)
                .ForeignKey("dbo.Corporations", t => t.IdCorporation)
                .ForeignKey("dbo.Ethnics", t => t.IdEthnic, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.IdGender, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.IdGrade)
                .Index(t => t.IdGender)
                .Index(t => t.IdCorporation)
                .Index(t => t.IdGrade)
                .Index(t => t.IdEthnic)
                .Index(t => t.IdArea);
            
            CreateTable(
                "dbo.Corporations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                        IsGang = c.Boolean(nullable: false),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ethnics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Quantity = c.Int(nullable: false),
                        Resource = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                        Price = c.Int(nullable: false),
                        Empathy = c.Int(nullable: false),
                        Description = c.String(),
                        SecondEffect = c.String(),
                        ChanceToDie = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChanceToBeMad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdFeature = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.IdFeature)
                .Index(t => t.IdFeature);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                        Factor = c.Int(nullable: false),
                        IdFeature = c.Int(nullable: false),
                        IdSpecialAbility = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.IdFeature, cascadeDelete: true)
                .ForeignKey("dbo.SpecialAbilities", t => t.IdSpecialAbility)
                .Index(t => t.IdFeature)
                .Index(t => t.IdSpecialAbility);
            
            CreateTable(
                "dbo.SpecialAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Protections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "IdSpecialAbility", "dbo.SpecialAbilities");
            DropForeignKey("dbo.Skills", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.Patents", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.Areas", "IdCity", "dbo.Cities");
            DropForeignKey("dbo.Characters", "IdGrade", "dbo.Grades");
            DropForeignKey("dbo.Characters", "IdGender", "dbo.Genders");
            DropForeignKey("dbo.Characters", "IdEthnic", "dbo.Ethnics");
            DropForeignKey("dbo.Characters", "IdCorporation", "dbo.Corporations");
            DropForeignKey("dbo.Characters", "IdArea", "dbo.Areas");
            DropIndex("dbo.Skills", new[] { "IdSpecialAbility" });
            DropIndex("dbo.Skills", new[] { "IdFeature" });
            DropIndex("dbo.Patents", new[] { "IdFeature" });
            DropIndex("dbo.Characters", new[] { "IdArea" });
            DropIndex("dbo.Characters", new[] { "IdEthnic" });
            DropIndex("dbo.Characters", new[] { "IdGrade" });
            DropIndex("dbo.Characters", new[] { "IdCorporation" });
            DropIndex("dbo.Characters", new[] { "IdGender" });
            DropIndex("dbo.Areas", new[] { "IdCity" });
            DropTable("dbo.Protections");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.Skills");
            DropTable("dbo.Patents");
            DropTable("dbo.Features");
            DropTable("dbo.Cities");
            DropTable("dbo.Grades");
            DropTable("dbo.Genders");
            DropTable("dbo.Ethnics");
            DropTable("dbo.Corporations");
            DropTable("dbo.Characters");
            DropTable("dbo.Areas");
        }
    }
}
