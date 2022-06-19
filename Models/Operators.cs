using System.ComponentModel.DataAnnotations;

namespace TravelAgencyCRM.Models
{
    public partial class Operators
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Login { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        /// <summary>
        /// is operator approved by MainManager, has values: 0 - created, not approved; 1 - approved; 2 - not approved
        /// </summary>
        public byte? IsDenied { get; set; }
    }
}