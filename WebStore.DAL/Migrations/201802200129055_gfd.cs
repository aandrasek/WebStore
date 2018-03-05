namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemEntities", "UserID", c => c.String());
            DropColumn("dbo.ItemEntities", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemEntities", "Email", c => c.String());
            DropColumn("dbo.ItemEntities", "UserID");
        }
    }
}
