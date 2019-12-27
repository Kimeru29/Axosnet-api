using System.Collections.Generic;

public class Provedor
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public IEnumerable<Recibo> Recibos { get; set; }
}