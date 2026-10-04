using System.ComponentModel.DataAnnotations;

namespace RentACarWebAPI.Models
{
    public class CarCreateDto
    {
        [Required(ErrorMessage = "Marka zorunludur!")]
        [StringLength(50, ErrorMessage = "Marka en fazla 50 karakter olabilir!")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model zorunludur!")]
        [StringLength(50, ErrorMessage = "Model en fazla 50 karakter olabilir!")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plaka zorunludur!")]
        [RegularExpression(@"^\d{2}\s[A-Z]{1,3}\s\d{2,4}$",
            ErrorMessage = "Plaka formatı: 34 ABC 123 şeklinde olmalıdır!")]
        public string Plate { get; set; } = string.Empty;

        [Range(1, 100000, ErrorMessage = "Günlük ücret 1 ile 100.000 arasında olmalıdır!")]
        public decimal DailyPrice { get; set; }

        public bool IsRented { get; set; }
    }
}