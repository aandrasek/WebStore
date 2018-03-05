namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductEntities", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemEntities", "Product_ID", "dbo.ProductEntities");
            DropIndex("dbo.ItemEntities", new[] { "Product_ID" });
            DropTable("dbo.ItemEntities");
        }
    }
}
