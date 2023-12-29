using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;
using Path = System.IO.Path;

namespace Bai9._5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Order> list = new List<Order>();
        static string absPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        static List<string> isChoosed = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            list.Add(new Order("1", "Nước cam tươi", absPath + "images\\cafe.jpg"));
            list.Add(new Order("2", "Nước ép kiwi", absPath + "images\\kiwi.jpg"));
            list.Add(new Order("3", "Nước soài ép", absPath + "images\\mango.jpg"));
            list.Add(new Order("4", "Sữa tươi", absPath + "images\\milk.jpg"));
            list.Add(new Order("5", "Cà phê", absPath + "images\\orange.jpg"));

            orders.ItemsSource = list;
        }

        public void handleOrder_Click(object sender, RoutedEventArgs e)
        {
            string res = "";
            res += String.Join(", ", isChoosed);
            MessageBox.Show(res);
            isChoosed.Clear();



        }

        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            StackPanel st = (StackPanel)checkBox.Parent;
            Label lb = st.Children.OfType<Label>().FirstOrDefault();
            if (lb != null)
            {
                isChoosed.Add(lb.Content + "");
            }

        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            StackPanel st = (StackPanel)checkBox.Parent;
            Label lb = st.Children.OfType<Label>().FirstOrDefault();
            if (lb != null)
            {
                string res = lb.Content + "";
                isChoosed.Remove(res);
            }
        }
    }
}
