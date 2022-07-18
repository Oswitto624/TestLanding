using Microsoft.EntityFrameworkCore;
using TestLanding.DAL.Context;
using TestLanding.Interfaces;
using TestLanding.Services.Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Services.AddControllersWithViews();

var configuration = builder.Configuration;

services.AddDbContext<TestLandingDB>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServer")));

services.AddTransient<IDbInitializer, DbInitializer>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await db_initializer.InitializeAsync(RemoveBefore: false);
}

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
