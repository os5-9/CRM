using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TravelAgencyCRM.Models;
using TravelAgencyCRM.Models.ViewModels;
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
        private IEnumerable<StaffViewModel> allStaff;
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

            allStaff = StaffRepository.GetAllStaff().Select(s => new StaffViewModel
            {
                ID = s.ID,
                FullName = s.FullName,
                Login = s.Login,
                Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Директор"
            });
            UpdateStaff();
            cmbRole.SelectedIndex = 0;
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
            SearchTours();
        }
        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchTours();
        }
        private void tbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchTours();
        }

        private void UpdateStaff()
        {
            dgStaff.ItemsSource = allStaff;
        }
        private void SearchStaff()
        {
            if (cmbRole.SelectedIndex == 0)
            {
                allStaff = StaffRepository.SearchStaffWithoutPlace(tbFullName.Text)
                    .Select(s => new StaffViewModel
                {
                    ID = s.ID,
                    FullName = s.FullName,
                    Login = s.Login,
                    Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Директор"
                });
            }
            else
            {
                byte role = (byte)((cmbRole.SelectedItem as ComboBoxItem).Content.ToString() == "Директор" ? 1 : 0); 
                allStaff = StaffRepository.SearchStaffWithPlace(role, tbFullName.Text)
                    .Select(s => new StaffViewModel
                {
                    ID = s.ID,
                    FullName = s.FullName,
                    Login = s.Login,
                    Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Директор"
                });
            }
            UpdateStaff();
        }
        private void tbFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchStaff();
        }
        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchStaff();
        }
    }
}
