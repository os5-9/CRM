namespace TravelAgencyCRM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Track")]
    public partial class Track
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? StaffID { get; set; }

        public int? ClientID { get; set; }

        public int? TourID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ContractDate { get; set; }

        public byte? IsExists { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Tours Tours { get; set; }

    }
}
