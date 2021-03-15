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
        public string os = "";
        public int beg = 0;
        public int end = 0;
        public string serw = "";
        public string wol = "";
        public int proc_wolnej = 0;

        public DBwindow()
        {
            InitializeComponent();
        }
        public void reset()
        {
            Serv_filter.Text = "";
            Wolumen_filter.Text = "";
            Zajetosc_filter.Text = "";
            Date_range1.Text = "";
            Date_range2.Text = "";
        }
        public void dataLin()
        {
            reset();
            Data_grid.ItemsSource = SqliteDataAccess.LoadLinux();
            os = "lin";
        }
        public void dataWin()
        {
            reset();
            List<WindowsModel>xx= SqliteDataAccess.LoadWindows();
            Data_grid.ItemsSource = xx;
            os = "win";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataWin();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            dataLin();
        }

        private void Serv_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            serw = Serv_filter.Text;
            try
            {
                if (os == "win")
                {

                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateWin(serw, wol, proc_wolnej, beg, end);
                }
                if (os == "lin")
                {

                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateLin(serw, wol, proc_wolnej, beg, end);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Wolumen_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            wol = Wolumen_filter.Text;
            try
            {
                if (os == "win")
                {

                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateWin(serw, wol, proc_wolnej, beg, end);
                }
                if (os == "lin")
                {

                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateLin(serw, wol, proc_wolnej, beg, end);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Zajetosc_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                proc_wolnej = Int32.Parse(Zajetosc_filter.Text);
            }
            catch (Exception)
            {

                proc_wolnej = 0;
            }

            try
            {
                if (os == "win")
                {
                    
                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateWin(serw, wol, proc_wolnej, beg, end);
                }
                if (os == "lin")
                {
                   
                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateLin(serw, wol, proc_wolnej, beg, end);
                }
            }
            catch (Exception)
            {
            }

        }

        private void Date_range2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (os == "win")
                {
                    List<WindowsModel> xx = SqliteDataAccess.LoadDateIDWin(Date_range2.Text);
                    end = xx.Last().Id;
                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateWin(serw, wol, proc_wolnej, beg, end);
                }
                if (os == "lin")
                {
                    List<LinuxModel> xx = SqliteDataAccess.LoadDateIDLin(Date_range2.Text);
                    end = xx.Last().Id;
                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateLin(serw, wol, proc_wolnej, beg, end);
                }
            }
            catch (Exception)
            {
                end = 0;
            }

        }

        private void Date_range1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (os == "win")
                {
                    List<WindowsModel> xx = SqliteDataAccess.LoadDateIDWin(Date_range1.Text);
                    beg = xx.First().Id;
                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateWin(serw, wol, proc_wolnej, beg, end);

                }
                if (os == "lin")
                {
                    List<LinuxModel> xx = SqliteDataAccess.LoadDateIDLin(Date_range1.Text);
                    beg = xx.First().Id;
                    Data_grid.ItemsSource = SqliteDataAccess.LoadDateLin(serw, wol, proc_wolnej, beg, end);
                }
            }
            catch (Exception)
            {
                beg = 0;
            }
            
        }
    }
}
