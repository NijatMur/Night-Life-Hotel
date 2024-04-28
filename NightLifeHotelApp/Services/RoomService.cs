using NightLifeHotelApp.Models;
using NightLifeHotelApp.Repositories.Base;
using NightLifeHotelApp.Services.Base;

namespace NightLifeHotelApp.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository ;
        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>?> GetAllAsync()
        {
            return await this.roomRepository.GetAllAsync();
        }

        public async Task CreateAsync(Room newEntity)
        {
            await this.roomRepository.CreateAsync(newEntity);
        }
    }
}
