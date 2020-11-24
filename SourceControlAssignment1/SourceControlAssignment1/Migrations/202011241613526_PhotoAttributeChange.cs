namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoAttributeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PhotoPath", c => c.String(nullable: false));
        }
    }
}
