using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf1
{
    public class Room
    {
        public int RoomId;
        public string number;
        public string bedrooms;
        public double price;
        public bool available;

        public int HotelId;
        public Hotel Hotel;

        public ICollection<Invoice> Invoices;
    }
}
