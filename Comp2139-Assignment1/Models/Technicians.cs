using System.ComponentModel.DataAnnotations;

namespace GBCSporting_OJO.Models
{
    public class Technicians
    {
        [Key]
        public int TechnicianId { get; set; }

        [Required (ErrorMessage = "Technician needs a name"), StringLength(51, ErrorMessage = "Name needs to have at least 1 character and 51 character maximum")]
        public string? TechnicianName { get; set; }

        [Required(ErrorMessage = "Technician needs an email"), DataType(DataType.EmailAddress)]
        public string? TechnicianEmail { get; set; }

        [Required(ErrorMessage = "Technician needs a phone number"), DataType(DataType.PhoneNumber), RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage ="Phone Number has to be in 999-999-9999 format")]
        public string? TechnicianPhone { get; set; }

    }
}
