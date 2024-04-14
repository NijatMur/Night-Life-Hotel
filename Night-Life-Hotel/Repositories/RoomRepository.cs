using Dapper;
using Night_Life_Hotel.Models;
using System.Data.SqlClient;

namespace Night_Life_Hotel.Repositories
{
    public class RoomRepository
    {
        private readonly string connectionString;

        public RoomRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Room>("Select * from Rooms");
        }   

    }
}
