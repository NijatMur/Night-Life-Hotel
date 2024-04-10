using Microsoft.AspNetCore.Mvc;

namespace NightLifeHotelApp.Controllers;

public class RoomsController : Controller
{
    // GET: RoomController
    public IActionResult Index()
    {
        return View();
    }
}
