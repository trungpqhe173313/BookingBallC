using BallBooking.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for UserViewBooking.xaml
    /// </summary>
    public partial class UserViewBooking : Window
    {
        private User user1;
        private BookingFieldsContext con;
        public UserViewBooking(User _user)
        {
            InitializeComponent();
            this.user1 = _user;
            con = new BookingFieldsContext();
            loadData();
        }
        private void loadData()
        {
            // Lấy ra lịch đặt của người dùng hiện tại
            var userBookings = con.Bookings
                                  .Include(x => x.Field) // Bao gồm thông tin sân
                                  .Where(x => x.UserId == user1.UserId) // Lọc theo UserId của người dùng hiện tại
                                  .ToList();

            // Gán dữ liệu vào DataGrid
            dgBooking.ItemsSource = userBookings;
            //dgBooking.ItemsSource = con.Bookings.Include(x => x.Field).ToList();
        }

        private void btnViewProfile_Click(object sender, RoutedEventArgs e)
        {
            
            var main = new UserViewProfile(user1);
            main.Show();
            this.Close();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            user1 = null;
            var profile = new MainWindow();
            profile.Show();
            this.Close();
        }
    }
}
