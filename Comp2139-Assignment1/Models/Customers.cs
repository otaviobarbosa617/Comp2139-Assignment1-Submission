using System.ComponentModel.DataAnnotations;

namespace GBCSporting_OJO.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer needs to have First Name"), MinLength(1,ErrorMessage ="Name has to have at least 1 character"), MaxLength(51, ErrorMessage = "Name has to have less than 51 characters")]
        [Display(Name ="First Name")]
        public string? CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Customer needs to have Last Name"), MinLength(1, ErrorMessage = "Last Name has to have at least 1 character"), MaxLength(51, ErrorMessage = "Last Name has to have less than 51 characters")]
        [Display(Name = "Last Name")]
        public string? CustomerLastName { get; set; }

        [Required(ErrorMessage = "Customer needs to have an Address"), MinLength(1, ErrorMessage = "Address has to have at least 1 character"), MaxLength(51, ErrorMessage = "Last Name has to have less than 51 characters")]
        [Display(Name = "Address")]
        public string? CustomerAddress { get; set; }

        [Required(ErrorMessage = "Customer needs to have a City"), MinLength(1, ErrorMessage = "City has to have at least 1 character"), MaxLength(51, ErrorMessage = "City has to have less than 51 characters")]
        [Display(Name = "City")]
        public string? CustomerCity { get; set; }

        [Required(ErrorMessage = "Customer needs to have a State"), MinLength(1, ErrorMessage = "State has to have at least 1 character"), MaxLength(51, ErrorMessage = "State Name has to have less than 51 characters")]
        [Display(Name = "State")]
        public string? CustomerState { get; set; }

        [Required(ErrorMessage = "Customer needs to have a Country")]
        [Display(Name = "Country")]
        public string? CustomerCountry { get; set; }

        [Required(ErrorMessage = "Customer needs to have an Email address"), DataType(DataType.EmailAddress), MaxLength(51, ErrorMessage ="Email has to have less than 51 characters")]
        [Display(Name = "Email")]
        public string? CustomerEmail { get; set; }

        [Required(ErrorMessage = "Customer needs to have a Phone Number"), DataType(DataType.PhoneNumber), RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone Number has to be in 999-999-9999 format")]
        [Display(Name = "Phone")]
        public string? CustomerPhone { get; set; }
        
    }
}
