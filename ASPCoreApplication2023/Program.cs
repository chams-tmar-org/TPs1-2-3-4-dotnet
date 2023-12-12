using ASPCoreApplication2023.Models;
using ASPCoreApplication2023.Repositories;
using ASPCoreApplication2023.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<MovieRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"
)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // route par defaut 
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // L’ajout d’une route pour l'action ByRelease
    endpoints.MapControllerRoute(
        name: "moviesByRelease",
        pattern: "Movie/released/{year}/{month}",
        defaults: new { controller = "Movies", action = "ByRelease" });

    endpoints.MapControllerRoute(
        name: "customerDetails",
        pattern: "Movies/CustomerDetails/{id}",
        defaults: new { controller = "Movies", action = "CustomerDetails" });
});


app.Run();
