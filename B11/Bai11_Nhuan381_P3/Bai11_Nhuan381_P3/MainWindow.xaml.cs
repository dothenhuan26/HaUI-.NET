using Bai11_Nhuan381_P3.Models;
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

namespace Bai11_Nhuan381_P3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Render> renders = new List<Render>();
        QLBanHangContext db = new QLBanHangContext();
        public MainWindow()
        {
            InitializeComponent();


        }

        public void render()
        {
            //foreach (var sp in db.SanPhams)
            //{
            //    Render render = new Render();
            //    render.MaSp = sp.MaSp;
            //    render.TenSp = sp.TenSp;
            //    render.SoLuong = sp.SoLuong;
            //    render.DonGia = sp.DonGia;
            //    if (sp.MaLoaiNavigation != null)
            //        render.TenLoai = sp.MaLoaiNavigation?.TenLoai;
            //    renders.Add(render);
            //}

            listData.ItemsSource = db.LoaiSanPhams.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            render();
        }
    }
}
