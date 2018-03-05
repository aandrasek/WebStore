namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghghg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemEntities", "Product_ID", "dbo.ProductEntities");
            DropIndex("dbo.ItemEntities", new[] { "Product_ID" });
            AddColumn("dbo.ItemEntities", "Email", c => c.String());
            AddColumn("dbo.ItemEntities", "ProductID", c => c.Int(nullable: false));
            DropColumn("dbo.ItemEntities", "Product_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemEntities", "Product_ID", c => c.Int());
            DropColumn("dbo.ItemEntities", "ProductID");
            DropColumn("dbo.ItemEntities", "Email");
            CreateIndex("dbo.ItemEntities", "Product_ID");
            AddForeignKey("dbo.ItemEntities", "Product_ID", "dbo.ProductEntities", "ID");
        }
    }
}
