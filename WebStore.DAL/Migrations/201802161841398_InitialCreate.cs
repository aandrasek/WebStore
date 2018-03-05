namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discounted = c.Boolean(nullable: false),
                        InStock = c.Boolean(nullable: false),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductEntityCategoryEntities",
                c => new
                    {
                        ProductEntity_ID = c.Int(nullable: false),
                        CategoryEntity_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductEntity_ID, t.CategoryEntity_ID })
                .ForeignKey("dbo.ProductEntities", t => t.ProductEntity_ID, cascadeDelete: true)
                .ForeignKey("dbo.CategoryEntities", t => t.CategoryEntity_ID, cascadeDelete: true)
                .Index(t => t.ProductEntity_ID)
                .Index(t => t.CategoryEntity_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductEntityCategoryEntities", "CategoryEntity_ID", "dbo.CategoryEntities");
            DropForeignKey("dbo.ProductEntityCategoryEntities", "ProductEntity_ID", "dbo.ProductEntities");
            DropIndex("dbo.ProductEntityCategoryEntities", new[] { "CategoryEntity_ID" });
            DropIndex("dbo.ProductEntityCategoryEntities", new[] { "ProductEntity_ID" });
            DropTable("dbo.ProductEntityCategoryEntities");
            DropTable("dbo.ProductEntities");
            DropTable("dbo.CategoryEntities");
        }
    }
}
