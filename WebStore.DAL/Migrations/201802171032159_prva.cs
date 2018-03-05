namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductEntities", "CategoryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductEntities", "CategoryID");
        }
    }
}
