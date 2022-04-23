using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM
{
    /// <summary>
    /// Логика взаимодействия для AdminW.xaml
    /// </summary>
    public partial class AdminW : Window
    {
        public AgencyModel model = new AgencyModel();
        private List<Clients> allAboutClients;
        private List<Tours> AllTours;
        
        public AdminW()
        {
            InitializeComponent();
            allAboutClients = model.Clients.Where(x => x.IsExists == 1).ToList();
            UpdateClients();
            cmbGender.SelectedIndex = 0;
            
            AllTours = model.Tours.Where(x => x.IsExists == 1).ToList();
            UpdateTours();

            cmbStatus.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
        }
        
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tiClient.IsSelected)
            {
                UpdateClients();
            }

            if (tiTour.IsSelected)
            {
                dgTour.Height = this.ActualHeight - wPanel.ActualHeight;
                UpdateTours();
            }

            if (tiTrack.IsSelected)
            {
                dgTrack.Height = this.ActualHeight - (TourPanel.ActualHeight - 180);
            }
        }

        private void UpdateClients()
        {
            dgClient.ItemsSource = allAboutClients;
        }

        private void SearchClient()
        {
            if (cmbGender.SelectedIndex == 0)
            {
                allAboutClients = model.Clients
                    .Where(
                        x => x.FullName.Contains(tbName.Text)
                        && x.IsExists == 1
                    )
                    .ToList();
            }
            else
            {
                allAboutClients = model.Clients
                    .Where(
                        x => x.Gender == ((ComboBoxItem)cmbGender.SelectedItem).Content.ToString()
                        && x.FullName.Contains(tbName.Text)
                        && x.IsExists == 1
                    )
                    .ToList();
            }
            UpdateClients();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchClient();
        }

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchClient();
        }

  
        private void UpdateTours()
        {
            dgTour.ItemsSource = AllTours;
        }
        private void SearchTours()
        {

        }
        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbCity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
