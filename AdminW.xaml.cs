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
        
        public AdminW()
        {
            InitializeComponent();
            allAboutClients = model.Clients.Where(x=>x.IsExists == 1).ToList();  
            Update();
            cmbGender.SelectedIndex = 0;
        }
        private void Update()
        {
            dgClient.ItemsSource = allAboutClients;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tiTour.IsSelected)
            {
                dgTour.Height = this.ActualHeight - wPanel.ActualHeight;
            }

            if (tiTrack.IsSelected)
            {
                dgTrack.Height = this.ActualHeight - (TourPanel.ActualHeight - 180);
            }
        }

        public void SearchClient()
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
            Update();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchClient();
        }

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchClient();
        }
    }
}
