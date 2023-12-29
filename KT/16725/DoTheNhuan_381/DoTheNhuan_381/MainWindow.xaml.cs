using DoTheNhuan_381.Models;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace DoTheNhuan_381
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLBenhNhanContext db = new QLBenhNhanContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderData();
            var query = from kk in db.KhoaKhams select kk;
            inputDepartment.ItemsSource = query.ToList();
            inputDepartment.SelectedValuePath = "Makhoa";
            inputDepartment.DisplayMemberPath = "Tenkhoa";
            inputDepartment.SelectedIndex = 0;
        }

        private void RenderData()
        {
            var query = from bn in db.BenhNhans
                        where bn.SongayNv <= 20
                        select new
                        {
                            Mabn = bn.Mabn,
                            Hoten = bn.Hoten,
                            Makhoa = bn.Makhoa,
                            Diachi = bn.Diachi,
                            SongayNv = bn.SongayNv,
                            VienPhi = bn.SongayNv * 60000,
                        };

            renderData.ItemsSource = query.ToList();
        }

        private void clearInput()
        {
            inputId.Clear();
            inputId.IsReadOnly = false;
            inputName.Clear();
            inputAddress.Clear();
            inputDays.Clear();
            inputDepartment.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validateId() && validate())
            {
                BenhNhan bn = new BenhNhan();
                bn.Mabn = inputId.Text.Trim();
                bn.Hoten = inputName.Text.Trim();
                bn.Diachi = inputAddress.Text.Trim();
                bn.Makhoa = inputDepartment.SelectedValue.ToString();
                bn.SongayNv = int.Parse(inputDays.Text.Trim());
                db.BenhNhans.Add(bn);
                db.SaveChanges();
                RenderData();
                clearInput();
            }
        }

        private bool validateId()
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã bệnh nhân không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Focus();
                return false;
            }
            var bn = db.BenhNhans.FirstOrDefault(x => x.Mabn == inputId.Text.Trim());
            if (bn != null)
            {
                MessageBox.Show("Mã bệnh nhân đã tồn tại!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Clear();
                inputId.Focus();
                return false;
            }
            return true;
        }

        private bool validate()
        {
            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Họ tên bệnh nhân không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputName.Focus();
                return false;
            }
            if (inputAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Địa chỉ của bệnh nhân không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputAddress.Focus();
                return false;
            }
            if (inputDays.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số ngày nằm viện của bệnh nhân không được để trống!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputDays.Focus();
                return false;
            }

            int inputInt;
            bool flag;
            flag = int.TryParse(inputDays.Text.Trim(), out inputInt);
            if (!flag || inputInt <= 0)
            {
                MessageBox.Show("Số ngày nằm viện của bệnh nhân phải là số nguyên và lớn hơn 0!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                inputDays.Clear();
                inputDays.Focus();
                return false;
            }

            return true;
        }

        private void renderData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (renderData.SelectedValue != null)
            {
                Type t = renderData.SelectedValue.GetType();
                PropertyInfo[] bn = t.GetProperties();
                inputId.Text = bn[0].GetValue(renderData.SelectedValue).ToString();
                inputId.IsReadOnly = true;
                inputName.Text = bn[1].GetValue(renderData.SelectedValue).ToString();
                inputDepartment.SelectedValue = bn[2].GetValue(renderData.SelectedValue).ToString();
                inputAddress.Text = bn[3].GetValue(renderData.SelectedValue).ToString();
                inputDays.Text = bn[4].GetValue(renderData.SelectedValue).ToString();
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var bn = db.BenhNhans.FirstOrDefault(x => x.Mabn == inputId.Text.Trim());
            if (bn != null)
            {
                if (validate())
                {
                    bn.Hoten = inputName.Text.Trim();
                    bn.Diachi = inputAddress.Text.Trim();
                    bn.Makhoa = inputDepartment.SelectedValue.ToString();
                    bn.SongayNv = int.Parse(inputDays.Text.Trim());
                    db.SaveChanges();
                    RenderData();
                    clearInput();
                    return;
                }
                return;
            }
            else
            {
                MessageBox.Show("Không tồn tại bệnh nhân!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var bn = db.BenhNhans.FirstOrDefault(x => x.Mabn == inputId.Text.Trim());
            if (bn != null)
            {
                MessageBoxResult rs = MessageBox.Show("Xác nhận xóa?", "Xóa bệnh nhân", MessageBoxButton.YesNoCancel);
                if (rs == MessageBoxResult.Yes)
                {
                    db.BenhNhans.Remove(bn);
                    db.SaveChanges();
                    RenderData();
                    clearInput();
                }

                return;
            }
            else
            {
                MessageBox.Show("Không tồn tại bệnh nhân!", "INVALID!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();

            var query = from kk in db.KhoaKhams
                        select new
                        {
                            kk.Makhoa,
                            kk.Tenkhoa,
                            TongVienPhi = kk.BenhNhans.Sum(x => x.SongayNv * 60000),
                        };

            window1.renderData2.ItemsSource = query.ToList();

            window1.Show();
        }
    }
}
