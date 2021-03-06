namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resources : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                        IdCity = c.Int(nullable: false),
                        Safety = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.IdCity, cascadeDelete: true)
                .Index(t => t.IdCity);
            
            CreateTable(
                "dbo.CharacterArea",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdArea = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdArea })
                .ForeignKey("dbo.Areas", t => t.IdArea, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdArea);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        IdCharactere = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
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
                "dbo.CharacterFeature",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdFeature = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdFeature })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.IdFeature, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdFeature);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
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
                        Wording = c.String(),
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
                "dbo.CharacterSkill",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdSkill = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdSkill })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.IdSkill, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdSkill);
            
            CreateTable(
                "dbo.SpecialAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CharacterSpecialAbility",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdSpecial = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdSpecial })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.SpecialAbilities", t => t.IdSpecial, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdSpecial);
            
            CreateTable(
                "dbo.CharacterProperty",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdProperty = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdProperty })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Property", t => t.IdProperty, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdProperty);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        IdProperty = c.Guid(nullable: false, identity: true),
                        Style = c.String(),
                        Price = c.Double(nullable: false),
                        IdArea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProperty)
                .ForeignKey("dbo.Areas", t => t.IdArea, cascadeDelete: true)
                .Index(t => t.IdArea);
            
            CreateTable(
                "dbo.CharacterProtection",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdProtection = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdProtection })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Protections", t => t.IdProtection, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdProtection);
            
            CreateTable(
                "dbo.Protections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                        IdPart = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.IdPart, cascadeDelete: true)
                .Index(t => t.IdPart);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CharacterPseudo",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdPseudo = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdPseudo })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Pseudo", t => t.IdPseudo, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdPseudo);
            
            CreateTable(
                "dbo.Pseudo",
                c => new
                    {
                        IdPseudo = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IdPseudo);
            
            CreateTable(
                "dbo.CharacterResourceCharacter",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdOtherCharacter = c.Guid(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdOtherCharacter })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.IdOtherCharacter)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdOtherCharacter);
            
            CreateTable(
                "dbo.CharacterResourceCorporation",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdCorpo = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdCorpo })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Corporations", t => t.IdCorpo, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdCorpo);
            
            CreateTable(
                "dbo.Corporations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
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
                        Wording = c.String(),
                        Alias = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        IdGender = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.IdGender);
            
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
                        Wording = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "IdCity", "dbo.Cities");
            DropForeignKey("dbo.CharacterArea", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Characters", "IdGrade", "dbo.Grades");
            DropForeignKey("dbo.Characters", "IdGender", "dbo.Genders");
            DropForeignKey("dbo.Characters", "IdEthnic", "dbo.Ethnics");
            DropForeignKey("dbo.Characters", "IdCorporation", "dbo.Corporations");
            DropForeignKey("dbo.CharacterResourceCorporation", "IdCorpo", "dbo.Corporations");
            DropForeignKey("dbo.CharacterResourceCorporation", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterResourceCharacter", "OtherCharacters_IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.CharacterResourceCharacter", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterPseudo", "IdPseudo", "dbo.Pseudo");
            DropForeignKey("dbo.CharacterPseudo", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterProtection", "IdProtection", "dbo.Protections");
            DropForeignKey("dbo.Protections", "IdPart", "dbo.Parts");
            DropForeignKey("dbo.CharacterProtection", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterProperty", "IdProperty", "dbo.Property");
            DropForeignKey("dbo.Property", "IdArea", "dbo.Areas");
            DropForeignKey("dbo.CharacterProperty", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterFeature", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.Skills", "IdSpecialAbility", "dbo.SpecialAbilities");
            DropForeignKey("dbo.CharacterSpecialAbility", "IdSpecial", "dbo.SpecialAbilities");
            DropForeignKey("dbo.CharacterSpecialAbility", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Skills", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.CharacterSkill", "IdSkill", "dbo.Skills");
            DropForeignKey("dbo.CharacterSkill", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Patents", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.CharacterFeature", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Characters", "IdArea", "dbo.Areas");
            DropForeignKey("dbo.CharacterArea", "IdArea", "dbo.Areas");
            DropIndex("dbo.CharacterResourceCorporation", new[] { "IdCorpo" });
            DropIndex("dbo.CharacterResourceCorporation", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterResourceCharacter", new[] { "OtherCharacters_IdCharactere" });
            DropIndex("dbo.CharacterResourceCharacter", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterPseudo", new[] { "IdPseudo" });
            DropIndex("dbo.CharacterPseudo", new[] { "IdCharacter" });
            DropIndex("dbo.Protections", new[] { "IdPart" });
            DropIndex("dbo.CharacterProtection", new[] { "IdProtection" });
            DropIndex("dbo.CharacterProtection", new[] { "IdCharacter" });
            DropIndex("dbo.Property", new[] { "IdArea" });
            DropIndex("dbo.CharacterProperty", new[] { "IdProperty" });
            DropIndex("dbo.CharacterProperty", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterSpecialAbility", new[] { "IdSpecial" });
            DropIndex("dbo.CharacterSpecialAbility", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterSkill", new[] { "IdSkill" });
            DropIndex("dbo.CharacterSkill", new[] { "IdCharacter" });
            DropIndex("dbo.Skills", new[] { "IdSpecialAbility" });
            DropIndex("dbo.Skills", new[] { "IdFeature" });
            DropIndex("dbo.Patents", new[] { "IdFeature" });
            DropIndex("dbo.CharacterFeature", new[] { "IdFeature" });
            DropIndex("dbo.CharacterFeature", new[] { "IdCharacter" });
            DropIndex("dbo.Characters", new[] { "IdArea" });
            DropIndex("dbo.Characters", new[] { "IdEthnic" });
            DropIndex("dbo.Characters", new[] { "IdGrade" });
            DropIndex("dbo.Characters", new[] { "IdCorporation" });
            DropIndex("dbo.Characters", new[] { "IdGender" });
            DropIndex("dbo.CharacterArea", new[] { "IdArea" });
            DropIndex("dbo.CharacterArea", new[] { "IdCharacter" });
            DropIndex("dbo.Areas", new[] { "IdCity" });
            DropTable("dbo.Cities");
            DropTable("dbo.Grades");
            DropTable("dbo.Genders");
            DropTable("dbo.Ethnics");
            DropTable("dbo.Corporations");
            DropTable("dbo.CharacterResourceCorporation");
            DropTable("dbo.CharacterResourceCharacter");
            DropTable("dbo.Pseudo");
            DropTable("dbo.CharacterPseudo");
            DropTable("dbo.Parts");
            DropTable("dbo.Protections");
            DropTable("dbo.CharacterProtection");
            DropTable("dbo.Property");
            DropTable("dbo.CharacterProperty");
            DropTable("dbo.CharacterSpecialAbility");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.CharacterSkill");
            DropTable("dbo.Skills");
            DropTable("dbo.Patents");
            DropTable("dbo.Features");
            DropTable("dbo.CharacterFeature");
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterArea");
            DropTable("dbo.Areas");
        }
    }
}
