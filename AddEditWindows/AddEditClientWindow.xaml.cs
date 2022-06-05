using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.AddEditWindows
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window
    {
        private AgencyModel model = new AgencyModel();
        private Clients currentClient;
        private static string log;

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
            if (string.IsNullOrEmpty(tbPasS.Text))
            {
                errors.AppendLine("Введите серию паспорта");
            }
            if (string.IsNullOrEmpty(tbPasN.Text))
            {
                errors.AppendLine("Введите номер паспорта");
            }
            if (dpBDay.SelectedDate == null)
            {
                errors.AppendLine("Выберите дату рождения");
            }
            if (cmbGender.SelectedItem == null)
            {
                errors.AppendLine("Выберите пол");
            }
            if (string.IsNullOrEmpty(tbMsisdn.Text))
            {
                errors.AppendLine("Введите номер телефона");
            }        
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errors.AppendLine("Введите электронную почту");
            }
            if (!new EmailAddressAttribute().IsValid(tbEmail.Text))
            {
                errors.AppendLine("Введите корректную электронную почту");
            }
            if (currentClient.ID == 0)
            {
                if (cmbGender.SelectedItem == null)
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

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                log = $"Добавление-Изменение клиента | Не пройдена валидация {errors}";
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

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {

            }
            else
            {
               await Logger.Log(log);
                return;
            }
        }
    }
}
