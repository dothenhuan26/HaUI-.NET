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

namespace De4_Nhuan_381
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
                customer.Fullname = inputName.Text.Trim();
                customer.Date = (DateTime)inputDate.SelectedDate;
                customer.Amount = int.Parse(inputAmount.Text);
                customers.Add(customer);
                renderData.ItemsSource = null;
                renderData.ItemsSource = customers;
            }
        }



        private bool validate()
        {
            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ tên không được để trống!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if ((DateTime)inputDate.SelectedDate > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày tuyển dụng phải trước ngày hiện tại!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var bon = customers.Max(x => x.Bonus);

            Window2 window2 = new Window2();
            var list = customers.Where(cus => cus.Bonus == bon);
            window2.render2.ItemsSource = list;
            window2.Show();
        }
    }
}
