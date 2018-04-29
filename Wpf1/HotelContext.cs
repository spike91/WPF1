using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf1
{
    public class HotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
           .HasOne(r => r.Hotel)
           .WithMany(h => h.Rooms)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
           .HasOne(r => r.Invoice)
           .WithMany(i => i.Clients)
           .OnDelete(DeleteBehavior.Cascade);
        }

        }
    }
