using System.ComponentModel.DataAnnotations;

namespace GBCSporting_OJO.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Test Controller Id")]
        public int CustomerId { get; set; }

        public Customers? Customer { get; set; }

        public int ProductId { get; set; }

        public Products? Product { get; set; }

        [Required(ErrorMessage = "Incident needs a title")]
        public string? IncidentTitle { get; set; }

        [Required(ErrorMessage = "Incident needs a description")]
        public string? IncidentDescription { get; set; }

        public int TechnicianId { get; set; }

        public Technicians? Technician { get; set; }

        public DateTime IncidentDateOpened { get; set; }

        public DateTime? IncidentDateClosed { get; set; }

    }
}
