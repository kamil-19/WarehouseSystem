namespace ArmyBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveredItem = c.String(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                        RecipientCompany = c.String(nullable: false),
                        CityTown = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        Weight = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmploymentDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Workplace = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Mark = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Executed = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        OrderId = c.Int(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemFrom = c.String(nullable: false),
                        ItemTo = c.String(nullable: false),
                        DateOfArrival = c.DateTime(nullable: false),
                        DateToSend = c.DateTime(nullable: false),
                        Weight = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderItem = c.String(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                        RecipientCompany = c.String(nullable: false),
                        CityTown = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Client = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShippedItem = c.String(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                        RecipientCompany = c.String(nullable: false),
                        CityTown = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Shipment");
            DropTable("dbo.Return");
            DropTable("dbo.Order");
            DropTable("dbo.Inventory");
            DropTable("dbo.Event");
            DropTable("dbo.EventHistory");
            DropTable("dbo.Equipment");
            DropTable("dbo.Employee");
            DropTable("dbo.Delivery");
            DropTable("dbo.Client");
        }
    }
}
