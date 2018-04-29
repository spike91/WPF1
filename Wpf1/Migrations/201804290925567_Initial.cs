namespace Wpf1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Check_in = c.DateTime(nullable: false),
                        Check_out = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Telephone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Bedrooms = c.String(),
                        Price = c.Double(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.ClientBookings",
                c => new
                    {
                        Client_ClientId = c.Int(nullable: false),
                        Booking_BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_ClientId, t.Booking_BookingId })
                .ForeignKey("dbo.Clients", t => t.Client_ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId, cascadeDelete: true)
                .Index(t => t.Client_ClientId)
                .Index(t => t.Booking_BookingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ClientBookings", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.ClientBookings", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.ClientBookings", new[] { "Booking_BookingId" });
            DropIndex("dbo.ClientBookings", new[] { "Client_ClientId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropTable("dbo.ClientBookings");
            DropTable("dbo.Rooms");
            DropTable("dbo.Clients");
            DropTable("dbo.Bookings");
        }
    }
}
