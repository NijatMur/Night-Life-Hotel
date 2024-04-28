using NightLifeHotelApp.Models;

namespace NightLifeHotelApp.Services.Base
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>?> GetAllAsync();
        Task CreateAsync(Room newEntity);
    }
}
