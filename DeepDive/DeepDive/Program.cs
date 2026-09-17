using DeepDive.Data;
using DeepDive.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<EquipmentContext>();
            // Register repositories
            builder.Services.AddScoped<IMask_SnorkelRepository, Mask_SnorkelRepository>();
            builder.Services.AddScoped<IBCDRepository, BCDRepository>();
            builder.Services.AddScoped<ITankRepository, TankRepository>();
            builder.Services.AddScoped<IDivingSuitsRepository, DivingSuitRepository>();
            builder.Services.AddScoped<IRegulatorSetRepository, RegulatorSetRepository>();
            builder.Services.AddScoped<IFinnsRepository, FinnsRepository>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

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
