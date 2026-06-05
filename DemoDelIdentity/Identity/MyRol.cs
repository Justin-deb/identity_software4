using Microsoft.AspNetCore.Identity;

namespace DemoIdentity.Identity
{
    public class MyRol:IdentityRole
    {
        public String Seccion { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
