using NightLifeHotelApp.Repositories;
using NightLifeHotelApp.Repositories.Base;
using NightLifeHotelApp.Services;
using NightLifeHotelApp.Services.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRoomRepository, RoomJsonRepository>();
builder.Services.AddTransient<IRoomService, RoomService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
