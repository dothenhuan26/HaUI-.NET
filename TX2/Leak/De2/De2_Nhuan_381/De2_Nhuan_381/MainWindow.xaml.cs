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

namespace De2_Nhuan_381
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> customers = new List<Customer>();
        public MainWindow()
        {
            InitializeComponent();
            inputDate.SelectedDate = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validate() == true)
            {
                Customer customer = new Customer();
                customer.Fullname = inputName.Text;
                customer.Date = (DateTime)inputDate.SelectedDate;
                customer.Amount = int.Parse(inputAmount.Text);
                customers.Add(customer);
                renderData.ItemsSource = null;
                renderData.ItemsSource = customers;
            }
        }

        private bool validate()
        {
            if (inputName.Text.Length == 0)
            {
                MessageBox.Show("Họ tên không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if ((DateTime)inputDate.SelectedDate != DateTime.Now.Date)
            {
                MessageBox.Show("Ngày mua phải là ngày hiện tại của hệ thống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (inputAmount.Text.Length == 0)
            {
                MessageBox.Show("Số lượng mua không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                int amount;
                bool flag;
                flag = int.TryParse(inputAmount.Text, out amount);
                if (!flag)
                {
                    MessageBox.Show("Số lượng mua phải là kiểu số!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (amount < 10 || amount > 20)
                {
                    MessageBox.Show("Số lượng mua phải là số nguyên trong khoảng 10-20!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Customer customer = customers.LastOrDefault();
            Window2 window2 = new Window2();
            window2.resName.Text = customer.Fullname;
            window2.resDate.SelectedDate = customer.Date;
            window2.resAmount.Text = customer.Amount + "";
            window2.resTotal.Text = customer.Total + "";
            window2.Show();

        }
    }
}
