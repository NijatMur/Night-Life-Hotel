namespace NightLifeHotelApp.Models
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int? Number { get; set; } = 0;
        public byte? Floor { get; set; } = 0;
        public bool? IsVIP { get; set; } = false;
        public string? AboutRoom { get; set; } = string.Empty;
        public Reservation? Reservation { get; set; } 
        public Price? Price { get; set; } 

        public Room() { }
    }
}
