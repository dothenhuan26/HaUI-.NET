using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
using TH.Model;

namespace TH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLBanHangContext db = new QLBanHangContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderData();
        }

        private void RenderData()
        {
            var renderQuery = from sp in db.SanPhams
                              orderby sp.DonGia ascending
                              select new Render
                              {
                                  MaSp = sp.MaSp,
                                  TenSp = sp.TenSp,
                                  DonGia = sp.DonGia,
                                  SoLuongCo = sp.SoLuongCo,
                                  MaLoai = sp.MaLoai,
                              };

            var renderCombobox = from lsp in db.LoaiSps select lsp;

            renderData.ItemsSource = renderQuery.ToList();
            inputType.ItemsSource = renderCombobox.ToList();
            inputType.DisplayMemberPath = "TenLoai";
            inputType.SelectedValuePath = "MaLoai";
            inputType.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validateId() && validate())
            {
                SanPham sp = new SanPham();
                sp.MaSp = inputId.Text.Trim();
                sp.TenSp = inputName.Text.Trim();
                sp.DonGia = int.Parse(inputPrice.Text.Trim());
                sp.SoLuongCo = int.Parse(inputAmount.Text.Trim());
                sp.MaLoai = inputType.SelectedValue.ToString();
                db.SanPhams.Add(sp);
                db.SaveChanges();
                RenderData();
                clearInput();
            }
            else
            {

            }
        }

        private void clearInput()
        {
            inputId.IsReadOnly = false;
            inputId.Text = "";
            inputName.Text = "";
            inputPrice.Text = "";
            inputAmount.Text = "";
            inputType.SelectedIndex = 0;
        }


        private bool validateId()
        {

            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Focus();
                return false;
            }
            var sp = db.SanPhams.FirstOrDefault(x => x.MaSp == inputId.Text.Trim());
            if (sp != null)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                inputId.Text = "";
                inputId.Focus();
                return false;
            }
            return true;
        }

        private bool validate()
        {

            if (inputName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                inputName.Focus();
                return false;
            }
            if (inputPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Đơn giá không được để trống!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                inputPrice.Focus();
                return false;
            }
            int inputInt;
            bool flag;
            flag = int.TryParse(inputPrice.Text.Trim(), out inputInt);
            if (!flag)
            {
                MessageBox.Show("Đơn giá phải là số nguyên!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                inputPrice.Text = "";
                inputPrice.Focus();
                return false;
            }
            else if (inputInt <= 0)
            {
                {
                    MessageBox.Show("Đơn giá phải lớn hơn 0!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                    inputPrice.Text = "";
                    inputPrice.Focus();
                    return false;
                }
            }
            if (inputAmount.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số lượng có không được để trống!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                inputAmount.Focus();
                return false;
            }
            flag = int.TryParse(inputAmount.Text.Trim(), out inputInt);
            if (!flag)
            {
                MessageBox.Show("Số lượng có phải là số nguyên!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                inputAmount.Text = "";
                inputAmount.Focus();
                return false;
            }
            else if (inputInt <= 0)
            {
                {
                    MessageBox.Show("Số lượng có phải lớn hơn 0!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                    inputAmount.Text = "";
                    inputAmount.Focus();
                    return false;
                }
            }
            return true;
        }

        private void renderData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (renderData.SelectedItem != null)
            {
                try
                {
                    var render = (Render)renderData.SelectedItem;
                    inputId.Text = render.MaSp;
                    inputName.Text = render.TenSp;
                    inputPrice.Text = render.DonGia + "";
                    inputAmount.Text = render.SoLuongCo + "";
                    inputType.SelectedValue = render.MaLoai;
                    inputId.IsReadOnly = true;
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var sp = db.SanPhams.FirstOrDefault(x => x.MaSp == inputId.Text.Trim());
            if (sp != null)
            {
                if (validate())
                {
                    sp.TenSp = inputName.Text.Trim();
                    sp.DonGia = int.Parse(inputPrice.Text.Trim());
                    sp.SoLuongCo = int.Parse(inputAmount.Text.Trim());
                    sp.MaLoai = inputType.SelectedValue.ToString();
                    db.SaveChanges();
                    RenderData();
                    clearInput();
                }
                else { return; }
            }
            else
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (inputId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var sp = db.SanPhams.SingleOrDefault(x => x.MaSp == inputId.Text.Trim());
            var cthds = from cthd in db.ChiTietHoaDons where cthd.MaSp == inputId.Text.Trim() select cthd;

            MessageBoxResult rs = MessageBox.Show("Chắc chắn xóa?", "Xác nhận xóa", MessageBoxButton.YesNoCancel);

            if (rs == MessageBoxResult.Yes)
            {
                foreach (var cthd in cthds)
                {
                    if (cthd != null)
                    {
                        db.ChiTietHoaDons.Remove(cthd);
                    }

                }
                if (sp != null)
                {
                    db.SanPhams.Remove((SanPham)sp);
                    db.SaveChanges();
                    RenderData();
                    clearInput();
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại!", "INVALID", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            var query = from sp in db.SanPhams
                        select new
                        {
                            MaSp = sp.MaSp,
                            TenSp = sp.TenSp,
                            TenLoai = sp.MaLoaiNavigation.TenLoai,
                            SoLuongDaBan = sp.ChiTietHoaDons.Sum(x => x.SoLuongMua),
                            TongTien = sp.ChiTietHoaDons.Sum(x => x.SoLuongMua) * sp.DonGia

                        };
            window1.renderData2.ItemsSource = query.ToList();

            window1.Show();
        }
    }
}
