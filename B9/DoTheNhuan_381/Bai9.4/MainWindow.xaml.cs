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

namespace Bai9._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int resOldIndex = 0;
        static int resTotalIndex = 0;
        static int resInQuota = 50;
        static int resOutQuota = 0;
        static int resTotal = 0;
        static int resNewIndex = 0;
        static string resName = "";
        public MainWindow()
        {
            InitializeComponent();
            setInitialize();
        }

        public void setInitialize()
        {
            oldIndex.Text = "0";
            inQuota.Text = "" + resInQuota;
        }

        public void setAfterCalc()
        {
            resOldIndex = resNewIndex;
            oldIndex.Text = "" + resOldIndex;
            resTotalIndex = 0;
            resOutQuota = 0;
            resTotal = 0;
            resNewIndex = 0;
            resName = "";
            //totalIndex.Text = "";
            //outQuota.Text = "";
        }

        private void calc_Click(object sender, RoutedEventArgs e)
        {
            resNewIndex = int.Parse(newIndex.Text);
            resTotalIndex = resNewIndex - resOldIndex;
            if (resTotalIndex > resInQuota)
            {
                resOutQuota = resTotalIndex - resInQuota;
                resTotal += resOutQuota * 1000 + 500 * resInQuota;
            }
            else
            {
                resTotal = resTotalIndex * 500;
            }
            total.Text = ""+resTotal;
            totalIndex.Text = "" + resTotalIndex;
            outQuota.Text = "" + resOutQuota;

            result.Items.Add(name.Text);
            result.Items.Add("Số kw tiêu thụ: " + resTotalIndex);
            result.Items.Add("Tổng tiền: " + resTotal);
            setAfterCalc();
        }
    }
}
