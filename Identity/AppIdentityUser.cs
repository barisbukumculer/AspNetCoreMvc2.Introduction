using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvc2.Introduction.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public int Age { get; set; }
    }
}
