using System.Windows;
using System.Windows.Input;
using TravelAgencyCRM.Repositories;

namespace TravelAgencyCRM.AddEditWindows
{
    /// <summary>
    /// Логика взаимодействия для TourProcent.xaml
    /// </summary>
    public partial class TourProcent : Window
    {
        public TourProcent()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (tbProcent.Text != "")
            {
                TourRepository.Procent = int.Parse(tbProcent.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите наценку стоимости тура в процентах");
            }
        }
        private void ControlForDigit(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}