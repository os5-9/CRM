using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgencyCRM.Models
{
    [Table("Track")]
    public partial class Track
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? StaffID { get; set; }

        public int? ClientID { get; set; }

        [StringLength(150)]
        public string Ward { get; set; }

        public int? TourID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ContractDate { get; set; }

        public int? TicketsAmount { get; set; }

        public int? TotalCost { get; set; }

        public byte? IsExists { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Tours Tours { get; set; }
    }
}