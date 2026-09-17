using Microsoft.AspNetCore.Identity;

namespace DeepDive.Data
{
    public  static class SeedAdmin
    {
        public static void Seed(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Opret rollen, hvis den ikke findes
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            }

            // Opret admin, hvis den ikke findes
            var admin = userManager.FindByEmailAsync("admin@deepdive.dk").Result;
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@deepdive.dk",
                    Email = "admin@deepdive.dk",
                    EmailConfirmed = true
                };

                userManager.CreateAsync(admin, "Admin123!").Wait();
                userManager.AddToRoleAsync(admin, "Admin").Wait();
            }
        }
    }
}
