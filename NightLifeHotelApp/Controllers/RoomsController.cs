using Microsoft.AspNetCore.Mvc;
using NightLifeHotelApp.Models;
using NightLifeHotelApp.Services.Base;

namespace NightLifeHotelApp.Controllers;

public class RoomsController : Controller
{
    private readonly IRoomService roomService;
    public RoomsController(IRoomService roomService)
    {
        this.roomService = roomService;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> Index()
    {
        var rooms = await this.roomService.GetAllAsync();

        return base.View(model: rooms);
    }

    [HttpPost]
    [Route("[controller]")]
    public IActionResult CreateRoom(Room room)
    {
        this.roomService.CreateAsync(room);

        return base.RedirectToAction(nameof(Index));
    }
}