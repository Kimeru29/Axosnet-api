using System;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReciboController : ControllerBase
{
  private readonly AxosContext _context;

  public ReciboController(AxosContext context) =>
    _context = context;

  [HttpPost]
  public int GuardarRecibo(Recibo recibo)
  {
    recibo.Fecha = DateTime.Now;
    _context.Set<Recibo>().Add(recibo);
    _context.SaveChanges();
    return recibo.Id;
  }
}
