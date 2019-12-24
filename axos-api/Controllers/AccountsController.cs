using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountsController
{
  private readonly UserManager<AppUser> _userManager;
  private readonly IMapper _mapper;
  private readonly AxosContext _context;
  public AccountsController(AxosContext context) => _context = context;

  [HttpGet]
  public string Ping() => "Desaparecer a los skywalkers fué un error";

  [HttpPost]
  public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
  {
    //TODO: Agregar validaciones | FluentAPI.
    var userIdentity = _mapper.Map<AppUser>(model);

    var result = await _userManager.CreateAsync(userIdentity, model.Password);

    await _context.Set<User>().AddAsync(new User { IdentityId = userIdentity.Id, Location = model.Location });
    await _context.SaveChangesAsync();

    return new OkObjectResult("Account created");
  }
}