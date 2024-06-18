using Microsoft.AspNetCore.Mvc;
using NightLifeHotelApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace NightLifeHotelApp.Controllers;

public class RoomsController : Controller
{
    private string jsonPath = "Data/rooms.json";

    private JsonSerializerOptions options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    [HttpGet]
    [ActionName("Index")]
    [Route("[controller]")]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await Deserialize(jsonPath);

        return View(model: rooms);
    }

    [HttpPost]
    [Route("[controller]")]
    public async Task<IActionResult> CreateRoom(Room room)
    {
        var rooms = await Deserialize(jsonPath);

        if (rooms.Count == 0)
        {
            return View(model: Enumerable.Empty<Room>());
        }

        room.Id = Guid.NewGuid();
        rooms.Add(room);

        Serialize(rooms, jsonPath);

        return RedirectToAction(nameof(Index));
    }

    private async Task<List<Room>> Deserialize(string path)
    {
        var roomsJsonExists = System.IO.File.Exists(path);
        if (!roomsJsonExists)
        {
            return Enumerable.Empty<Room>().ToList();
        }

        var roomsJson = await System.IO.File.ReadAllTextAsync(path);
        var rooms = JsonSerializer.Deserialize<List<Room>>(roomsJson, options);

        return rooms!;
    }

    private async void Serialize(List<Room> rooms, string path)
    {
        var resultRoomsJson = JsonSerializer.Serialize<List<Room>>(rooms, options);
        await System.IO.File.WriteAllTextAsync(path, resultRoomsJson);
    }
}