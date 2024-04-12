using Microsoft.AspNetCore.Mvc;
using NightLifeHotelApp.Models;
using System.Text.Json;

namespace NightLifeHotelApp.Controllers;

public class RoomsController : Controller
{
    // GET: RoomController
    [HttpGet]
    [Route("[controller]")]
    public IActionResult Index()
    {
        return View();
    }

    // POST: RoomController
    [HttpPost]
    [Route("[controller]")]
    public async Task<IActionResult> Create(Room room) //IFormCollection
    {
        var roomsJson = await System.IO.File.ReadAllTextAsync(path: "Data/rooms.json");
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
        var rooms = JsonSerializer.Deserialize<List<Room>>(roomsJson, options);

        room.Id = Guid.NewGuid();
        rooms?.Add(room);

        var resultRoomsJson = JsonSerializer.Serialize<List<Room>>(rooms!, options);
        await System.IO.File.WriteAllTextAsync(path: "Data/rooms.json", resultRoomsJson);

        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
