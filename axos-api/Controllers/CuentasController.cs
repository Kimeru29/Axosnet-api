using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
// [EnableCors("MuereCors")]
public class CuentasController : ControllerBase
{
  private readonly AxosContext _context;

  public CuentasController(AxosContext context)
  {
    _context = context;
  }

  [HttpGet]
  public string Get() => "Hola";

  [HttpPost]
  // [EnableCors("MuereCors")]
  public int Registro(Usuario usuario)
  {
    _context.Set<Usuario>().Add(usuario);
    _context.SaveChanges();
    return usuario.Id;
  }
}

