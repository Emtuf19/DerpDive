using DeepDive.Data;
using DeepDive.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DeepDive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EquipmentContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
            // Register repositories
            builder.Services.AddScoped<IMask_SnorkelRepository, Mask_SnorkelRepository>();
            builder.Services.AddScoped<IBCDRepository, BCDRepository>();
            builder.Services.AddScoped<ITankRepository, TankRepository>();
            builder.Services.AddScoped<IDivingSuitsRepository, DivingSuitRepository>();
            builder.Services.AddScoped<IRegulatorSetRepository, RegulatorSetRepository>();
            builder.Services.AddScoped<IFinnsRepository, FinnsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
