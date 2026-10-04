using System.ComponentModel.DataAnnotations;

namespace RentACarWebAPI.Models
{
    public class CustomerCreateDto
    {
        [Required(ErrorMessage = "Ad zorunludur!")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir!")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur!")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir!")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon zorunludur!")]
        [RegularExpression(@"^05\d{2}\s\d{3}\s\d{2}\s\d{2}$",
            ErrorMessage = "Telefon formatı: 05XX XXX XX XX olmalıdır!")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta zorunludur!")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "TC Kimlik No zorunludur!")]
        [RegularExpression(@"^\d{11}$",
            ErrorMessage = "TC Kimlik No 11 haneli ve sadece rakamdan oluşmalıdır!")]
        public string NationalId { get; set; } = string.Empty;
    }
}