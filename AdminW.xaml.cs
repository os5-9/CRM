using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TravelAgencyCRM.AddEditWindows;
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
        private IEnumerable<Tours> allTours;
        private IEnumerable<StaffViewModel> allStaff;
        private IEnumerable<Operators> allOperators;
        private IEnumerable<Operators> allWaitingOperators;

        public AdminW()
        {
            InitializeComponent();

            allStaff = StaffRepository.GetAllStaff().Select(s => new StaffViewModel
            {
                ID = s.ID,
                FullName = s.FullName,
                Login = s.Login,
                Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Главный менеджер",
                IsActive = s.IsExists.Value == 0 ? "Заблокирован" : "Активен"
            });
            cmbExisting.SelectedIndex = 0;
            cmbRole.SelectedIndex = 0;
            UpdateStaff();

            allTours = TourRepository.GetAllNotApprovedTours();
            cmbStatus.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            dpArrivalS.DisplayDateStart = DateTime.Now;
            dpArrivalF.DisplayDateStart = DateTime.Now;
            dpDepartureS.DisplayDateStart = DateTime.Now;
            dpDepartureF.DisplayDateStart = DateTime.Now;
            UpdateTours();

            allWaitingOperators = OperatorRepository.GetAllWaitingOperators();
            UpdateWaitOperators();

            allOperators = OperatorRepository.GetAllOperators();
            UpdateOperators();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tiTour.IsSelected)
            {
                dgTour.Height = this.ActualHeight - wPanel.ActualHeight;
                UpdateTours();
            }
            if (tiStaff.IsSelected)
            {
                UpdateStaff();
            }
            if (tiWaitingOperators.IsSelected)
            {
                UpdateWaitOperators();
            }
            if (tiOperators.IsSelected)
            {
                UpdateOperators();
            }
        }
        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        #region Handlers for Tour
        private void UpdateTours()
        {
            dgTour.ItemsSource = allTours.ToList();
        }
        private void SearchTours()
        {
            allTours = TourRepository.GetAllNotApprovedTours();
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
                    allTours = TourRepository.SearchTourDeparture(allTours, arrivalS, arrivalF);
                }
                if ((dpDepartureS.SelectedDate != null) && (dpDepartureF.SelectedDate != null))
                {
                    var departureS = dpDepartureS.SelectedDate.Value;
                    var departureF = dpDepartureF.SelectedDate.Value;
                    allTours = TourRepository.SearchTourArrival(allTours, departureS, departureF);
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
        private void btnApproveTour_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Tours)dgTour.SelectedItem;
            if (selected != null)
            {
                TourProcent tour = new TourProcent();
                tour.ShowDialog();
                int procent = TourRepository.Procent;
                TourRepository.ApproveTour(selected, procent);
                UpdateTours();
            }
            else
            {
                MessageBox.Show("Выберите тур для одобрения");
            }
        }
        private void btnDismissTour_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Tours)dgTour.SelectedItem;
            if (selected != null)
            {
                if (MessageBox.Show("Вы уверенны, что хотите отклонить выбранный тур?\nДанное действие нельзя будет отменить", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TourRepository.DismissTour(selected.ID);
                    UpdateTours();
                }
            }
            else
            {
                MessageBox.Show("Выберите тур для отклонения");
            }
        }
        #endregion

        #region Handlers for Staff
        private void UpdateStaff()
        {
            dgStaff.ItemsSource = allStaff.ToList();
        }
        private void SearchStaff()
        {
            if ((cmbExisting.SelectedItem != null) && (cmbRole.SelectedItem != null))
            {
                int existing = 0;
                switch (cmbExisting.SelectedIndex)
                {
                    case 1:
                        existing = 1;
                        break;
                    case 2:
                        existing = 0;
                        break;
                }
                if (cmbExisting.SelectedIndex != 0)
                {
                    if (cmbRole.SelectedIndex == 0)
                    {
                        allStaff = StaffRepository.SearchStaffWithoutPlace(tbFullName.Text, existing)
                            .Select(s => new StaffViewModel
                            {
                                ID = s.ID,
                                FullName = s.FullName,
                                Login = s.Login,
                                Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Главный менеджер",
                                IsActive = s.IsExists.Value == 0 ? "Заблокирован" : "Активен"
                            });
                    }
                    else
                    {
                        byte role = (byte)((cmbRole.SelectedItem as ComboBoxItem).Content.ToString() == "Главный менеджер" ? 1 : 0);
                        allStaff = StaffRepository.SearchStaffWithPlace(role, tbFullName.Text, existing)
                            .Select(s => new StaffViewModel
                            {
                                ID = s.ID,
                                FullName = s.FullName,
                                Login = s.Login,
                                Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Главный менеджер",
                                IsActive = s.IsExists.Value == 0 ? "Заблокирован" : "Активен"
                            });
                    }
                }
                else
                {
                    if (cmbRole.SelectedIndex == 0)
                    {
                        allStaff = StaffRepository.SearchAllStaffWithoutPlace(tbFullName.Text)
                            .Select(s => new StaffViewModel
                            {
                                ID = s.ID,
                                FullName = s.FullName,
                                Login = s.Login,
                                Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Главный менеджер",
                                IsActive = s.IsExists.Value == 0 ? "Заблокирован" : "Активен"
                            });
                    }
                    else
                    {
                        byte role = (byte)((cmbRole.SelectedItem as ComboBoxItem).Content.ToString() == "Главный менеджер" ? 1 : 0);
                        allStaff = StaffRepository.SearchAllStaffWithPlace(role, tbFullName.Text)
                            .Select(s => new StaffViewModel
                            {
                                ID = s.ID,
                                FullName = s.FullName,
                                Login = s.Login,
                                Place = s.IsAdmin.Value == 0 ? "Менеджер" : "Главный менеджер",
                                IsActive = s.IsExists.Value == 0 ? "Заблокирован" : "Активен"
                            });
                    }
                }
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
        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            var selected = (StaffViewModel)dgStaff.SelectedItem;
            if (selected != null)
            {
                if (StaffRepository.GetStaffByID(selected.ID).IsExists == 0)
                {
                    MessageBox.Show("Выбранный сотрудник уже заблокирован");
                }
                else
                {
                    if (StaffRepository.CurrentStaffID == selected.ID)
                    {
                        MessageBox.Show("Вы не можете заблокировать свой аккаунт");
                    }
                    else
                    {
                        StaffRepository.Lock(selected.ID);
                        UpdateStaff();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для блокировки");
            }
        }
        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            var selected = (StaffViewModel)dgStaff.SelectedItem;
            if (selected != null)
            {
                if (StaffRepository.GetStaffByID(selected.ID).IsExists == 1)
                {
                    MessageBox.Show("Выбранный сотрудник уже имеет доступ к системе");
                }
                else
                {
                    StaffRepository.Unlock(selected.ID);
                    UpdateStaff();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для разблокировки");
            }
        }
        private void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            AddEditStaffWindow window = new AddEditStaffWindow(0);
            window.ShowDialog();
        }
        private void btnEditStaff_Click(object sender, RoutedEventArgs e)
        {
            var selected = (StaffViewModel)dgStaff.SelectedItem;
            if (selected != null)
            {
                AddEditStaffWindow window = new AddEditStaffWindow(selected.ID);
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования");
            }
        }
        #endregion

        #region Handlers for Waiting for approve operators
        private void UpdateWaitOperators()
        {
            dgWaitingOperators.ItemsSource = allWaitingOperators.ToList();
        }
        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Operators)dgWaitingOperators.SelectedItem;
            if (selected != null)
            {
                OperatorRepository.ApproveOperator(selected.ID);
                UpdateWaitOperators();
            }
            else
            {
                MessageBox.Show("Выберите оператора для одобрения");
            }
        }
        private void btnDismiss_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Operators)dgWaitingOperators.SelectedItem;
            if (selected != null)
            {
                if (MessageBox.Show("Вы уверенны, что хотите отклонить выбранную заявку?\nДанное действие нельзя будет отменить", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OperatorRepository.DismissOperator(selected.ID);
                    UpdateWaitOperators();
                }
            }
            else
            {
                MessageBox.Show("Выберите оператора для отклонения");
            }
        }
        #endregion

        #region Handlers for approved operators
        private void UpdateOperators()
        {
            dgOperators.ItemsSource = allOperators.ToList();
        }
        private void btnDeny_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Operators)dgOperators.SelectedItem;
            if (selected != null)
            {
                if (MessageBox.Show("Вы уверенны, что хотите заблокировать выбранному оператору доступ к системе?\nДанное действие нельзя будет отменить", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OperatorRepository.DismissOperator(selected.ID);
                    UpdateOperators();
                }
            }
            else
            {
                MessageBox.Show("Выберите оператора для блокирования");
            }
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            auth.Show();
        }
    }
}