using Microsoft.EntityFrameworkCore;
using PhaseEndProject.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmpdbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Cust")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
