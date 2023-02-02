using Microsoft.AspNetCore.Identity;

namespace TextGameAPI.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() { }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
