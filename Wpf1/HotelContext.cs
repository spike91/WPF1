using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf1
{
    public class HotelContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public HotelContext() : base("DefaultConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    }
