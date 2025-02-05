using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Commands;
using TaskManagement.Core.Handlers;
using TaskManagement.Core.Interfaces;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? conection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskManDbContext>(c => c.UseMySql(
    conection,
    new MySqlServerVersion(new Version(8, 0, 21))
    ,op => op.EnableRetryOnFailure())
);

builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateTaskHandler).Assembly));

builder.Services.AddScoped<ITaskRepository,TaskRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
