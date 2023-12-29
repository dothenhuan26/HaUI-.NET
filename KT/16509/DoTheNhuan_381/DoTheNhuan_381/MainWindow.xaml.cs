using DoTheNhuan_381.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace DoTheNhuan_381
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLNhanvienContext db = new QLNhanvienContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderData();
            var query = from pb in db.PhongBans select pb;
            inputDepartment.ItemsSource = query.ToList();
            inputDepartment.DisplayMemberPath = "TenPhong";
            inputDepartment.SelectedValuePath = "MaPhong";
            inputDepartment.SelectedIndex = 0;
        }

        private void RenderData()
        {
            var query = from nv in db.Nhanviens
                        where nv.Luong > 5000
                        select new
                        {
                            nv.MaNv,
                            nv.Hoten,
                            nv.Luong,
                            nv.Thuong,
                            nv.MaPhong,
                            TongTien = nv.Luong + nv.Thuong,
                        };
            renderData.ItemsSource = query.ToList();
        }

        private void clearInput()
        {
            inputId.Clear();
            inputId.IsReadOnly = false;
            inputName.Clear();
            inputSalary.Clear();
            inputBonus.Clear();
            inputDepartment.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validateId() && validate())
            {
                Nhanvien nv = new Nhanvien();
                nv.MaNv = inputId.Text.Trim();
                nv.Hoten = inputName.Text.Trim();
                nv.Luong = int.Parse(inputSalary.Text.Trim());
                nv.Thuong = int.Parse(inputBonus.Text.Trim());
                nv.MaPhong = inputDepartment.SelectedValue.ToString();
                db.Nhanviens.Add(nv);
                db.SaveChanges();
                RenderData();
                clearInput();
            }
        }

        private bool validateId()
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Focus();
                return false;
            }
            var nv = db.Nhanviens.FirstOrDefault(x => x.MaNv == inputId.Text.Trim());
            if (nv != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Clear();
                inputId.Focus();
                return false;
            }
            return true;
        }

        private bool validate()
        {
            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ tên nhân viên không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputName.Focus();
                return false;
            }
            int inputInt;
            bool flag;
            if (inputSalary.Text.Trim().Length == 0)
            {
                MessageBox.Show("Lương nhân viên không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputSalary.Focus();
                return false;
            }
            flag = int.TryParse(inputSalary.Text.Trim(), out inputInt);
            if (!flag || (inputInt < 3000 || inputInt > 9000))
            {
                MessageBox.Show("Lương nhân viên phải từ 3000 đến 9000!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputSalary.Clear();
                inputSalary.Focus();
                return false;
            }
            if (inputBonus.Text.Trim().Length == 0)
            {
                MessageBox.Show("Thưởng nhân viên không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputBonus.Focus();
                return false;
            }
            flag = int.TryParse(inputBonus.Text.Trim(), out inputInt);
            if (!flag || (inputInt < 100 || inputInt > 900))
            {
                MessageBox.Show("Thưởng nhân viên phải từ 300 đến 900!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputBonus.Clear();
                inputBonus.Focus();
                return false;
            }
            return true;
        }

        private void renderData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (renderData.SelectedItem != null)
            {
                Type t = renderData.SelectedItem.GetType();
                PropertyInfo[] nv = t.GetProperties();
                inputId.Text = nv[0].GetValue(renderData.SelectedItem).ToString();
                inputId.IsReadOnly = true;
                inputName.Text = nv[1].GetValue(renderData.SelectedItem).ToString();
                inputSalary.Text = nv[2].GetValue(renderData.SelectedItem).ToString();
                inputBonus.Text = nv[3].GetValue(renderData.SelectedItem).ToString();
                inputDepartment.SelectedValue = nv[4].GetValue(renderData.SelectedItem).ToString();

                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var nv = db.Nhanviens.FirstOrDefault(x => x.MaNv == inputId.Text.Trim());
            if (nv != null)
            {
                if (validate())
                {
                    nv.MaNv = inputId.Text.Trim();
                    nv.Hoten = inputName.Text.Trim();
                    nv.Luong = int.Parse(inputSalary.Text.Trim());
                    nv.Thuong = int.Parse(inputBonus.Text.Trim());
                    nv.MaPhong = inputDepartment.SelectedValue.ToString();
                    db.SaveChanges();
                    RenderData();
                    clearInput();

                    return;
                }
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var nv = db.Nhanviens.FirstOrDefault(x => x.MaNv == inputId.Text.Trim());
            if (nv != null)
            {
                MessageBoxResult rs = MessageBox.Show("Xác nhận xóa?", "Xóa Nhân Viên", MessageBoxButton.YesNoCancel);

                if (rs == MessageBoxResult.Yes)
                {
                    db.Nhanviens.Remove(nv);
                    db.SaveChanges();
                    RenderData();
                    clearInput();

                }
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();

            var query = from pb in db.PhongBans
                        select new
                        {
                            pb.MaPhong,
                            pb.TenPhong,
                            SlNhanVien = pb.Nhanviens.Count(),
                            TongLuong = pb.Nhanviens.Sum(x => x.Thuong + x.Luong),
                        };
            window1.renderData2.ItemsSource = query.ToList();
            window1.Show();
        }
    }
}
