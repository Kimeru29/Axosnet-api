//TODO: Separar datos de Usuario con datos usados en la lógica de cuenta
//      usar EF Core para ello.
using System.Collections.Generic;

public class Usuario
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public string Apellido { get; set; }
  public string Correo { get; set; }
  public string Password { get; set; }

  public Genero Genero { get; set; }
  public virtual IEnumerable<Recibo> Recibos { get; set; }
}