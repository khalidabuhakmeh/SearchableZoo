namespace SearchableZoo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Species = c.String(),
                        Age = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Keepers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Speciality = c.String(),
                        YearsExperience = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KeeperAnimals",
                c => new
                    {
                        Keeper_Id = c.Int(nullable: false),
                        Animal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Keeper_Id, t.Animal_Id })
                .ForeignKey("dbo.Keepers", t => t.Keeper_Id, cascadeDelete: true)
                .ForeignKey("dbo.Animals", t => t.Animal_Id, cascadeDelete: true)
                .Index(t => t.Keeper_Id)
                .Index(t => t.Animal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeeperAnimals", "Animal_Id", "dbo.Animals");
            DropForeignKey("dbo.KeeperAnimals", "Keeper_Id", "dbo.Keepers");
            DropIndex("dbo.KeeperAnimals", new[] { "Animal_Id" });
            DropIndex("dbo.KeeperAnimals", new[] { "Keeper_Id" });
            DropTable("dbo.KeeperAnimals");
            DropTable("dbo.Keepers");
            DropTable("dbo.Animals");
        }
    }
}
