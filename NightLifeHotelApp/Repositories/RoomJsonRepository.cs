using NightLifeHotelApp.Models;
using NightLifeHotelApp.Repositories.Base;
using System.Text.Json;

namespace NightLifeHotelApp.Repositories
{
    public class RoomJsonRepository : IRoomRepository
    {
        private readonly string path = "Data/rooms.json";
        private readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
        private string? roomsJson = string.Empty;
        private List<Room> rooms = Enumerable.Empty<Room>().ToList();

        public RoomJsonRepository() { }

        public async Task<IEnumerable<Room>?> GetAllAsync()
        {
            //Нет смысла использовать File.Exists
            try
            {
                roomsJson = await File.ReadAllTextAsync(path);
                rooms = JsonSerializer.Deserialize<List<Room>>(roomsJson, options) ?? Enumerable.Empty<Room>().ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return rooms;
        }

        public async Task CreateAsync(Room newRoom)
        {
            try
            {
                roomsJson = await File.ReadAllTextAsync(path);
                rooms = JsonSerializer.Deserialize<List<Room>>(roomsJson, options) ?? Enumerable.Empty<Room>().ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            rooms.Add(newRoom);

            var resultRoomsJson = JsonSerializer.Serialize<List<Room>>(rooms, options);
            await File.WriteAllTextAsync(path, resultRoomsJson);
        }
    }
}
