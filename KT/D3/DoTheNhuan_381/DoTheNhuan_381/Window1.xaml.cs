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
using System.Windows.Shapes;

namespace DoTheNhuan_381
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            QLNhanvienContext db = new QLNhanvienContext();
            var query = from nv in db.Nhanviens
                        group nv by nv.MaPhong into PBGR
                        select new { Maphong = PBGR.Key, TongLuong = PBGR.Sum(x => x.Luong), SoLuongNV = PBGR.Count() };

            var query2 = from pb in query
                         join nv in db.PhongBans on pb.Maphong equals nv.MaPhong
                         select new
                         {
                             nv.MaPhong,
                             nv.TenPhong,
                             pb.TongLuong,
                             pb.SoLuongNV,
                         };
            listPb.ItemsSource = query2.ToList();
        }
    }
}
