using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf1
{
    /// <summary>
    /// Interaction logic for RoomDetails.xaml
    /// </summary>
    public partial class RoomDetails : Window
    {
        Room room;
        HotelContext db = new HotelContext();
        public RoomDetails(Room room)
        {
            InitializeComponent();
            this.room = room;
            Block.IsEnabled = room.Available;
            UnBlock.IsEnabled = !room.Available;
            AddClient.IsEnabled = !room.Available;
        }

        private void UpdateRoom()
        {
            Block.IsEnabled = room.Available;
            UnBlock.IsEnabled = !room.Available;
            AddClient.IsEnabled = !room.Available;
            db.Rooms.Attach(room);
            db.Entry(room).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        private void CreateBooking()
        {
            db.Bookings.Add(new Booking() { Check_in = DateTime.Now, Room = this.room });

        }

        private void CancelBooking()
        {
            Booking booking = db.Bookings.Where(b => b.RoomId == this.room.RoomId).Single();
            booking.Check_out = DateTime.Now;

        }

        private void Block_Click(object sender, RoutedEventArgs e)
        {
            room.Available = false;
            CreateBooking();
            UpdateRoom();
        }

        private void UnBlock_Click(object sender, RoutedEventArgs e)
        {
            room.Available = true;
            CancelBooking();
            UpdateRoom();
        }

        private void UpdateClients()
        {

        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client()
                {
                    Firstname = Tb_firstname.Text,
                    Lastname = Tb_lastname.Text,
                    Email = Tb_email.Text,
                    Telephone = Tb_telephone.Text,
                    Birthday = Dp_birthday.SelectedDate.Value
                };
                Client client_check;
                client_check = db.Clients.Where(
                   c => c.Firstname == client.Firstname
                && c.Lastname == client.Lastname
                && c.Birthday == client.Birthday
                ).Single();
                if (client_check != null)
                {
                    client_check.Email = client.Email;
                    client_check.Telephone = client.Telephone;
                    db.Clients.Attach(client_check);
                    db.Entry(client_check).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                UpdateClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid data!");
            }
        }
    }
}
