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

namespace De5_Nhuan_381
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
            if (validate() == true)
            {
                Employee employee = new Employee();
                employee.Fullname = inputName.Text.Trim();
                employee.Gender = radMale.IsChecked == true ? "Nam" : "Nữ";
                employee.Amount = int.Parse(inputAmount.Text.Trim());
                employees.Add(employee);
                renderData.ItemsSource = null;
                renderData.ItemsSource = employees;
            }
        }

        private bool validate()
        {
            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ tên không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            } else
            {
                var emp = employees.FirstOrDefault(x => x.Fullname.Equals(inputName.Text));
                if(emp != null)
                {
                    MessageBox.Show("Họ tên không được trùng nhau!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            if (inputAmount.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số ngày làm việc không được để trống!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                int amount;
                bool flag;
                flag = int.TryParse(inputAmount.Text.Trim(), out amount);
                if (!flag)
                {
                    MessageBox.Show("Số ngày làm việc phải là số nguyên!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (amount < 0 || amount > 20)
                {
                    MessageBox.Show("Số ngày làm việc phải nằm trong khoảng 0-20!", "INVALID DATA", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();

            Employee emp = null;

            foreach (var item in renderData.SelectedItems)
            {
                emp = (Employee)item;
            }
            window2.resAmount.Text = emp.Amount + "";
            window2.resName.Text = emp.Fullname;
            if (emp.Gender.Equals("Nam"))
            {
                window2.radResMale.IsChecked = true;
            }
            else
            {
                window2.radResFemale.IsChecked = true;
            }
            window2.Show();
        }
    }
}
