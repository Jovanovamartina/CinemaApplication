
using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Repositories.Data;
using CinemaAppMVC.Repositories.Implementation;
using CinemaAppMVC.Services.Abstraction;
using CinemaAppMVC.Services.Implementation;
using DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementation;
using Services.Abstraction;
using Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddMvcCore().AddApiExplorer();

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// sql
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

//Dependency Injection
builder.Services.AddTransient<IRepository<CinemaHall>, CinemaHallRepository>();
builder.Services.AddTransient<IRepository<MovieProgram>, MovieProgramRepository>();
builder.Services.AddTransient<IRepository<Movie>, MovieRepository>();
builder.Services.AddTransient<IRepository<Reservation>, ReservationRepository>();
builder.Services.AddTransient<IRepository<Size>, SizeRepository>();
builder.Services.AddTransient<IRepository<SnackOrder>, SnackOrderRepository>();
builder.Services.AddTransient<IRepository<Snack>, SnackRepository>();

builder.Services.AddTransient<ICinemaHallService, CinemaHallService>();
builder.Services.AddTransient<IMovieProgramService, MovieProgramService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddTransient<ISizeService, SizeService>();
builder.Services.AddTransient<ISnackService, SnackService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
//seed data
using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}
app.Run();
