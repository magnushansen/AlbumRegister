using Microsoft.EntityFrameworkCore;
using AlbumRegister.Data;
using AlbumRegister.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AlbumContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AlbumContext") ?? throw new InvalidOperationException("Connection string 'AlbumContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();