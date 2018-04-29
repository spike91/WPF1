using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf1
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Number { get; set; }
        public string Bedrooms { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Room()
        {
            Bookings = new List<Booking>();
        }
    }
}
