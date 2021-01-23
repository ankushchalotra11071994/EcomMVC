namespace Ecom.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.categoryId)
                .ForeignKey("dbo.Products", t => t.product_ProductId)
                .Index(t => t.product_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        thumbnailid = c.Int(nullable: false),
                        Categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Thumbnails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.product_ProductId)
                .Index(t => t.product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thumbnails", "product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Categories", "product_ProductId", "dbo.Products");
            DropIndex("dbo.Thumbnails", new[] { "product_ProductId" });
            DropIndex("dbo.Categories", new[] { "product_ProductId" });
            DropTable("dbo.Thumbnails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
