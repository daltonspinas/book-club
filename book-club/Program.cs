using book_club.Database.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SpaServices.Extensions;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<BookClubContext>(
//    options => options.UseSqlite(builder.Configuration.GetConnectionString("book_club_sqlite")));

var connection = new SqliteConnection(builder.Configuration.GetConnectionString("book_club_sqlite"));
connection.Open();
connection.EnableExtensions(true);
builder.Services.AddDbContext<BookClubContext>(options => options.UseSqlite(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "ClientApp";
        spa.UseReactDevelopmentServer(npmScript: "start");
    });
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
