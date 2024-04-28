namespace NightLifeHotelApp.Models
{
    public class Price
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal? Cost { get; set; } = decimal.Zero;

        public Price() { }
    }
}
