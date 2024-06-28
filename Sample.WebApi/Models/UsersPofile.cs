using Microsoft.AspNetCore.Identity;

namespace Sample.WebApi.Models
{
    public class UserPofile: IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string ProfilePicture { get; set; }
        public string? UserPassword { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
