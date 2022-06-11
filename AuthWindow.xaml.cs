using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TravelAgencyCRM.Models;
using TravelAgencyCRM.Repositories;
using static System.Console;

namespace TravelAgencyCRM
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            TourRepository.CheckDate();
        }
        AgencyModel model = new AgencyModel();

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Password;

            if ((string.IsNullOrWhiteSpace(login)) && (string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (model.Staff.Where(x => x.Password == password && x.Login == login && x.IsExists == 1).Any())
            {
                Staff staff = model.Staff.Where(x => x.Password == password && x.Login == login && x.IsExists == 1).FirstOrDefault();

                switch (staff.IsAdmin)
                {
                    case 0:
                        ManagerWindow m = new ManagerWindow();
                        m.Show();
                        this.Close();
                        break;
                    case 1:
                        AdminW window = new AdminW();
                        window.Show();
                        this.Close();
                        break;
                }
                StaffRepository.CurrentStaffID = staff.ID;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Enter_Click(sender, e);
            }
        }
    }
}
