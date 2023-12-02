using DoTheNhuan_381.Models;
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

namespace DoTheNhuan_381
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static QLNhanvienContext db = new QLNhanvienContext();
        static List<Info> listRender = new List<Info>();
        static string maPhong = "", hoTen = "", maNv = "", luongTxt = "", thuongTxt = "";
        static int luong = 0, thuong = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (inputId.Text.Length > 0)
            {
                var nvs = db.Nhanviens.SingleOrDefault(nv => nv.MaNv == inputId.Text);
                if (nvs != null)
                {
                    if (validate())
                    {
                        nvs.MaNv = maNv;
                        nvs.Hoten = hoTen;
                        nvs.Luong = luong;
                        nvs.Thuong = thuong;
                        PhongBan fpb = (PhongBan)departmentId.SelectedItem;
                        nvs.MaPhong = fpb.MaPhong;
                        db.SaveChanges();
                        clearInput();
                        Re_Render();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!");
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên không tồn tại!");
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên không được để trống!");
                inputId.Focus();
                return;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (inputId.Text.Length > 0)
            {
                var nvs = db.Nhanviens.SingleOrDefault(nv => nv.MaNv == inputId.Text);
                if (nvs != null)
                {
                    MessageBoxResult res = MessageBox.Show("Có chắc chắn muốn xóa?", "Thông báo", MessageBoxButton.YesNoCancel);
                    if (res == MessageBoxResult.Yes)
                    {
                        db.Nhanviens.Remove(nvs);
                        db.SaveChanges();
                        clearInput();
                        Re_Render();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên không tồn tại!");
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên không được để trống!");
                inputId.Focus();
                return;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 nwd = new Window1();
            nwd.Show();
        }

        private void Handle_Loaded(object sender, RoutedEventArgs e)
        {
            Re_Render();
        }

        private void Re_Render()
        {
            listRender.Clear();
            var listNV = from nv in db.Nhanviens where nv.Luong > 5000 orderby nv.Luong select nv;
            foreach (var nv in listNV)
            {
                Info info = new Info();
                info.MaNv = nv.MaNv;
                info.Hoten = nv.Hoten;
                info.Thuong = nv.Thuong;
                info.Luong = nv.Luong;
                info.MaPhong = nv.MaPhong;
                info.TongTien = nv.Luong + nv.Thuong;
                listRender.Add(info);
            }
            listData.ItemsSource = listRender.ToList();

            var listDepartment = from dp in db.PhongBans select dp;
            departmentId.ItemsSource = listDepartment.ToList();
            departmentId.DisplayMemberPath = "TenPhong";
            departmentId.SelectedValuePath = "MaPhong";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (maNv.Length > 0)
            {
                var nvById = from nv in db.Nhanviens where nv.MaNv == maNv select nv;
                if (nvById.ToList().Count > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    inputId.Focus();
                    return;
                }
            }
            if (validate())
            {
                Nhanvien nvm = new Nhanvien();
                nvm.MaNv = maNv;
                nvm.Hoten = hoTen;
                nvm.Luong = luong;
                nvm.Thuong = thuong;
                PhongBan fpb = (PhongBan)departmentId.SelectedItem;
                nvm.MaPhong = fpb.MaPhong;
                db.Nhanviens.Add(nvm);
                db.SaveChanges();
                clearInput();
                Re_Render();
            }
        }

        private bool validate()
        {
            maPhong = departmentId.Text;
            hoTen = inputName.Text.Trim();
            maNv = inputId.Text.Trim();
            luongTxt = inputSalary.Text.Trim();
            thuongTxt = inputBonus.Text.Trim();


            if (maNv.Length == 0)
            {
                MessageBox.Show("Mã nhân viên không được để trống!");
                inputId.Focus();
                return false;
            }

            if (hoTen.Length == 0)
            {
                MessageBox.Show("Họ tên không được để trống!");
                inputName.Focus();
                return false;
            }

            if (luongTxt.Length == 0)
            {
                MessageBox.Show("Lương không được để trống!");
                inputSalary.Focus();
                return false;
            }
            else
            {
                bool flag = int.TryParse(luongTxt, out luong);
                if (!flag || !(luong <= 9000 && luong >= 3000))
                {
                    MessageBox.Show("Lương không hợp lệ!");
                    inputSalary.Focus();
                    return false;
                }
            }

            if (thuongTxt.Length == 0)
            {
                MessageBox.Show("Thưởng không được để trống!");
                inputBonus.Focus();
                return false;
            }
            else
            {
                bool flag = int.TryParse(thuongTxt, out thuong);
                if (!flag || !(thuong <= 900 && thuong >= 100))
                {
                    MessageBox.Show("Thưởng không hợp lệ!");
                    inputBonus.Focus();
                    return false;
                }
            }

            if (maPhong.Length == 0)
            {
                MessageBox.Show("Mã phòng không được để trống!");
                departmentId.Focus();
                return false;
            }
            return true;
        }

        private void clearInput()
        {
            inputId.Text = "";
            inputName.Text = "";
            inputSalary.Text = "";
            inputBonus.Text = "";
            departmentId.SelectedIndex = -1;
            maPhong = ""; hoTen = ""; maNv = ""; luongTxt = ""; thuongTxt = "";
            luong = 0; thuong = 0;
        }
    }
}
