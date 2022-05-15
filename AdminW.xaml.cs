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
            cmbGender.SelectedIndex = 0; 
            UpdateClients();

            allTours = TourRepository.GetAllTours();// model.Tours.Where(x => x.IsExists == 1).ToList();
            cmbStatus.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            UpdateTours();

            allStaff = StaffRepository.GetAllStaff().Select(s => new StaffViewModel
            {
                ID = s.ID,
                FullName = s.FullName,
                Login = s.Login,
                Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Директор"
            });
            cmbRole.SelectedIndex = 0;
            UpdateStaff();
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
            allTours = TourRepository.GetAllTours();
            if ((cmbStatus.SelectedItem != null) && (cmbType.SelectedItem != null))
            {
                string status = ((ComboBoxItem)cmbStatus.SelectedItem).Content.ToString();
                string type = ((ComboBoxItem)cmbType.SelectedItem).Content.ToString();
                if (!string.IsNullOrEmpty(tbCity.Text))
                {
                    allTours = TourRepository.SearchTourCity(allTours, tbCity.Text);
                }
                if (!string.IsNullOrEmpty(tbCountry.Text))
                {
                    allTours = TourRepository.SearchTourCountry(allTours, tbCountry.Text);
                }
                if (cmbStatus.SelectedIndex != 0)
                {
                    allTours = TourRepository.SearchTourStatus(allTours, status);
                }
                if (cmbType.SelectedIndex != 0)
                {
                    allTours = TourRepository.SearchTourType(allTours, type);
                }
                if (!string.IsNullOrEmpty(tbPrice.Text))
                {
                    allTours = TourRepository.SearchTourPrice(allTours, int.Parse(tbPrice.Text.ToString()));
                }
                if ((dpArrivS.SelectedDate != null) && (dpArrivF.SelectedDate != null))
                {
                    var arrivS = dpArrivS.SelectedDate.Value;
                    var arrivF = dpArrivF.SelectedDate.Value;
                    allTours = TourRepository.SearchTourArrival(allTours, arrivS, arrivF);
                }
                if ((dpDeparS.SelectedDate != null) && (dpDeparF.SelectedDate != null))
                {
                    var deparS = dpDeparS.SelectedDate.Value;
                    var deparF = dpDeparF.SelectedDate.Value;
                    allTours = TourRepository.SearchTourDeparture(allTours, deparS, deparF);
                }
            }
            UpdateTours();
        }
        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchTours();
        }
        private void tbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchTours();
        }
        private void tbPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
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
        
        private void UpdateTrack()    
        {
            dgStaff.ItemsSource = allStaff;
        }
        private void SearchTrack()
        {
        }

    }
}
