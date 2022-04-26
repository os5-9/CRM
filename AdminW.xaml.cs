using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TravelAgencyCRM.Models;
using TravelAgencyCRM.Repositories;

namespace TravelAgencyCRM
{
    /// <summary>
    /// Логика взаимодействия для AdminW.xaml
    /// </summary>
    public partial class AdminW : Window
    {
        public AgencyModel model = new AgencyModel();
        private List<Clients> allClients;
        private List<Tours> allTours;
        private List<Staff> allStaff;
        private List<Track> allTracks;

        public AdminW()
        {
            InitializeComponent();
            
            allClients = ClientRepository.GetAllClients();
            UpdateClients();
            cmbGender.SelectedIndex = 0;
            
            allTours = model.Tours.Where(x => x.IsExists == 1).ToList();
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

            if (tiStaff.IsSelected)
            {
                UpdateClients();
            }

            if (tiTrack.IsSelected)
            {
                dgTrack.Height = this.ActualHeight - (TourPanel.ActualHeight - 180);
            }
        }

        private void UpdateClients()
        {
            dgClient.ItemsSource = allClients;
        }

        private void SearchClient()
        {
            if (cmbGender.SelectedIndex == 0)
            {
                allClients = ClientRepository.SearchClientWithoutGender(tbName.Text);
            }
            else
            {
                allClients = ClientRepository.SearchClientWithGender(((ComboBoxItem)cmbGender.SelectedItem).Content.ToString(), tbName.Text);
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
            dgTour.ItemsSource = allTours;
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
        private void UpdateStaff()
        {
            dgTour.ItemsSource = allTours;
        }
       
    }
}
