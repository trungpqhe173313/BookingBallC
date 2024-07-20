using BallBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for BookFieldWindow.xaml
    /// </summary>
    public partial class BookFieldWindow : Window
    {
        private BookingFieldsContext con;

        public BookFieldWindow()
        {
            InitializeComponent();
            con = new BookingFieldsContext();
            loadField();
            loadData();
        }
        private void loadData()
        {
            // Đảm bảo rằng việc kết nối cơ sở dữ liệu thành công
            try
            {
                UpdateExpiredBookingsStatus();
                var userBookings = con.Bookings
                                      .Include(x => x.Field)
                                      .Include(x => x.Status)
                                  .Where(x => x.StatusId == 3)
                                  .ToList();
                dgBooking.ItemsSource = userBookings;
                
                if (userBookings.Count == 0)
                {
                    MessageBox.Show("Không có booking nào với trạng thái 'đã đặt'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}");
            }
        }
        private void loadField()
        {
            try
            {
                cbField.ItemsSource = con.Fields.ToList();
                cbField.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private void dgBooking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBooking.SelectedItem is Booking selected)
            {
                User user = con.Users.FirstOrDefault(x => x.UserId == selected.UserId);
                if (user != null)
                {
                    tbPhone.Text = user.Username.ToString();
                }


                // Hiển thị TotalPrice


                // Hiển thị StartTime
                tbStartTime.Text = selected.StartTime.ToString();

                // Hiển thị EndTime
                tbEndTime.Text = selected.EndTime.ToString();

                // Kiểm tra và thiết lập giá trị cho ComboBox cbField

                // Giả sử selected.Field.FieldName là thuộc tính cần khớp với các mục trong ComboBox
                Field field = con.Fields.FirstOrDefault(x => x.FieldId == selected.FieldId);
                tbPrice.Text = field.PricePerHour.ToString();
                dpDate.Text = selected.BookingDate.ToString();
                if (field != null)
                {
                    cbField.SelectedItem = field;
                }
                else
                {
                    cbField.SelectedIndex = -1; // Không có mục nào khớp, xóa lựa chọn
                }

            }
        }

        private void btnField_Click(object sender, RoutedEventArgs e)
        {
            var filed = new FieldWindow();
            filed.Show();
            this.Close();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {

            var main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbField.SelectedItem is Field selectedField &&
                    TimeOnly.TryParse(tbStartTime.Text, out TimeOnly startTime) &&
                    TimeOnly.TryParse(tbEndTime.Text, out TimeOnly endTime) &&
                    decimal.TryParse(tbPrice.Text, out decimal pricePerHour) &&
                    !string.IsNullOrEmpty(tbPhone.Text))
                {
                    // Kiểm tra điều kiện StartTime phải nhỏ hơn EndTime
                    if (startTime < endTime)
                    {
                        var bookingDate = DateOnly.FromDateTime(dpDate.SelectedDate.Value);

                        // Kiểm tra xem có booking nào trong cùng khung giờ và cùng ngày cho sân đã chọn không
                        var overlappingBookings = con.Bookings
                            .Where(b => b.FieldId == selectedField.FieldId &&
                                        b.StatusId == 3 &&
                                        b.BookingDate == bookingDate &&
                                        (
                                            (startTime >= b.StartTime && startTime < b.EndTime) ||
                                            (endTime > b.StartTime && endTime <= b.EndTime) ||
                                            (startTime <= b.StartTime && endTime >= b.EndTime)
                                        ))
                            .ToList();

                        if (overlappingBookings.Any())
                        {
                            MessageBox.Show("Đã có booking trong khung giờ này cho sân này. Vui lòng chọn thời gian khác.");
                            return;
                        }

                        // Tìm hoặc thêm người dùng mới với số điện thoại đã nhập
                        var user = con.Users.FirstOrDefault(u => u.Username == tbPhone.Text);
                        if (user == null)
                        {
                            user = new User
                            {
                                Username = tbPhone.Text,
                                Password = "123", // Mật khẩu mặc định
                                FullName = null,
                                Email = null,
                            };
                            con.Users.Add(user);
                            con.SaveChanges();
                        }

                        var totalMinutes = (endTime - startTime).TotalMinutes;
                        var totalHours = totalMinutes / 60;

                        // Tính tổng tiền dựa trên PricePerHour
                        var total = pricePerHour * (decimal)totalHours;

                        var booking = new Booking
                        {
                            UserId = user.UserId,
                            FieldId = selectedField.FieldId,
                            StatusId = 3,
                            StartTime = startTime,
                            EndTime = endTime,
                            BookingDate = bookingDate,
                            TotalPrice = total
                        };

                        con.Bookings.Add(booking);
                        con.SaveChanges();
                        loadData();
                        ClearFields();
                        MessageBox.Show("Booking added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Start Time phải nhỏ hơn End Time.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields correctly.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding booking: {ex.Message}");
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Inner exception: {ex.InnerException.Message}");
                }
            }
        }







        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgBooking.SelectedItem is Booking selectedBooking &&
                    cbField.SelectedItem is Field selectedField &&
                    TimeOnly.TryParse(tbStartTime.Text, out TimeOnly startTime) &&
                    TimeOnly.TryParse(tbEndTime.Text, out TimeOnly endTime) &&
                    decimal.TryParse(tbPrice.Text, out decimal pricePerHour) &&
                    dpDate.SelectedDate.HasValue)
                {
                    var bookingDate = DateOnly.FromDateTime(dpDate.SelectedDate.Value);

                    // Kiểm tra điều kiện StartTime phải nhỏ hơn EndTime
                    if (startTime < endTime)
                    {
                        // Kiểm tra xem có booking nào khác trong cùng ngày và khung giờ cho sân đã chọn không
                        var overlappingBookings = con.Bookings
                            .Where(b => b.FieldId == selectedField.FieldId &&
                                        b.StatusId == 3 &&
                                        b.BookingDate == bookingDate &&
                                        b.BookingId != selectedBooking.BookingId &&
                                        (
                                            (startTime >= b.StartTime && startTime < b.EndTime) ||
                                            (endTime > b.StartTime && endTime <= b.EndTime) ||
                                            (startTime <= b.StartTime && endTime >= b.EndTime)
                                        ))
                            .ToList();

                        if (overlappingBookings.Any())
                        {
                            MessageBox.Show("Đã có booking khác trong ngày và khung giờ này cho sân này. Vui lòng chọn thời gian khác.");
                            return;
                        }

                        var totalMinutes = (endTime - startTime).TotalMinutes;
                        var totalHours = totalMinutes / 60;

                        // Tính tổng tiền dựa trên PricePerHour
                        var total = pricePerHour * (decimal)totalHours;

                        // Cập nhật thông tin booking
                        selectedBooking.FieldId = selectedField.FieldId;
                        selectedBooking.StatusId = 3;
                        selectedBooking.StartTime = startTime;
                        selectedBooking.EndTime = endTime;
                        selectedBooking.BookingDate = bookingDate;
                        selectedBooking.TotalPrice = total;

                        con.SaveChanges();
                        loadData();
                        ClearFields();
                        MessageBox.Show("Booking updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Start Time phải nhỏ hơn End Time.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields correctly.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating booking: {ex.Message}");
            }
        }



        private void ClearFields()
        {
            cbField.SelectedIndex = -1;
            tbPhone.Clear();
            tbPrice.Clear();
            tbStartTime.Clear();
            tbEndTime.Clear();
            dpDate.SelectedDate = null;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePriceBasedOnField();
        }
        private void UpdatePriceBasedOnField()
        {
            try
            {
                // Lấy sân được chọn từ ComboBox
                var selectedField = cbField.SelectedItem as Field;
                if (selectedField != null)
                {
                    // Cập nhật giá tiền vào TextBox tbPrice
                    tbPrice.Text = selectedField.PricePerHour.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật giá tiền: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgBooking.SelectedItem is Booking selectedBooking)
                {
                    // Đặt trạng thái của booking thành 2 (đã hủy)
                    selectedBooking.StatusId = 2;

                    con.Bookings.Update(selectedBooking);
                    con.SaveChanges();
                    loadData();
                    MessageBox.Show("Booking has been cancelled successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a booking to cancel.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling booking: {ex.Message}");
            }
        }
        private void UpdateExpiredBookingsStatus()
        {
            try
            {
                // Lấy tất cả các lịch đặt có trạng thái '3' (đang đặt)
                var bookings = con.Bookings
                          .Where(b => b.StatusId == 3)
                          .ToList(); // Chuyển dữ liệu sang phía client

                // Kiểm tra các lịch đặt đã hết hạn
                var expiredBookings = bookings
                                      .Where(b => DateTime.Parse($"{b.BookingDate.ToShortDateString()} {b.EndTime}") < DateTime.Now)
                                      .ToList();

                if (expiredBookings.Any())
                {
                    // Cập nhật trạng thái các lịch đặt đã qua
                    foreach (var booking in expiredBookings)
                    {
                        booking.StatusId = 2;
                    }

                    con.SaveChanges();
                    MessageBox.Show("Updated expired bookings successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating expired bookings: {ex.Message}");
            }
        }
    }
}
