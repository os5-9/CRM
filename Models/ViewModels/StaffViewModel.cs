namespace TravelAgencyCRM.Models.ViewModels
{
    /// <summary>
    /// ViewModel сотрудника
    /// </summary>
    public class StaffViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Place { get; set; }
    }
}
