using StanDysków.Models;
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
using System.Windows.Shapes;

namespace StanDysków
{
    /// <summary>
    /// Logika interakcji dla klasy DBwindow.xaml
    /// </summary>
    public partial class DBwindow : Window
    {
        public DBwindow()
        {
            InitializeComponent();
        }
        public void dataLin()
        {
            Data_grid.ItemsSource = SqliteDataAccess.LoadLinux();
        }
        public void dataWin()
        {
            List<WindowsModel>xx= SqliteDataAccess.LoadWindows();
            Data_grid.ItemsSource = xx;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataWin();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            dataLin();
        }
    }
}
