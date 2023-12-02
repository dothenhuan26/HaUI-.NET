using DemoEFCore.Models;
using Microsoft.EntityFrameworkCore;
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

namespace DemoEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static QLBanHangContext db = new QLBanHangContext();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Re_Render();
        }

        private void Re_Render()
        {
            var query = from sp in db.LoaiSanPhams select sp;

            products.ItemsSource = query.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputNameTxt = inputName.Text.Trim();
            string inputIdTxt = inputId.Text.Trim();

            if (inputNameTxt.Length == 0)
            {
                MessageBox.Show("Name is required!");
                inputName.Focus();
                return;
            }

            if (inputIdTxt.Length == 0)
            {
                MessageBox.Show("Id is required!");
                inputId.Focus();
                return;
            }

            var findSp = from findsp in db.LoaiSanPhams where findsp.MaLoai == inputIdTxt select findsp;

            if (findSp.ToList().Count() > 0)
            {
                MessageBox.Show("Id is Exists!");
                inputId.Focus();
                return;
            }

            LoaiSanPham sp = new LoaiSanPham();
            sp.MaLoai = inputIdTxt;
            sp.TenLoai = inputNameTxt;
            db.LoaiSanPhams.Add(sp);
            db.SaveChanges();
            Re_Render();
            inputId.Text = "";
            inputName.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string inputNameTxt = inputName.Text.Trim();
            string inputIdTxt = inputId.Text.Trim();

            if (inputNameTxt.Length == 0)
            {
                MessageBox.Show("Name is required!");
                inputName.Focus();
                return;
            }
            if (inputIdTxt.Length == 0)
            {
                MessageBox.Show("Id is required!");
                inputId.Focus();
                return;
            }
            var findSp = from findsp in db.LoaiSanPhams where findsp.MaLoai == inputIdTxt select findsp;
            findSp.First().TenLoai = inputNameTxt;
            db.SaveChanges();
            Re_Render();
            inputId.Text = "";
            inputName.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string inputIdTxt = inputId.Text.Trim();

            if (inputIdTxt.Length == 0)
            {
                MessageBox.Show("Id is required!");
                inputId.Focus();
                return;
            }

            var findSp = from findsp in db.LoaiSanPhams where findsp.MaLoai == inputIdTxt select findsp;

            db.LoaiSanPhams.Remove(findSp.First());

            db.SaveChanges();
            Re_Render();
            inputId.Text = "";
            inputName.Text = "";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
