using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
  [HttpPost, Route("login")]
  public IActionResult Login([FromBody]Usuario user)
  {
    if (user == null)
      return BadRequest();

    //TODO: Chequeo real.
    if (user.Correo == "p" && user.Password == "p")
    {
      var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@99"));
      var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

      var tokeOptions = new JwtSecurityToken(
          issuer: "http://localhost:5000",
          audience: "http://localhost:5000",
          claims: new List<Claim>(),
          expires: DateTime.Now.AddDays(1),
          signingCredentials: signinCredentials
      );

      var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
      return Ok(new { Token = tokenString });
    }
    else
    {
      return Unauthorized();
    }
  }
}