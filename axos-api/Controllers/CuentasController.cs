using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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

  [HttpGet, Authorize]
  public IEnumerable<string> Get()
  {
    return new string[] { "John Doe", "Jane Doe" };
  }

  [HttpPost]
  // [EnableCors("MuereCors")]
  public int Registro(Usuario usuario)
  {
    _context.Set<Usuario>().Add(usuario);
    _context.SaveChanges();
    return usuario.Id;
  }

  [HttpGet, Route("usuario")]
  public Usuario GetUsuario(string correo) => _context.Set<Usuario>().Where(u => u.Correo == correo).FirstOrDefault();
}

