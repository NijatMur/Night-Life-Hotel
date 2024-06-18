namespace NightLifeHotelApp.Models
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.Empty;
        public int? Number { get; set; } = 0;
        public byte? Floor { get; set; } = 0;
        public decimal? Cost { get; set; } = decimal.Zero;
        public DateTime? ReservationBegin { get; set; } = DateTime.Now;
        public DateTime? ReservationEnd { get; set; } = DateTime.Now;
        public string? AboutRoom { get; set; } = string.Empty;

        public Room()
        {
            
        }
    }
}
