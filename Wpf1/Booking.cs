using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf1
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public ICollection<Client> Clients { get; set; }

        public Booking()
        {
            Clients = new List<Client>();
        }
    }
}
