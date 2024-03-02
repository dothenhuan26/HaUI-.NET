using DoTheNhuan_381.Models;
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
        QLDuocPhamContext db = new QLDuocPhamContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from dm in db.DanhMucThuocs select dm;
            inputCategory.ItemsSource = query.ToList();
            inputCategory.SelectedValuePath = "MaDm";
            inputCategory.DisplayMemberPath = "TenDm";
            inputCategory.SelectedIndex = 0;
            RenderData();
        }

        private void RenderData()
        {
            var query = from thuoc in db.Thuocs
                        where thuoc.SoLuong <= 200
                        select new
                        {
                            MaThuoc = thuoc.MaThuoc,
                            TenThuoc = thuoc.TenThuoc,
                            MaDm = thuoc.MaDm,
                            GiaBan = thuoc.GiaBan,
                            SoLuong = thuoc.SoLuong,
                            ThanhTien = thuoc.GiaBan * thuoc.SoLuong
                        };

            renderData.ItemsSource = query.ToList();
        }

        private void clearInput()
        {
            inputId.IsReadOnly = false;
            inputId.Clear();
            inputName.Clear();
            inputPrice.Clear();
            inputAmount.Clear();
            inputCategory.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validateId() && validate())
            {
                Thuoc thuoc = new Thuoc();
                thuoc.MaThuoc = inputId.Text.Trim();
                thuoc.TenThuoc = inputName.Text.Trim();
                thuoc.GiaBan = double.Parse(inputPrice.Text.Trim());
                thuoc.SoLuong = int.Parse(inputAmount.Text.Trim());
                thuoc.MaDm = inputCategory.SelectedValue.ToString();
                db.Thuocs.Add(thuoc);
                db.SaveChanges();
                clearInput();
                RenderData();
            }
        }

        private bool validateId()
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã thuốc không được để trống!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Focus();
                return false;
            }
            var thuoc = db.Thuocs.FirstOrDefault(x => x.MaThuoc == inputId.Text.Trim());
            if (thuoc != null)
            {
                MessageBox.Show("Mã thuốc đã tồn tại!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Text = "";
                inputId.Focus();
                return false;
            }
            return true;
        }

        private bool validate()
        {
            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên thuốc không được để trống!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputName.Focus();
                return false;
            }
            bool flag;
            int inputInt;
            double inputDouble;
            if (inputPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Gía bán không được để trống!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputPrice.Focus();
                return false;
            }
            flag = double.TryParse(inputPrice.Text.Trim(), out inputDouble);
            if (!flag || inputDouble <= 0)
            {
                MessageBox.Show("Gía bán phải là số thực dương!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputPrice.Text = "";
                inputPrice.Focus();
                return false;
            }
            if (inputAmount.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số lượng không được để trống!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputAmount.Focus();
                return false;
            }
            flag = int.TryParse(inputPrice.Text.Trim(), out inputInt);
            if (!flag || inputInt <= 0)
            {
                MessageBox.Show("Gía bán phải là số nguyên dương!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputPrice.Text = "";
                inputPrice.Focus();
                return false;
            }
            return true;
        }

        private void renderData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var thuoc = renderData.SelectedItem;
            if (thuoc != null)
            {
                try
                {
                    Type t = thuoc.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    inputId.Text = p[0].GetValue(renderData.SelectedValue).ToString();
                    inputId.IsReadOnly = true;
                    inputName.Text = p[1].GetValue(renderData.SelectedValue).ToString();
                    inputPrice.Text = p[3].GetValue(renderData.SelectedValue).ToString();
                    inputAmount.Text = p[4].GetValue(renderData.SelectedValue).ToString();
                    inputCategory.SelectedValue = p[2].GetValue(renderData.SelectedValue).ToString();
                    return;

                }
                catch
                {
                    MessageBox.Show("Thuốc không hợp lệ!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var thuoc = db.Thuocs.FirstOrDefault(x => x.MaThuoc == inputId.Text);

            if (thuoc != null)
            {
                if (validate())
                {
                    thuoc.TenThuoc = inputName.Text.Trim();
                    thuoc.GiaBan = double.Parse(inputPrice.Text.Trim());
                    thuoc.SoLuong = int.Parse(inputAmount.Text.Trim());
                    thuoc.MaDm = inputCategory.SelectedValue.ToString();
                    db.SaveChanges();
                    clearInput();
                    RenderData();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Thuốc không hợp lệ!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var thuoc = db.Thuocs.FirstOrDefault(x => x.MaThuoc == inputId.Text);
            if (thuoc != null)
            {
                MessageBoxResult rs = MessageBox.Show("Xác nhận xóa?", "Xóa Thuốc", MessageBoxButton.YesNoCancel);
                if (rs == MessageBoxResult.Yes)
                {
                    db.Thuocs.Remove(thuoc);
                    db.SaveChanges();
                    clearInput();
                    RenderData();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Thuốc không hợp lệ!", "INVALID INPUT DATA!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();

            var query = from dm in db.DanhMucThuocs
                        select new
                        {
                            dm.MaDm,
                            dm.TenDm,
                            TongTien = dm.Thuocs.Sum(x => x.GiaBan * x.SoLuong),
                        };

            window1.renderData2.ItemsSource = query.ToList();

            window1.Show();
        }
    }
}
