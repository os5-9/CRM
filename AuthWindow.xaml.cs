﻿using System;
using System.IO;
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
        public static string log;
         

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Password;

            if ((string.IsNullOrWhiteSpace(login)) && (string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show("Заполните все поля");
                log = $"Авторизация | Пустые поля логина и пароля\n";
                Logger.Log(log);
                return;
            }

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин");
                log = $"Авторизация | Пустое поле логина\n";
                Logger.Log(log);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль");
                log = $"Авторизация | Пустое поле пароля\n";
                Logger.Log(log);
                return;
            }

            if (model.Staff.Where(x => x.Password == password && x.Login == login && x.IsExists == 1).Any())
            {
                Staff staff = model.Staff.Where(x => x.Password == password && x.Login == login && x.IsExists == 1).FirstOrDefault();

                switch (staff.IsAdmin)
                {
                    case 0:
                        log = $"Авторизация | Авторизация пользователя Менеджер - {staff.FullName}\n";
                        Logger.Log(log);
                        ManagerWindow m = new ManagerWindow();
                        m.Show();
                        this.Close();
                        break;
                    case 1:
                        log = $"Авторизация | Авторизация пользователя Директор - {staff.FullName}\n";
                        Logger.Log(log);
                        AdminW window = new AdminW();
                        window.Show();
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                log = $"Авторизация | Неверный логин или пароль {login}\n";
                Logger.Log(log);
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
