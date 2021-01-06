namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Short_Desc", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Products", "SmallImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "SmallImagePath", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Short_Desc", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
    }
}
