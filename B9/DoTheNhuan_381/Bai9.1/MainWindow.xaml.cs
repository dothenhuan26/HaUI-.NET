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

namespace Bai9._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<String> list = new List<string>() { "Đảm bảo chất lượng phần mềm", "Giai thuật di truyền và ứng dụng", "Hệ chuyên gia", "Lập trình căn bản" };
            InitializeComponent();
            foreach (var item in list)
            {
                listL.Items.Add(item);
            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listR.Items.Add(listL.SelectedItem);
            listL.Items.Remove(listL.SelectedItem);
        }

        private void LtrAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in listL.Items)
            {
                listR.Items.Add(item);
            }
            listL.Items.Clear();
        }

        private void Rtl_Click(object sender, RoutedEventArgs e)
        {
            listL.Items.Add(listR.SelectedItem);
            listR.Items.Remove(listR.SelectedItem);
        }

        private void RtlAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in listR.Items)
            {
                listL.Items.Add(item);
            }
            listR.Items.Clear();
        }
    }
}
