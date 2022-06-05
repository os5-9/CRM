using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TravelAgencyCRM.Models;
using TravelAgencyCRM.Repositories;

namespace TravelAgencyCRM.AddEditWindows
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window
    {
        private AgencyModel model = new AgencyModel();
        private Clients currentClient;

        public AddEditClientWindow(Clients movedClient)
        {
            InitializeComponent();
            dpBDay.DisplayDateEnd = DateTime.Now;
            if (movedClient == null)
            {
                currentClient = new Clients();
                this.Title = "Добавление клиента";
                spAddress.Visibility = Visibility.Visible;
            }
            else
            {
                currentClient = movedClient;
                if (currentClient.Gender == "Женский")
                {
                    cmbGender.SelectedIndex = 0;
                }
                else
                {
                    cmbGender.SelectedIndex = 1;
                }
                this.Title = $"Редактирование клиента {currentClient.FullName}";
                spAddress.Visibility = Visibility.Collapsed;
                tbAddress.Visibility = Visibility.Visible;
                dpBDay.SelectedDate = currentClient.BDay; 
            }
            DataContext = currentClient;
        }

        private void ControlForDigit(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private bool Validation()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(tbFIO.Text))
            {
                errors.AppendLine("Введите ФИО клиента");
            }
            if (dpBDay.SelectedDate == null)
            {
                errors.AppendLine("Выберите дату рождения");
            }
            if (cmbGender.SelectedItem == null)
            {
                errors.AppendLine("Выберите пол");
            }
            if (tbMsisdn.Text == "")
            {
                errors.AppendLine("Введите номер телефона");
            }
           
            if (!new EmailAddressAttribute().IsValid(tbEmail.Text))
            {
                errors.AppendLine("Введите корректную электронную почту");
            }
            if (currentClient.ID == 0)
            {
                if (cmbTypeAddress.SelectedItem == null)
                {
                    errors.AppendLine("Выберите тип адреса (улица, проспект и т.д.)");
                }
                if (string.IsNullOrEmpty(tbStreet.Text))
                {
                    errors.AppendLine("Введите название улицы/проспекта/бульвара/переулка");
                }
                if (string.IsNullOrEmpty(tbBuilding.Text))
                {
                    errors.AppendLine("Введите номер дома");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tbAddress.Text))
                {

                    errors.AppendLine("Введите адрес");
                }
            }
            //            if (dpBDay.SelectedDate != null) {
            //                DateTime yer = (DateTime)dpBDay.SelectedDate;
            //                DateTime t = DateTime.Now.Date;
            //                DateTime y = t - yer;
            //                if (t. >= 14)
            //                {

            //                }
            //}
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                currentClient.Gender = cmbGender.Text;
                currentClient.IsExists = 1;
                if (currentClient.ID == 0)
                {
                    ClientRepository.AddClient(currentClient);
                }
                else
                {
                    ClientRepository.EditClient();
                }
                btnCancel_Click(sender,e);
            }
            else
            {
                return;
            }
        }

        private void tbCertificate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
#warning Написать нормальную маску
            //if (e.Text == "-")
            //{
            //    tb
            //}
        }
    }
}
