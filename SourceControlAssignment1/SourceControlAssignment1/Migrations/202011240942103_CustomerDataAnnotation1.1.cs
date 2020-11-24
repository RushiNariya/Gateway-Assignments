namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDataAnnotation11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "MembershipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipId", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
    }
}
