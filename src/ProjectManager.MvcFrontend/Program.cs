using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcProject.WebApplication.Data;
using MvcProject.WebApplication.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcProjectWebApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcProjectWebApplicationContext") ?? throw new InvalidOperationException("Connection string 'MvcProjectWebApplicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
