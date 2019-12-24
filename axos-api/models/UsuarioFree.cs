public class User
{
  public int Id { get; set; }
  public string IdentityId { get; set; }
  public AppUser Identity { get; set; }
  public string Locale { get; set; }
  public string Location { get; set; }
  public Genero Genero { get; set; }
}