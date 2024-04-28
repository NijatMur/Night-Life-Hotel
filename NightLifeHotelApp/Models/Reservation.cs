namespace NightLifeHotelApp.Models
{
    public class Reservation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? ReservationBegin { get; set; } = DateTime.Now;
        public DateTime? ReservationEnd { get; set; } = DateTime.Now;

        public Reservation() { }
    }
}
