namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Age");
        }
    }
}
