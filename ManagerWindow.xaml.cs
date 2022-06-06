using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TravelAgencyCRM.AddEditWindows;
using TravelAgencyCRM.Models;
using TravelAgencyCRM.Repositories;

namespace TravelAgencyCRM
{
    public partial class ManagerWindow : Window
    {
        private IEnumerable<Clients> allClients;
        private IEnumerable<Tours> allTours;
        private IEnumerable<Track> allTracks;

        public ManagerWindow()
        {
            InitializeComponent();

            allClients = ClientRepository.GetAllClients();
            cmbGender.SelectedIndex = 0;
            UpdateClients();

            allTours = TourRepository.GetAllTours();
            cmbStatus.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            dpArrivalS.DisplayDateStart = DateTime.Now;
            dpArrivalF.DisplayDateStart = DateTime.Now;
            dpDepartureS.DisplayDateStart = DateTime.Now;
            dpDepartureF.DisplayDateStart = DateTime.Now;
            UpdateTours();

            allTracks = TrackRepository.GetAllTrack();
            cmbGenderTrack.SelectedIndex = 0;
            cmbStatusTrack.SelectedIndex = 0;
            cmbTypeTrack.SelectedIndex = 0;
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
                SetSize();
                UpdateTours();
            }
            if (tiTrack.IsSelected)
            {
                SetSize();
                UpdateTrack();
            }
        }
        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        #region Client
        private void UpdateClients()
        {
            dgClient.ItemsSource = allClients.ToList();
        }
        private void SearchClient()
        {
            if (cmbGender.SelectedIndex == 0)
            {
                allClients = ClientRepository.SearchClientWithoutGender(tbClientName.Text);
            }
            else
            {
                allClients = ClientRepository.SearchClientWithGender(((ComboBoxItem)cmbGender.SelectedItem).Content.ToString(), tbClientName.Text);
            }
            UpdateClients();
        }
        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchClient();
        }
        private void tbClientName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchClient();
        }
        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddEditClientWindow window = new AddEditClientWindow(null);
            window.Show();
            this.Close();
        }
        private void btnEditClient_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Clients)dgClient.SelectedItem;
            if (selected != null)
            {
                AddEditClientWindow window = new AddEditClientWindow(selected);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите  для редактирования");
            }
        }

        #endregion

        #region Tours
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
        private void cmbTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchTours();
        }
        private void tbTour_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchTours();
        }
        private void dpTour_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchTours();
        }
        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
        #endregion

        #region Track
        private void UpdateTrack()
        {
            dgTrack.ItemsSource = allTracks.ToList();
        }
        private void SearchTrack()
        {
            allTracks = TrackRepository.GetAllTrack();

            if ((cmbStatusTrack.SelectedItem != null) && (cmbTypeTrack.SelectedItem != null) && (cmbGenderTrack.SelectedItem != null))
            {
                string status = ((ComboBoxItem)cmbStatusTrack.SelectedItem).Content.ToString();
                string type = ((ComboBoxItem)cmbTypeTrack.SelectedItem).Content.ToString();
                string gender = ((ComboBoxItem)cmbGenderTrack.SelectedItem).Content.ToString();

                if (cmbGenderTrack.SelectedIndex != 0)
                {
                    allTracks = allTracks.Where(x => x.Clients.Gender == gender);
                }
                if (!string.IsNullOrEmpty(tbClientNameTrack.Text))
                {
                    allTracks = allTracks.Where(x => x.Clients.FullName.ToLower().Contains(tbClientNameTrack.Text.ToLower()));
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
                if (!string.IsNullOrEmpty(tbStaffFIOTrack.Text))
                {
                    allTracks = allTracks.Where(x => x.Staff.FullName.ToLower().Contains(tbStaffFIOTrack.Text.ToLower()));
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
        #endregion

        private void MoveToTrackForm(object sender, MouseButtonEventArgs e)
        {
            var selected = (Tours)dgTour.SelectedItem;
            AddEditTrackWindow window = new AddEditTrackWindow(selected);
            window.Show();
        }

        private void SetSize()
        {
            dgTour.Height = this.ActualHeight - wPanel.ActualHeight - 64;
            dgTrack.Height = this.ActualHeight - (TourPanel.ActualHeight + 140);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetSize();
        }
    }
}