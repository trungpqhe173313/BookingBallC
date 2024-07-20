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
    /// Interaction logic for FieldWindow.xaml
    /// </summary>
    public partial class FieldWindow : Window
    {
        private BookingFieldsContext con;
        public FieldWindow()
        {
            InitializeComponent();
            con = new BookingFieldsContext();
            loadData();

        }
        private void loadData()
        {
            try
            {
                dgField.ItemsSource = con.Fields.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            var booking = new BookFieldWindow();
            booking.Show();
            this.Close();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void dgField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgField.SelectedItem is Field selected)
            {
                tbDescription.Text = selected.Description.ToString();
                tbField.Text = selected.FieldName.ToString();
                tbLocation.Text = selected.Location.ToString();
                tbPricePerHour.Text = selected.PricePerHour.ToString();

            }
        }
        private void clear()
        {
            tbPricePerHour.Clear();
            tbDescription.Clear();
            tbField.Clear();
            tbLocation.Clear();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (decimal.TryParse(tbPricePerHour.Text, out decimal pricePerHour))
                {
                    var field = new Field
                    {
                        FieldName = tbField.Text,
                        Location = tbLocation.Text,
                        Description = tbDescription.Text,
                        PricePerHour = pricePerHour
                    };

                    con.Fields.Add(field);
                    con.SaveChanges();
                    loadData();
                    clear();
                    MessageBox.Show("Field added successfully!");
                }
                else
                {
                    MessageBox.Show("Please enter a valid price per hour.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding field: {ex.Message}");
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgField.SelectedItem is Field selectedField &&
                    decimal.TryParse(tbPricePerHour.Text, out decimal pricePerHour))
                {
                    selectedField.FieldName = tbField.Text;
                    selectedField.Location = tbLocation.Text;
                    selectedField.Description = tbDescription.Text;
                    selectedField.PricePerHour = pricePerHour;

                    con.SaveChanges();
                    loadData();
                    clear();
                    MessageBox.Show("Field updated successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a field and enter a valid price per hour.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating field: {ex.Message}");
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgField.SelectedItem is Field selectedField)
                {
                    // Lấy tất cả các bookings liên quan đến field này
                    var relatedBookings = con.Bookings.Where(b => b.FieldId == selectedField.FieldId).ToList();

                    // Xóa các bookings liên quan
                    con.Bookings.RemoveRange(relatedBookings);

                    // Xóa field
                    con.Fields.Remove(selectedField);

                    // Lưu thay đổi
                    con.SaveChanges();

                    // Tải lại dữ liệu và làm sạch các ô nhập liệu
                    loadData();
                    clear();
                    MessageBox.Show("Field and related bookings deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a field to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting field and related bookings: {ex.Message}");
            }
        }

    }
}
