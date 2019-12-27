using System;

//TODO: Agregar explícitamente el Id MetodoPago.
public class Recibo
{
  public int Id { get; set; }
  public int ProvedorId { get; set; }
  public int UsuarioId { get; set; }
  public decimal Monto { get; set; }
  public MetodoPago MétodoDePago { get; set; }
  public DateTime Fecha { get; set; }
  public string Comentario { get; set; }

  public Provedor Provedor { get; set; }
  public Usuario Usuario { get; set; }

}