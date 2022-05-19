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
        private IEnumerable<Clients> allClients;
        private IEnumerable<Tours> allTours;
        private IEnumerable<StaffViewModel> allStaff;
        private IEnumerable<Track> allTracks;

        public AdminW()
        {
            InitializeComponent();

            allClients = ClientRepository.GetAllClients();
            cmbGender.SelectedIndex = 0;
            UpdateClients();

            allTours = TourRepository.GetAllTours();
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

            allTracks = model.Track.Where(x => x.IsExists == 1);
            cmbGenderTrack.SelectedIndex = 0;
            cmbStatusTrack.SelectedIndex = 0;
            cmbTypeTrack.SelectedIndex = 0;
            cmbRoleTrack.SelectedIndex = 0;
            UpdateTrack();
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
                UpdateTrack();
            }
        }

        private void UpdateClients()
        {
            dgClient.ItemsSource = allClients.ToList();
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
            dgTour.ItemsSource = allTours.ToList();
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
                if ((dpArrivalS.SelectedDate != null) && (dpArrivalF.SelectedDate != null))
                {
                    var arrivalS = dpArrivalS.SelectedDate.Value;
                    var arrivalF = dpArrivalF.SelectedDate.Value;
                    allTours = TourRepository.SearchTourarrivalal(allTours, arrivalS, arrivalF);
                }
                if ((dpDepartureS.SelectedDate != null) && (dpDepartureF.SelectedDate != null))
                {
                    var departureS = dpDepartureS.SelectedDate.Value;
                    var departureF = dpDepartureF.SelectedDate.Value;
                    allTours = TourRepository.SearchTourdepartureture(allTours, departureS, departureF);
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
            dgStaff.ItemsSource = allStaff.ToList();
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
            dgTrack.ItemsSource = allTracks.ToList();
        }
        private void SearchTrack()
        {
            allTracks = model.Track.Where(x => x.IsExists == 1);

            if ((cmbStatusTrack.SelectedItem != null) && (cmbTypeTrack.SelectedItem != null) && (cmbGenderTrack.SelectedItem != null) && (cmbRoleTrack.SelectedItem != null))
            {
                string status = ((ComboBoxItem)cmbStatusTrack.SelectedItem).Content.ToString();
                string type = ((ComboBoxItem)cmbTypeTrack.SelectedItem).Content.ToString();
                string gender = ((ComboBoxItem)cmbGenderTrack.SelectedItem).Content.ToString();
                byte role = (byte)((cmbRoleTrack.SelectedItem as ComboBoxItem).Content.ToString() == "Директор" ? 1 : 0);

                if (cmbGenderTrack.SelectedIndex != 0)
                {
                    allTracks = allTracks.Where(x => x.Clients.Gender == gender);
                }
                if (!string.IsNullOrEmpty(tbClientName.Text))
                {
                    allTracks = allTracks.Where(x => x.Clients.FullName.ToLower().Contains(tbClientName.Text.ToLower()));
                }
                if (cmbStatusTrack.SelectedIndex != 0)
                {
                    allTracks = allTracks.Where(x => x.Tours.TourStates.Name.Contains(status));
                }
                if (cmbTypeTrack.SelectedIndex != 0)
                {
                    allTracks = allTracks.Where(x => x.Tours.TourType.Name.Contains(type));
                }
                if (!string.IsNullOrEmpty(tbCityTrack.Text))
                {
                    allTracks = allTracks.Where(x => x.Tours.City.ToLower().Contains(tbCityTrack.Text.ToLower()));
                }
                if (!string.IsNullOrEmpty(tbCountryTrack.Text))
                {
                    allTracks = allTracks.Where(x => x.Tours.Country.ToLower().Contains(tbCountryTrack.Text.ToLower()));
                }
                if (!string.IsNullOrEmpty(tbPriceTrack.Text))
                {
                    allTracks = allTracks.Where(x => x.Tours.Price <= int.Parse(tbPriceTrack.Text));
                }
                if ((dpArrivalSTrack.SelectedDate != null) && (dpArrivalFTrack.SelectedDate != null))
                {
                    var arrivalS = dpArrivalSTrack.SelectedDate.Value;
                    var arrivalF = dpArrivalFTrack.SelectedDate.Value;
                    allTracks = allTracks.Where(x => (x.Tours.Arrival >= arrivalS && x.Tours.Arrival <= arrivalF));
                }
                if ((dpDepartureSTrack.SelectedDate != null) && (dpDepartureFTrack.SelectedDate != null))
                {
                    var departureS = dpDepartureSTrack.SelectedDate.Value;
                    var departureF = dpDepartureFTrack.SelectedDate.Value;
                    allTracks = allTracks.Where(x => (x.Tours.Departure >= departureS && x.Tours.Departure <= departureF));
                }
                if (cmbRoleTrack.SelectedIndex != 0)
                {
                    allTracks = allTracks.Where(x => x.Staff.IsAdmin == role);
                }
                if (!string.IsNullOrEmpty(tbStaffFIO.Text))
                {
                    allTracks = allTracks.Where(x => x.Staff.FullName.ToLower().Contains(tbStaffFIO.Text.ToLower()));
                }
            }
            UpdateTrack();
        }
        private void cmbTrack_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchTrack();
        }
        private void tbTrack_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchTrack();
        }
        private void dpTrack_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchTrack();
        }
    }
}
