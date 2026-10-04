namespace RentACarWebAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;       
        public string Model { get; set; } = string.Empty;       
        public string Plate { get; set; } = string.Empty;
        public decimal DailyPrice { get; set; }                 
        public bool IsRented { get; set; } = false;             
    }
}