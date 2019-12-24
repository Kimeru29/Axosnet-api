
using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
  public string Nombre { get; set; }
  public string Apellido { get; set; }
  public long? FacebookId { get; set; }
  public string UrlFoto { get; set; }
}