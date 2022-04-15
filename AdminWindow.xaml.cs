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

namespace TravelAgencyCRM
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        #region Views
        public int selected = 0;
        private void Client_Click(object sender, RoutedEventArgs e)
        {
            selected = 1;
            cl_panel.Visibility = Visibility.Visible;
            dg.Visibility = Visibility.Visible;
            tr_panel.Visibility = Visibility.Collapsed;
            tour_panel.Visibility = Visibility.Collapsed;
            staff_panel.Visibility = Visibility.Collapsed;
            dgTours.Visibility = Visibility.Collapsed;
        }

        private void Tour_Click(object sender, RoutedEventArgs e)
        {
            selected = 2;
            tour_panel.Visibility = Visibility.Visible;
            dgTours.Visibility = Visibility.Visible;
            cl_panel.Visibility = Visibility.Collapsed;
            tr_panel.Visibility = Visibility.Collapsed;
            staff_panel.Visibility = Visibility.Collapsed;
            dg.Visibility = Visibility.Collapsed;
        }

        private void Transport_Click(object sender, RoutedEventArgs e)
        {
            selected = 3;
            tr_panel.Visibility = Visibility.Visible;
            dg.Visibility = Visibility.Visible;
            cl_panel.Visibility = Visibility.Collapsed;
            tour_panel.Visibility = Visibility.Collapsed;
            staff_panel.Visibility = Visibility.Collapsed;
            dgTours.Visibility = Visibility.Collapsed;
        }

        private void Track_Click(object sender, RoutedEventArgs e)
        {
            selected = 4;
            cl_panel.Visibility = Visibility.Visible;
            tr_panel.Visibility = Visibility.Visible;
            tour_panel.Visibility = Visibility.Visible;
            staff_panel.Visibility = Visibility.Visible;
            dg.Visibility = Visibility.Visible;
            dgTours.Visibility = Visibility.Collapsed;
        }

        private void Staff_Click(object sender, RoutedEventArgs e)
        {
            selected = 5;
            staff_panel.Visibility = Visibility.Visible;
            dg.Visibility = Visibility.Visible;
            dgTours.Visibility = Visibility.Collapsed;
            cl_panel.Visibility = Visibility.Collapsed;
            tr_panel.Visibility = Visibility.Collapsed;
            tour_panel.Visibility = Visibility.Collapsed;
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            selected = 6;
            dg.Visibility = Visibility.Collapsed;
            dgTours.Visibility = Visibility.Collapsed;
            staff_panel.Visibility = Visibility.Collapsed;
            cl_panel.Visibility = Visibility.Collapsed;
            tr_panel.Visibility = Visibility.Collapsed;
            tour_panel.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
