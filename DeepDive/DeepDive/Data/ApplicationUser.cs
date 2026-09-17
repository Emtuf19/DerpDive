using DeepDive.Models;
using Microsoft.AspNetCore.Identity;
namespace DeepDive.Data;
// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public List<Booking>? Bookings { get; set; } 
}
