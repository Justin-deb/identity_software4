using Microsoft.AspNetCore.Identity;

namespace DemoIdentity.Identity
{
    public class MyUser: IdentityUser
    {
        public int NCedula { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
