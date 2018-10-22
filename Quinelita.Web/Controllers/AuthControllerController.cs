using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Quinelita.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public IActionResult Token()
        {
            var userClaims = new[] { new Claim(ClaimTypes.Name, "Luis Forero") };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("youKey"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                audience: "localhost:23456",
                issuer: "otro",
                expires: DateTime.Now.AddMinutes(3),
                claims: userClaims,
                signingCredentials: credential
                );

            return Ok(token);
        }
    }
}