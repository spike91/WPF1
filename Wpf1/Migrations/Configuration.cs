namespace Wpf1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Wpf1.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Wpf1.HotelContext context)
        {
            using (HotelContext db = new HotelContext())
            {
                if (db.Rooms.Count() == 0)
                {
                    db.Rooms.Add(new Room() { Number = 101.ToString(), Bedrooms = 2.ToString(), Price = 30, Available = true });
                    db.Rooms.Add(new Room() { Number = 102.ToString(), Bedrooms = 2.ToString(), Price = 30, Available = true });
                    db.Rooms.Add(new Room() { Number = 103.ToString(), Bedrooms = 2.ToString(), Price = 30, Available = true });
                    db.Rooms.Add(new Room() { Number = 104.ToString(), Bedrooms = 3.ToString(), Price = 50, Available = true });
                    db.Rooms.Add(new Room() { Number = 105.ToString(), Bedrooms = 1.ToString(), Price = 20, Available = true });
                    db.SaveChanges();
                }
            }
        }
    }
}
