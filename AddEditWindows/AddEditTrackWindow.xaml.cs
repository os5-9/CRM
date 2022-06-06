using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TravelAgencyCRM.Models;
using TravelAgencyCRM.Repositories;

namespace TravelAgencyCRM.AddEditWindows
{
    public partial class AddEditTrackWindow : Window
    {
        private IEnumerable<Clients> allClients;
        private List<Clients> allWardClients = new List<Clients>();
        private IEnumerable<Tours> allTours;
        private Tours selectedTour;
        private Clients selectedClient;
        private Staff selectedStaff;
        private List<Track> ert = new List<Track>();

        public AddEditTrackWindow(Tours movedTour)
        {
            InitializeComponent();
            allClients = ClientRepository.GetAllClients();
            UpdateClients();
            allTours = TourRepository.GetAllTours();
            UpdateTours();
            //selectedStaff = StaffRepository.GetStaffByID(StaffRepository.CurrentStaffID);
            //tbStaff.Text += ": " + selectedStaff.FullName;
            selectedTour = movedTour;
            dgTour.SelectedItem = selectedTour;

        }
        private void UpdateClients()
        {
            dgClient.ItemsSource = allClients.ToList();
        }
        private void UpdateTours()
        {
            dgTour.ItemsSource = allTours.ToList();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //ManagerWindow window = new ManagerWindow();
            this.Close();
           // window.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (selectedClient != null)
            {
                Track track = new Track();
                track.StaffID = 11;// selectedStaff.ID;
                track.ClientID = selectedClient.ID;
                track.TourID = selectedTour.ID;
                track.ContractDate = DateTime.Now;
                foreach (var ward in allWardClients)
                {
                    track.Ward += ward.ID + "|";
                }
                track.TicketsAmount = 1 + allWardClients.Count;
                track.TotalCost = track.TicketsAmount * selectedTour.Price;
                track.IsExists = 1;

                if (selectedTour.Tickets - track.TicketsAmount >= 0)
                {
                    TrackRepository.AddTrack(track);
                    TrackRepository.FormContract(track); 
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Количество людей превышает количество билетов в наличии");
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для оформления договора");
            }
        }

        private void tbFullName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            allClients = ClientRepository.SearchClientWithoutGender(tbFullName.Text);
            UpdateClients();
        }

        private void dgTour_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selected = (Tours)dgTour.SelectedItem;
            tbTour.Text = "Тур: "
                + selected.City
                + " "
                + selected.Country
                + " "
                + selected.Price
                + " руб. от "
                + (selected.Departure).Value.ToShortDateString()
                + " по "
                + (selected.Arrival).Value.ToShortDateString();
            selectedTour = selected;
        }

        private void dgClient_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selected = (Clients)dgClient.SelectedItem;
            if (selected.PassportN != null)
            {
                tbClient.Text = "Основной клиент: "
                                + selected.FullName
                                + " "
                                + selected.PassportS
                                + " "
                                + selected.PassportN;
                tbID.Text = selected.ID.ToString();
                if (allWardClients.Where(x => x.ID == selected.ID).Any())
                {
                    if (allWardClients.Remove(selected))
                    {
                        dgWardClient.ItemsSource = allWardClients.ToList();
                    }
                }
                selectedClient = selected;
            }
        }

        private void btnGetWard_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Clients)dgClient.SelectedItem;
            if (selected != null && selected.ID.ToString() != tbID.Text && !allWardClients.Where(x => x.ID == selected.ID).Any() && selected.PassportN == null)
            {
                allWardClients.Add(selected);
                dgWardClient.ItemsSource = allWardClients.ToList();
            }
        }

        private void btnLostWard_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Clients)dgWardClient.SelectedItem;
            if (selected != null)
            {
                if (allWardClients.Remove(selected))
                {
                    dgWardClient.ItemsSource = allWardClients.ToList();
                }
            }
        }
    }
}
