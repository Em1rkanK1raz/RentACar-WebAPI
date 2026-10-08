using System.ComponentModel.DataAnnotations;
namespace RentACarWebAPI.Models
{
    public class RentalCreateDto
    {
        [Required(ErrorMessage = "Araba ID zorunludur!")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Müşteri ID zorunludur!")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur!")]
        public DateTime StartDate { get; set;
        }
        [Required(ErrorMessage = "Bitiş tarihi zorunludur!")]
        public DateTime EndDate { get; set; }

    }
}
