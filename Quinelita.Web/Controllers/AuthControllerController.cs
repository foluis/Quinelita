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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Your very big key"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                audience: "localhost:23456",
                issuer: "otro",
                expires: DateTime.Now.AddMinutes(3),
                claims: userClaims,
                signingCredentials: credential
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(tokenString);
        }

        [HttpPost("token2")]
        public IActionResult Token2()
        {

            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("basic".Length).Trim();
                var userCredential = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                var userNameNpass = userCredential.Split(':');

                //verify from database
                var authorize = ValidateUserPassword(userNameNpass[0], userNameNpass[1]);

                if (authorize)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecurityKeyFromApp.config.js"));
                    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                    var userClaims = new[]
                    {
                        new Claim(
                            ClaimTypes.Name, "Luis Forero"
                        ),
                        new Claim(
                            ClaimTypes.MobilePhone, "12345678"
                        ),
                        new Claim(
                            ClaimTypes.Role, "1"
                        )
                        ,
                        new Claim(
                            ClaimTypes.UserData,"mas cosas, se puede json?"
                        )
                    };

                    var token = new JwtSecurityToken(
                        audience: "localhost:44322",
                        issuer: "localhost:44322",
                        expires: DateTime.Now.AddMinutes(9),
                        claims: userClaims,
                        signingCredentials: signingCredentials
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(tokenString);
                }
            }

            return BadRequest("Usuario o clave invalidos");
        }

        private bool ValidateUserPassword(string user, string pws)
        {
            if (user == "luis" && pws == "clave")
                return true;

            return false;
        }
    }
}