using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Drawing;

namespace Wpf1
{
    /// <summary>
    /// Interaction logic for RoomDetails.xaml
    /// </summary>
    public partial class RoomDetails : Window
    {
        Room room;
        Button roomButton;
        HotelContext db = new HotelContext();
        public RoomDetails(Room room, Button roomButton)
        {
            InitializeComponent();
            this.room = db.Rooms.Find(room.RoomId);
            this.roomButton = roomButton;
            Block.IsEnabled = this.room.Available;
            UnBlock.IsEnabled = !this.room.Available;
            AddClient.IsEnabled = !this.room.Available;
            UpdateClients();
        }

        private void UpdateRoom()
        {
            Block.IsEnabled = this.room.Available;
            UnBlock.IsEnabled = !this.room.Available;
            AddClient.IsEnabled = !this.room.Available;            
            db.Rooms.Attach(this.room);
            db.Entry(this.room).State = EntityState.Modified;
            db.SaveChanges();
        }

        private void CreateBooking()
        {
            db.Rooms.Attach(this.room);
            db.Bookings.Add(new Booking() { Check_in = DateTime.Now, Check_out = null, Room = this.room });
            db.SaveChanges();

        }

        private void CancelBooking()
        {
            Booking booking = db.Bookings.Where(b => b.RoomId == this.room.RoomId && b.isClosed == false).FirstOrDefault();
            booking.Check_out = DateTime.Now;
            booking.isClosed = true;
            db.SaveChanges();
            UpdateClients();

        }

        private void Block_Click(object sender, RoutedEventArgs e)
        {
            room.Available = false;
            CreateBooking();
            UpdateRoom();
            roomButton.Background = new SolidColorBrush(Colors.Red);
        }

        private void UnBlock_Click(object sender, RoutedEventArgs e)
        {
            room.Available = true;
            CancelBooking();
            UpdateRoom();
            roomButton.Background = new SolidColorBrush(Colors.Green);
        }

        private void UpdateClients()
        {
            List<Client> clients = db.Bookings.Where(b => b.RoomId == room.RoomId && b.isClosed == false).SelectMany(b => b.Clients).ToList();
            ClientsGrid.ItemsSource = clients;
            if (clients.Count >= Int32.Parse(this.room.Bedrooms))
            {
                AddClient.IsEnabled = false;
            }
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
                ).SingleOrDefault();
                if (client_check != null)
                {
                    client_check.Email = client.Email;
                    client_check.Telephone = client.Telephone;                    
                    db.Clients.Attach(client_check);
                    db.Entry(client_check).State = EntityState.Modified;
                    db.Bookings.Where(b => b.RoomId == this.room.RoomId && b.isClosed == false).FirstOrDefault().Clients.Add(client_check);
                }
                else
                {
                    db.Clients.Add(client);
                    db.Bookings.Where(b => b.RoomId == this.room.RoomId && b.isClosed == false).FirstOrDefault().Clients.Add(client);
                }

                db.SaveChanges();
                UpdateClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid data!");
            }
        }
    }
}
