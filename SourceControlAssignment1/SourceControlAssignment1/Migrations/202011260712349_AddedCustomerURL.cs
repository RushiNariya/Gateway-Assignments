namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "URL");
        }
    }
}
