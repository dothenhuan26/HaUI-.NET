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

namespace De1_Nhun_381
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validate() == true)
            {
                Customer customer = new Customer();
                customer.Fullname = inputName.Text;
                if (radMale.IsChecked == true)
                {
                    customer.Gender = "Nam";
                }
                else
                {
                    customer.Gender = "Nữ";
                }
                customer.Amount = int.Parse(inputAmount.Text);
                customer.Price = double.Parse(inputPrice.Text);
                customers.Add(customer);
                renderData.ItemsSource = null;

                renderData.ItemsSource = customers;
            }
        }

        private bool validate()
        {
            bool flag;
            if (inputName.Text.Length == 0)
            {
                MessageBox.Show("Tên không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (inputAmount.Text.Length == 0)
            {
                MessageBox.Show("Số lượng không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                int amount;
                flag = int.TryParse(inputAmount.Text, out amount);
                if (flag == true)
                {
                    if (amount <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng phải là số nguyên!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (inputPrice.Text.Length == 0)
            {
                MessageBox.Show("Đơn giá không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                double price;
                flag = double.TryParse(inputPrice.Text, out price);
                if (flag == true)
                {
                    if (price <= 0)
                    {
                        MessageBox.Show("Đơn giá phải lớn hơn 0!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Đơn giá phải là số thực!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Customer> customers2 = new List<Customer>();

            foreach(Customer customer in renderData.SelectedItems)
            {
                customers2.Add(customer);
            }


            Window2 window2 = new Window2();
            window2.render2.ItemsSource = customers2;
            window2.Show(); 
        }
    }
}
