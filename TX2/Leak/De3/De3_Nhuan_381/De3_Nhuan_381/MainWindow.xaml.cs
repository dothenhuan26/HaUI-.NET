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

namespace De3_Nhuan_381
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employees = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                Employee employee = new Employee();
                employee.Id = inputId.Text.Trim();
                employee.Fullname = inputName.Text.Trim();
                employee.Gender = (radMale.IsChecked == true) ? "Nam" : "Nữ";
                employee.Price = double.Parse(inputPrice.Text.Trim());
                employees.Add(employee);

                renderData.ItemsSource = null;

                renderData.ItemsSource = employees;
            }

        }

        private bool validate()
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                var findId = employees.SingleOrDefault(employee => employee.Id == inputId.Text.Trim());
                if (findId != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ tên không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (inputPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số tiền bán hàng không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                double price;
                bool flag;
                flag = double.TryParse(inputPrice.Text, out price);
                if (!flag)
                {
                    MessageBox.Show("Số tiền bán hàng phải là số!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (price < 0)
                {
                    MessageBox.Show("Số tiền bán hàng phải lớn hơn 0!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var max = employees.Max(employee => employee.Price);
            Window2 window2 = new Window2();
            var emps = employees.Where(employee => employee.Price == max);
            window2.render2.ItemsSource = emps;
            window2.Show();
        }
    }
}
