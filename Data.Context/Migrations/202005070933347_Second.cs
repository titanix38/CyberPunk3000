namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdCity = c.Int(nullable: false),
                        Safety = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.IdCity, cascadeDelete: true)
                .Index(t => t.IdCity);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Characters", "IdArea", c => c.Int());
            CreateIndex("dbo.Characters", "IdArea");
            AddForeignKey("dbo.Characters", "IdArea", "dbo.Areas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "IdCity", "dbo.Cities");
            DropForeignKey("dbo.Characters", "IdArea", "dbo.Areas");
            DropIndex("dbo.Characters", new[] { "IdArea" });
            DropIndex("dbo.Areas", new[] { "IdCity" });
            DropColumn("dbo.Characters", "IdArea");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
        }
    }
}
