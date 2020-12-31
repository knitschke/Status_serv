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
using EAGetMail;
using StanDysków;

namespace StanDysków
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            Functions a = new Functions();
            a.ScanAndAdd(Mail.Text.ToString(), Pswd.Password.ToString());
            MessageBox.Show("Zakończono dodawanie maili");
        }

        private void Database_Click(object sender, RoutedEventArgs e)
        {
            DBwindow ls = new DBwindow();
            this.Close();
            ls.Show();
        }
    }
}
