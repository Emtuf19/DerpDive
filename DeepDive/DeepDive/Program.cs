using DeepDive.Data;
using DeepDive.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DeepDive.Services;

namespace DeepDive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Bruger til kurven. Kurven bliver gemt i sessionen
            builder.Services.AddSession();

            builder.Services.AddDbContext<EquipmentContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

            //Login
            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<EquipmentContext>();
            
            //API
            builder.Services.AddHttpClient("GeocodingClient", (httpClient) => { httpClient.BaseAddress = new Uri("https://api.api-ninjas.com/v1/geocoding"); 
                httpClient.DefaultRequestHeaders.Add("X-Api-Key", "TKIWMkwNraRx8HHDCl6b9Yqhhx41qHfNxVNF6udB"); });

            builder.Services.AddHttpClient("WeatherClient", (httpClient) => { httpClient.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast"); });
            builder.Services.AddHttpClient("MarineClient", (httpClient) => { httpClient.BaseAddress = new Uri("https://marine-api.open-meteo.com/v1/marine"); });

            // Register repositories
            builder.Services.AddScoped<IMask_SnorkelRepository, Mask_SnorkelRepository>();
            builder.Services.AddScoped<IBCDRepository, BCDRepository>();
            builder.Services.AddScoped<ITankRepository, TankRepository>();
            builder.Services.AddScoped<IDivingSuitsRepository, DivingSuitRepository>();
            builder.Services.AddScoped<IRegulatorSetRepository, RegulatorSetRepository>();
            builder.Services.AddScoped<IFinnsRepository, FinnsRepository>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<ICompleteWeatherService, ComlpeteWeatherService>();

            var app = builder.Build();
            SeedAdmin.Seed(app.Services);



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Tilføjet for at kunne bruge sessionen i applikationen
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapRazorPages();

            app.Run();
        }
    }
}
