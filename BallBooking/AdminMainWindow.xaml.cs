using BallBooking.Models;
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

namespace BallBooking
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        private BookingFieldsContext con;
        private User user1;
        public AdminMainWindow(User user)
        {
            InitializeComponent();
            this.user1 = user;
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            var booking = new BookFieldWindow();
            booking.Show();
            this.Close();
        }

        private void Pitch_Click(object sender, RoutedEventArgs e)
        {
            var filed = new FieldWindow();
            filed.Show();
            this.Close();
        }
    }
}
