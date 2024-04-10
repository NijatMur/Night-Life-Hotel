namespace Night_Life_Hotel.Models
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.Empty;
        public int Number { get; set; } = 0;
        public byte Floor { get; set; } = 0;
        public bool IsVIP { get; set; } = false;
    }
}
