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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf1
{
    public partial class HotelPlan : Window
    {
        List<Button> buttons;
        List<Room> rooms;
        public HotelPlan()
        {
            InitializeComponent();
            buttons = new List<Button>() { Room1, Room2, Room3, Room4, Room5 };
            using (HotelContext db = new HotelContext())
            {
                rooms = db.Rooms.OrderBy(r => r.Number).ToList();
            }  
            for (int i =0; i < buttons.Count; i++)
            {
                buttons[i].Content = "#" + rooms[i].Number + "\nBedrooms: "+ rooms[i].Bedrooms;
                if (rooms[i].Available)
                {
                    buttons[i].Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    buttons[i].Background = new SolidColorBrush(Colors.Red);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new RoomDetails(rooms[0],buttons[0]);
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new RoomDetails(rooms[1], buttons[1]);
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window window = new RoomDetails(rooms[2], buttons[2]);
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window window = new RoomDetails(rooms[3], buttons[3]);
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window window = new RoomDetails(rooms[4], buttons[4]);
            window.Show();
        }
    }
}
