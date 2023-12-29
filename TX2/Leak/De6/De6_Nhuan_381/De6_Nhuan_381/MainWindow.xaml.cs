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

namespace De6_Nhuan_381
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.Id = inputId.Text.Trim();
            student.Birthday = (DateTime)inputBirthday.SelectedDate;
            student.Area = inputArea.Text;
            students.Add(student);
            renderData.ItemsSource = null;
            renderData.ItemsSource = students;
        }

        private bool validate()
        {
            if (inputId.Text.Trim().Length==0)
            {

            }

                return true;
        }

    }
}
