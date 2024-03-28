using Night_Life_Hotel.Repositories;
using System.Net;
using System.Text.Json;

const string connectionString = "Server=localhost;Initial Catalog=NightLifeHotelDB;Integrated Security=true;TrustServerCertificate=True";
var roomRepository = new RoomRepository(connectionString);

var httpListener = new HttpListener();
var prefix = $"http://localhost:8080/";

httpListener.Prefixes.Add(prefix);
httpListener.Start();
Console.WriteLine($"Server started on {prefix}");

while (true)
{
    var client = await httpListener.GetContextAsync();
    string endpoint = client.Request.RawUrl;

    switch (endpoint)
    {
        case "/":
            {
                client.Response.ContentType = "application/json";
                using var streamWriter = new StreamWriter(client.Response.OutputStream);

                var allRooms = await roomRepository.GetAllRooms();

                if (allRooms is null)
                {
                    string message = "No hotel rooms in database";
                    await streamWriter.WriteLineAsync(JsonSerializer.Serialize(message));
                    break;
                }

                await streamWriter.WriteLineAsync(JsonSerializer.Serialize(allRooms));
                client.Response.StatusCode = (int)HttpStatusCode.OK;

                break;
            }

        default:
            {
                client.Response.ContentType = "application/json";
                using var streamWriter = new StreamWriter(client.Response.OutputStream);

                string outputMessage = "wtf?";
                await streamWriter.WriteLineAsync(JsonSerializer.Serialize(outputMessage));

                break;
            }
    }

    client.Response.Close();
}