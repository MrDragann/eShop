namespace eShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "ManufacturerId", c => c.Int());
            CreateIndex("dbo.Products", "ManufacturerId");
            AddForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropColumn("dbo.Products", "ManufacturerId");
            DropTable("dbo.Manufacturers");
        }
    }
}
