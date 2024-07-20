using BallBooking.Models;
using Microsoft.VisualBasic.ApplicationServices;
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
    /// Interaction logic for UserViewProfile.xaml
    /// </summary>
    public partial class UserViewProfile : Window
    {
        private BookingFieldsContext con;
        private Models.User user1;
        public UserViewProfile(Models.User _user)
        {
            InitializeComponent();
            con = new BookingFieldsContext();
            this.user1 = _user;
            loadProfile();
            
        }
        private void LoadProfile()
        {
           try
            {
                user1 = con.Users.FirstOrDefault(x => x.UserId == user1.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewBooking_Click(object sender, RoutedEventArgs e)
        {
            var viewBooking = new UserViewBooking(user1);
            viewBooking.Show();
            this.Close();
        }

        private void loadProfile()
        {
            try
            {
                if (user1 != null)
                {
                    Models.User loadedUser = con.Users.FirstOrDefault(x => x.UserId == user1.UserId);
                    if (loadedUser != null)
                    {
                        user1 = loadedUser;
                        txtEmail.Text = user1.Email;
                        txtName.Text = user1.FullName;
                        txtPhone.Text = user1.Username;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy người dùng!");
                    }
                }
                else
                {
                    MessageBox.Show("Người dùng hiện tại là null!");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin người dùng: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}");
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lấy đối tượng người dùng từ cơ sở dữ liệu
                var userToUpdate = con.Users.FirstOrDefault(u => u.UserId == user1.UserId);
                if (userToUpdate != null)
                {
                    // Cập nhật các thuộc tính của người dùng
                    userToUpdate.Username = txtPhone.Text;
                    userToUpdate.Email = txtEmail.Text;
                    userToUpdate.FullName = txtName.Text;
                    
                    con.Users.Update(userToUpdate);
                    // Lưu thay đổi vào cơ sở dữ liệu
                    con.SaveChanges();

                    MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                    loadProfile();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật người dùng: {ex.Message}");
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            user1 = null;
            var formMain = new MainWindow();
            formMain.Show();
            this.Close(); ;
        }
    }
}
