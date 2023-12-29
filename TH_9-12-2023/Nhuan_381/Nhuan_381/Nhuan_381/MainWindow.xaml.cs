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
        }

        private void renderData()
        {
            var data = from render in db.NhanViens
                       select new
                       {
                           MaNv = render.MaNv,
                           HoTen = render.HoTen,
                           NgaySinh = render.NgaySinh,
                           GioiTinh = render.Gioitinh,
                           NgoaiNgu = render.NgoaiNgu,
                           MaPb = render.MaPb,
                           TenPb = render.MaPbNavigation.TenPb
                       };
            render.ItemsSource = data.ToList();

            inputDepartment.ItemsSource = (from dp in db.PhongBans select dp).ToList();
            inputDepartment.DisplayMemberPath = "TenPb";
            inputDepartment.SelectedValuePath = "MaPb";
            inputDepartment.SelectedIndex = 0;
        }

        private void clearInput()
        {
            inputId.Text = "";
            inputName.Text = "";
            inputBirthday.SelectedDate = DateTime.Now;
            radMale.IsChecked = true;
            inputEl.IsChecked = false;
            inputCn.IsChecked = false;
            inputFr.IsChecked = false;
            inputDepartment.SelectedIndex = 0;
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            renderData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNv = inputId.Text.Trim();
            nv.HoTen = inputName.Text.Trim();
            nv.NgaySinh = inputBirthday.SelectedDate;
            nv.Gioitinh = radMale.IsChecked == true ? "Nam" : "Nữ";

            List<string> langs = new List<string>();
            if (inputEl.IsChecked == true) langs.Add("Anh");
            if (inputFr.IsChecked == true) langs.Add("Pháp");
            if (inputCn.IsChecked == true) langs.Add("Trung");
            nv.NgoaiNgu = string.Join(",", langs);
            
            PhongBan pb = (PhongBan)inputDepartment.SelectedItem;
            nv.MaPb = pb.MaPb;
            db.NhanViens.Add(nv);
            db.SaveChanges();
            renderData();
            clearInput();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNv.Equals(inputId.Text));

            nv.HoTen = inputName.Text.Trim();
            nv.NgaySinh = inputBirthday.SelectedDate;
            nv.Gioitinh = radMale.IsChecked == true ? "Nam" : "Nữ";

            List<string> langs = new List<string>();
            if (inputEl.IsChecked == true) langs.Add("Anh");
            if (inputFr.IsChecked == true) langs.Add("Pháp");
            if (inputCn.IsChecked == true) langs.Add("Trung");
            nv.NgoaiNgu = string.Join(",", langs);
            PhongBan pb = (PhongBan)inputDepartment.SelectedItem;
            nv.MaPb = pb.MaPb;
            db.SaveChanges();
            renderData();
            clearInput();
        }

        private void nonValid()
        {
            if(inputName.Text.Trim().Length==0)
            {
                MessageBox.Show("Họ tên không được để trống!", "INVALID INPUT DATA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (inputBirthday.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ngày sinh không được để trống!", "INVALID INPUT DATA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
