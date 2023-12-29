using Nhuan_381.Models;
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

namespace Nhuan_381
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLNhanSuContext db = new QLNhanSuContext();
        public MainWindow()
        {
            InitializeComponent();
            inputBirthday.SelectedDate = DateTime.Now;
            renderDepartments();
            renderEmployees();




        }

        private void renderDepartments()
        {
            var departments = from dp in db.PhongBans select dp;

            inputDepartment.ItemsSource = departments.ToList();
            inputDepartment.DisplayMemberPath = "TenPb";
            inputDepartment.SelectedValuePath = "MaPb";
            inputDepartment.SelectedIndex = 0;
        }

        private List<Render> getDataRender()
        {
            var render = from nv in db.NhanViens
                         join pb in db.PhongBans on nv.MaPbNavigation equals pb
                         select new Render
                         {
                             MaNv = nv.MaNv,
                             HoTen = nv.HoTen,
                             NgaySinh = nv.NgaySinh,
                             Gioitinh = nv.Gioitinh,
                             NgoaiNgu = nv.NgoaiNgu,
                             MaPb = nv.MaPb,
                             TenPb = pb.TenPb,
                         };
            return render.ToList<Render>();
        }

        private void renderEmployees()
        {
            renderData.ItemsSource = getDataRender();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validate() == true && validateId() == true)
            {
                NhanVien nv = new NhanVien();
                nv.MaNv = inputId.Text.Trim();
                nv.HoTen = inputName.Text.Trim();
                nv.NgaySinh = inputBirthday.SelectedDate;
                nv.Gioitinh = radMale.IsChecked == true ? "Nam" : "Nữ";
                List<string> lang = new List<string>();
                if (chkViet.IsChecked == true) lang.Add("Việt");
                if (chkFran.IsChecked == true) lang.Add("Pháp");
                if (chkEng.IsChecked == true) lang.Add("Anh");
                nv.NgoaiNgu = string.Join(",", lang.ToArray());
                PhongBan pb = (PhongBan)inputDepartment.SelectedItem;
                nv.MaPb = pb.MaPb;

                db.NhanViens.Add(nv);
                db.SaveChanges();
                renderEmployees();
                clearData();
            }
        }

        private bool validate()
        {
            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ tên không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                inputName.Text = string.Empty;
                inputName.Focus();
                return false;
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã nhân viên không tồn tại!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (validate() == true)
            {
                NhanVien nv = (NhanVien)db.NhanViens.FirstOrDefault(x => x.MaNv.Equals(inputId.Text.Trim()));
                nv.HoTen = inputName.Text.Trim();
                nv.NgaySinh = inputBirthday.SelectedDate;
                nv.Gioitinh = radMale.IsChecked == true ? "Nam" : "Nữ";
                List<string> lang = new List<string>();
                if (chkViet.IsChecked == true) lang.Add("Việt");
                if (chkFran.IsChecked == true) lang.Add("Pháp");
                if (chkEng.IsChecked == true) lang.Add("Anh");
                nv.NgoaiNgu = string.Join(",", lang.ToArray());
                PhongBan pb = (PhongBan)inputDepartment.SelectedItem;
                nv.MaPb = pb.MaPb;
                db.SaveChanges();
                renderEmployees();
                clearData();
            }
        }

        private bool validateId()
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Text = string.Empty;
                inputId.Focus();
                return false;
            }
            else
            {
                var findById = db.NhanViens.FirstOrDefault(x => x.MaNv.Equals(inputId.Text.Trim()));
                if (findById != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    inputId.Text = string.Empty;
                    inputId.Focus();
                    return false;
                }
            }

            return true;
        }

        private void selection_changed(object sender, SelectionChangedEventArgs e)
        {
            if (renderData.SelectedItem != null)
            {
                Render nv = (Render)renderData.SelectedItem;
                inputId.Text = nv.MaNv;
                inputName.Text = nv.HoTen;
                inputBirthday.SelectedDate = nv.NgaySinh;
                if (nv.Gioitinh.Equals("Nam")) radMale.IsChecked = true;
                else radFemale.IsChecked = true;

                if (nv.NgoaiNgu.Contains("Việt")) chkViet.IsChecked = true;
                else chkViet.IsChecked = false;
                if (nv.NgoaiNgu.Contains("Pháp")) chkFran.IsChecked = true;
                else chkFran.IsChecked = false;

                if (nv.NgoaiNgu.Contains("Anh")) chkEng.IsChecked = true;
                else chkEng.IsChecked = false;

                inputDepartment.SelectedValue = nv.MaPb;
                inputId.IsReadOnly = true;
            }
        }

        private void clearData()
        {
            inputId.Text = string.Empty;
            inputDepartment.SelectedIndex = 0;
            inputBirthday.SelectedDate = DateTime.Now;
            inputName.Text = string.Empty;
            radMale.IsChecked = true;
            chkViet.IsChecked = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (renderData.SelectedItem != null)
            {
                MessageBoxResult res = MessageBox.Show("Chắc chắn muốn xóa?", "Thông báo!", MessageBoxButton.YesNoCancel);

                if (res == MessageBoxResult.Yes)
                {
                    Render nv = (Render)renderData.SelectedItem;
                    NhanVien dnv = db.NhanViens.FirstOrDefault(x => x.MaNv.Equals(nv.MaNv));
                    db.NhanViens.Remove(dnv);
                    db.SaveChanges();
                    renderEmployees();
                    clearData();
                }


            }
            else
            {
                MessageBox.Show("Nhân sự không tồn tại!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
