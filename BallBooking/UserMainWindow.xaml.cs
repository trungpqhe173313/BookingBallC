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
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        private BookingFieldsContext con;
        private User user1;
        public UserMainWindow(User _user)
        {
            InitializeComponent();
            this.user1 = _user;
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            var viewBooking = new UserViewBooking(user1);
            viewBooking.Show();
            this.Close();
        }

        private void Prifile_Click(object sender, RoutedEventArgs e)
        {
            var profile = new UserViewProfile(user1);
            profile.Show();
            this.Close();
        }
    }
}
