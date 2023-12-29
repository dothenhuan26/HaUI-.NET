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

namespace Bai9._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string resName = "Họ tên: ";
        static string resGender = "Gioi tính: ";
        static string resMarried = "Tình trạng hôn nhân: ";
        static string resFavorite = "Sở thích: ";
        static List<string> favorites = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void resetRes()
        {
            resName = "Họ tên: ";
            resGender = "Gioi tính: ";
            resMarried = "Tình trạng hôn nhân: ";
            resFavorite = "Sở thích: ";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            result.Items.Clear();
            if (name.Text.Length <= 0)
            {
                MessageBox.Show("Bắt buộc phải nhập tên!");
                return;
            }
            resName += name.Text;
            resGender += (male.IsChecked == true) ? "Nam" : "Nữ";
            resMarried += (isMarried.IsChecked == true) ? "Đã kết hôn" : "Chưa kết hôn";
            if (football.IsChecked == true) favorites.Add("Bóng đá");
            if (swimming.IsChecked == true) favorites.Add("Bơi lội");
            if (music.IsChecked == true) favorites.Add("Âm nhạc");
            if (climbing.IsChecked == true) favorites.Add("Leo núi");
            resFavorite += String.Join(", ", favorites);

            result.Items.Add(resName);
            result.Items.Add(resGender);
            result.Items.Add(resMarried);
            result.Items.Add(resFavorite);
            resetRes();
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
