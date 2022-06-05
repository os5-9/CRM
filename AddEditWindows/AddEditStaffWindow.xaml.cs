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
    public partial class AddEditStaffWindow : Window
    {
        private Staff currentStaff;

        public AddEditStaffWindow(int id)
        {
            InitializeComponent();
            Staff movedStaff = StaffRepository.GetStaffByID(id);
            if (movedStaff == null)
            {
                currentStaff = new Staff();
                this.Title = "Добавление сотрудника";
            }
            else
            {
                currentStaff = movedStaff;
                if (currentStaff.IsAdmin == 1)
                {
                    cmbRole.SelectedIndex = 1;
                }
                else
                {
                    cmbRole.SelectedIndex = 0;
                }
                this.Title = $"Редактирование сотрудника {currentStaff.FullName}";
            }
            DataContext = currentStaff;
        }

        private bool Validation()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(tbFIO.Text))
            {
                errors.AppendLine("Введите ФИО сотрудника");
            }
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                errors.AppendLine("Введите логин для сотрудника");
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                errors.AppendLine("Введите пароль для сотрудника");
            }
            if (cmbRole.SelectedItem == null)
            {
                errors.AppendLine("Выберите должность сотрудника");
            }
            
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
            AdminW window = new AdminW();
            window.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                currentStaff.IsAdmin = (byte?)cmbRole.SelectedIndex;
                if (currentStaff.ID == 0)
                {
                    currentStaff.IsExists = 1;
                    StaffRepository.AddStaff(currentStaff);
                }
                else
                {
                    StaffRepository.EditStaff();
                }
                btnCancel_Click(sender,e);
            }
            else
            {
                return;
            }
        }
    }
}
