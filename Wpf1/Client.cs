using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf1
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Client()
        {
            Bookings = new List<Booking>();
        }
    }
}
