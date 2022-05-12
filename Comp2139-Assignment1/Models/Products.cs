using System.ComponentModel.DataAnnotations;

namespace GBCSporting_OJO.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required (ErrorMessage = "Product needs a code")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Product needs a name")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product needs a price")]
        public string? ProductPrice { get; set; }

        [Required(ErrorMessage = "Product needs a release date")]
        public DateTime ProductReleaseDate { get; set; }

    }
}
