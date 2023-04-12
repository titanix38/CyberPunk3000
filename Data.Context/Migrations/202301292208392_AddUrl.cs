namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
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
                "dbo.CharacterAreas",
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
                        IdCharacter = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Chance = c.Int(nullable: false),
                        Alive = c.Boolean(nullable: false),
                        Slash = c.Int(),
                        Cross = c.Int(),
                        Stabilized = c.Boolean(),
                        IdGender = c.Int(nullable: false),
                        IdCorporation = c.Int(),
                        IdGrade = c.Int(),
                        IdEthnic = c.Int(nullable: false),
                        IdArea = c.Int(),
                    })
                .PrimaryKey(t => t.IdCharacter)
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
                "dbo.CharacterFeatures",
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
                        IdSkill = c.Int(),
                        IdSpecialAbility = c.Int(),
                        Skills_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.IdFeature)
                .ForeignKey("dbo.Skills", t => t.Skills_Id)
                .Index(t => t.IdFeature)
                .Index(t => t.Skills_Id);
            
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
                "dbo.CharacterSkills",
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
                "dbo.CharacterSpecialAbilities",
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
                "dbo.CharacterProperties",
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
                "dbo.CharacterProtections",
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
                "dbo.CharacterPseudos",
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
                "dbo.CharacterResourceCharacters",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdOtherCharacter = c.Guid(nullable: false),
                        Value = c.Int(nullable: false),
                        OtherCharacters_IdCharacter = c.Guid(),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdOtherCharacter })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.OtherCharacters_IdCharacter)
                .Index(t => t.IdCharacter)
                .Index(t => t.OtherCharacters_IdCharacter);
            
            CreateTable(
                "dbo.CharacterResourceCorporations",
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
                "dbo.CharactersWeapons",
                c => new
                    {
                        IdCharacter = c.Guid(nullable: false),
                        IdWeapon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharacter, t.IdWeapon })
                .ForeignKey("dbo.Characters", t => t.IdCharacter, cascadeDelete: true)
                .ForeignKey("dbo.Weapons", t => t.IdWeapon, cascadeDelete: true)
                .Index(t => t.IdCharacter)
                .Index(t => t.IdWeapon);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                        Magazine = c.Int(),
                        Range = c.Int(),
                        AccuracyBonus = c.Int(nullable: false),
                        Silencer = c.Boolean(nullable: false),
                        DamageMultiplier = c.Int(nullable: false),
                        DamageBonus = c.Int(nullable: false),
                        IdDice = c.Int(nullable: false),
                        IdCategory = c.Int(nullable: false),
                        IdConcealment = c.Int(nullable: false),
                        IdPlace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concealments", t => t.IdConcealment, cascadeDelete: true)
                .ForeignKey("dbo.Dices", t => t.IdPlace, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.IdPlace, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.IdCategory, cascadeDelete: true)
                .Index(t => t.IdCategory)
                .Index(t => t.IdConcealment)
                .Index(t => t.IdPlace);
            
            CreateTable(
                "dbo.Concealments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dices",
                c => new
                    {
                        IdDice = c.Int(nullable: false, identity: true),
                        Face = c.Int(nullable: false),
                        Bonus = c.Int(),
                        Malus = c.Int(),
                    })
                .PrimaryKey(t => t.IdDice);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wording = c.String(),
                        Alias = c.String(),
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
            DropForeignKey("dbo.CharacterAreas", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Characters", "IdGrade", "dbo.Grades");
            DropForeignKey("dbo.Characters", "IdGender", "dbo.Genders");
            DropForeignKey("dbo.Characters", "IdEthnic", "dbo.Ethnics");
            DropForeignKey("dbo.Characters", "IdCorporation", "dbo.Corporations");
            DropForeignKey("dbo.CharactersWeapons", "IdWeapon", "dbo.Weapons");
            DropForeignKey("dbo.Weapons", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Weapons", "IdPlace", "dbo.Places");
            DropForeignKey("dbo.Weapons", "IdPlace", "dbo.Dices");
            DropForeignKey("dbo.Weapons", "IdConcealment", "dbo.Concealments");
            DropForeignKey("dbo.CharactersWeapons", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterResourceCorporations", "IdCorpo", "dbo.Corporations");
            DropForeignKey("dbo.CharacterResourceCorporations", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterResourceCharacters", "OtherCharacters_IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterResourceCharacters", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterPseudos", "IdPseudo", "dbo.Pseudo");
            DropForeignKey("dbo.CharacterPseudos", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterProtections", "IdProtection", "dbo.Protections");
            DropForeignKey("dbo.Protections", "IdPart", "dbo.Parts");
            DropForeignKey("dbo.CharacterProtections", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterProperties", "IdProperty", "dbo.Property");
            DropForeignKey("dbo.Property", "IdArea", "dbo.Areas");
            DropForeignKey("dbo.CharacterProperties", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.CharacterFeatures", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.Patents", "Skills_Id", "dbo.Skills");
            DropForeignKey("dbo.Skills", "IdSpecialAbility", "dbo.SpecialAbilities");
            DropForeignKey("dbo.CharacterSpecialAbilities", "IdSpecial", "dbo.SpecialAbilities");
            DropForeignKey("dbo.CharacterSpecialAbilities", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Skills", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.CharacterSkills", "IdSkill", "dbo.Skills");
            DropForeignKey("dbo.CharacterSkills", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Patents", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.CharacterFeatures", "IdCharacter", "dbo.Characters");
            DropForeignKey("dbo.Characters", "IdArea", "dbo.Areas");
            DropForeignKey("dbo.CharacterAreas", "IdArea", "dbo.Areas");
            DropIndex("dbo.Weapons", new[] { "IdPlace" });
            DropIndex("dbo.Weapons", new[] { "IdConcealment" });
            DropIndex("dbo.Weapons", new[] { "IdCategory" });
            DropIndex("dbo.CharactersWeapons", new[] { "IdWeapon" });
            DropIndex("dbo.CharactersWeapons", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterResourceCorporations", new[] { "IdCorpo" });
            DropIndex("dbo.CharacterResourceCorporations", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterResourceCharacters", new[] { "OtherCharacters_IdCharacter" });
            DropIndex("dbo.CharacterResourceCharacters", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterPseudos", new[] { "IdPseudo" });
            DropIndex("dbo.CharacterPseudos", new[] { "IdCharacter" });
            DropIndex("dbo.Protections", new[] { "IdPart" });
            DropIndex("dbo.CharacterProtections", new[] { "IdProtection" });
            DropIndex("dbo.CharacterProtections", new[] { "IdCharacter" });
            DropIndex("dbo.Property", new[] { "IdArea" });
            DropIndex("dbo.CharacterProperties", new[] { "IdProperty" });
            DropIndex("dbo.CharacterProperties", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterSpecialAbilities", new[] { "IdSpecial" });
            DropIndex("dbo.CharacterSpecialAbilities", new[] { "IdCharacter" });
            DropIndex("dbo.CharacterSkills", new[] { "IdSkill" });
            DropIndex("dbo.CharacterSkills", new[] { "IdCharacter" });
            DropIndex("dbo.Skills", new[] { "IdSpecialAbility" });
            DropIndex("dbo.Skills", new[] { "IdFeature" });
            DropIndex("dbo.Patents", new[] { "Skills_Id" });
            DropIndex("dbo.Patents", new[] { "IdFeature" });
            DropIndex("dbo.CharacterFeatures", new[] { "IdFeature" });
            DropIndex("dbo.CharacterFeatures", new[] { "IdCharacter" });
            DropIndex("dbo.Characters", new[] { "IdArea" });
            DropIndex("dbo.Characters", new[] { "IdEthnic" });
            DropIndex("dbo.Characters", new[] { "IdGrade" });
            DropIndex("dbo.Characters", new[] { "IdCorporation" });
            DropIndex("dbo.Characters", new[] { "IdGender" });
            DropIndex("dbo.CharacterAreas", new[] { "IdArea" });
            DropIndex("dbo.CharacterAreas", new[] { "IdCharacter" });
            DropIndex("dbo.Areas", new[] { "IdCity" });
            DropTable("dbo.Cities");
            DropTable("dbo.Grades");
            DropTable("dbo.Genders");
            DropTable("dbo.Ethnics");
            DropTable("dbo.Categories");
            DropTable("dbo.Places");
            DropTable("dbo.Dices");
            DropTable("dbo.Concealments");
            DropTable("dbo.Weapons");
            DropTable("dbo.CharactersWeapons");
            DropTable("dbo.Corporations");
            DropTable("dbo.CharacterResourceCorporations");
            DropTable("dbo.CharacterResourceCharacters");
            DropTable("dbo.Pseudo");
            DropTable("dbo.CharacterPseudos");
            DropTable("dbo.Parts");
            DropTable("dbo.Protections");
            DropTable("dbo.CharacterProtections");
            DropTable("dbo.Property");
            DropTable("dbo.CharacterProperties");
            DropTable("dbo.CharacterSpecialAbilities");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.CharacterSkills");
            DropTable("dbo.Skills");
            DropTable("dbo.Patents");
            DropTable("dbo.Features");
            DropTable("dbo.CharacterFeatures");
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterAreas");
            DropTable("dbo.Areas");
        }
    }
}
