namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parrent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parrent_Id)
                .Index(t => t.Parrent_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        selectedCategory = c.String(),
                        Description = c.String(),
                        Characteristics = c.String(),
                        Price = c.Int(nullable: false),
                        Tags = c.String(),
                        DateAdd = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Parrent_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Parrent_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
