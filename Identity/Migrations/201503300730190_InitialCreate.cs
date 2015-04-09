namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street1 = c.String(nullable: false),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Pin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EndUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Email = c.String(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                        Password = c.String(nullable: false, maxLength: 15),
                        ContactNo = c.Int(nullable: false),
                        AddressObject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressObject_Id)
                .Index(t => t.AddressObject_Id);
            
            CreateTable(
                "dbo.ProductOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Description = c.String(),
                        FoundedIn = c.DateTime(nullable: false),
                        WebsiteUrl = c.String(),
                        TwitterUrl = c.String(),
                        FbUrl = c.String(),
                        Email = c.String(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                        Password = c.String(nullable: false, maxLength: 15),
                        ContactNo = c.Int(nullable: false),
                        AddressObject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressObject_Id)
                .Index(t => t.AddressObject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOwners", "AddressObject_Id", "dbo.Addresses");
            DropForeignKey("dbo.EndUsers", "AddressObject_Id", "dbo.Addresses");
            DropIndex("dbo.ProductOwners", new[] { "AddressObject_Id" });
            DropIndex("dbo.EndUsers", new[] { "AddressObject_Id" });
            DropTable("dbo.ProductOwners");
            DropTable("dbo.EndUsers");
            DropTable("dbo.Addresses");
        }
    }
}
