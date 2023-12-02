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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoBai9_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //tạo 1 danh sách mà các phần tử là Nhân viên
            List<NhanVien> dsNhanVien = new List<NhanVien>()
            {
                new NhanVien(){HoTen="An", GioiTinh="Nam",NgaySinh=DateTime.Today,
                        NgoaiNgu="Anh",PhongBan="Tổ chức"},
                 new NhanVien(){HoTen="Hòa", GioiTinh="Nam",NgaySinh=DateTime.Today,
                        NgoaiNgu="Anh",PhongBan="Tổ chức"},
                  new NhanVien(){HoTen="Thủy", GioiTinh="Nữ",NgaySinh=DateTime.Today,
                        NgoaiNgu="Trung",PhongBan="Tổ chức"}
            };
            //hiển thị danh sách nhân viên lên datagrid
            dtgNhanVien.ItemsSource = dsNhanVien;
        }

        

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
           var tl= MessageBox.Show("Bạn muốn kết thúc chương trình?", "Exit", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            //nếu user kích vào yes thì đóng window
            if(tl==MessageBoxResult.Yes)
                Close();
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {//phương thức xử lý sự kiện user kích chuột vào nút lệnh window 2
            //tạo thể hiện của cửa sổ 2
            Window2 w2 = new Window2();
            //show cửa sổ 2
            w2.Show();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string nn = "";
            //tạo một nhân viên mới
            NhanVien nvMoi = new NhanVien();
            nvMoi.HoTen = txtHoTen.Text;
            nvMoi.NgaySinh =(DateTime) dtpNgaySinh.SelectedDate;
            if (radNam.IsChecked == true)
                nvMoi.GioiTinh = "Nam";
            else
                nvMoi.GioiTinh = "Nữ";
            //xác định ngoại ngữ
            if (chkAnh.IsChecked == true)
                nn = "Anh";
            if (chkPhap.IsChecked == true)
                nn += ", Pháp";
            if (chkTrung.IsChecked == true)
                nn += ", Trung";
            nvMoi.NgoaiNgu = nn;
            nvMoi.PhongBan = cboPhongBan.Text;
        }
    }
    class NhanVien
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string NgoaiNgu { get; set; }
        public string  PhongBan { get; set; }

    }
}
