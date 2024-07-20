using BallBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BallBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookingFieldsContext con;
        public MainWindow()
        {
            InitializeComponent();
            con = new BookingFieldsContext();   
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String user = tbUsername.Text;
            String pass = pbPass.Password;
            User user1 = null;
            try
            {
                user1 = con.Users.FirstOrDefault(x => x.Username == user && x.Password == pass);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (user1 != null)
            {
                MessageBox.Show("Đăng nhập thành công!");

                if (user1.RoleId == 2)
                {
                    var adminWindow = new AdminMainWindow(user1);
                    adminWindow.Show();
                    this.Close();
                    return;
                }
                else
                {
                    var userWindow = new UserMainWindow(user1);
                    userWindow.Show();
                    this.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Số điện thoại hoặc mật khẩu không đúng!");
            }
        }
    }
}