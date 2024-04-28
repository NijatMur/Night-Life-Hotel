using NightLifeHotelApp.Models;

namespace NightLifeHotelApp.Repositories.Base
{
    public interface IRoomRepository : IGetAllAsync<Room>, ICreateAsync<Room> { }
}
