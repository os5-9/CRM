using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TravelAgencyCRM.Models;
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
        }
        
        AgencyModel model = new AgencyModel();
        
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Password;

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин");
                WriteLine($"Пустое поле логина");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль");
                WriteLine($"Пустое поле пароля");
                return;
            }

            if (model.Staff.Where(x => x.Password == password && x.Login == login && x.IsExists == 1).Any())
            {
                Staff staff = model.Staff.Where(x => x.Password == password && x.Login == login && x.IsExists == 1).FirstOrDefault();

                switch (staff.IsAdmin)
                {
                    case 0:
                        WriteLine($"Авторизация пользователя Менеджер - {staff.FullName}");
                        ManagerWindow m = new ManagerWindow();
                        m.Show();
                        this.Close();
                        break;
                    case 1:
                        WriteLine($"Авторизация пользователя Директор - {staff.FullName}");
                        AdminWindow window = new AdminWindow();
                        window.Show();
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                WriteLine($"Неверный логин или пароль {login} {password}");
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
