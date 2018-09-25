using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quinelita.Data;
using Quinelita.Models;

namespace Quinelita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
		private readonly QuinelitaContext _context;

		public AuthController(QuinelitaContext context)
		{
			_context = context;
		}
		
		[Route("registrarse")]
		//[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Registrarse(RegisterModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(model);
			}

			var usuario = new Usuario {
				Email = model.Email				
			};

			if (!_context.Usuarios.Any(x => x.Email == model.Email))
			{
				_context.Usuarios.Add(usuario);
				await _context.SaveChangesAsync();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,usuario.Email),
                    new Claim(ClaimTypes.Name,usuario.Email),
                    new Claim(ClaimTypes.Email,usuario.Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return Ok();//devolver usuario insertado
			}
			else
			{
				return BadRequest("Usuario ya existe");
			}			

			//await SignInUser(user);

			//return CreatedAtAction("Get", new { id = usuario.Id }, usuario);

			
		}

        //[Route("login")]
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public async Task<IActionResult> LogIn(LogInModel model)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return View(model);
        //	}

        //	var user = await userService.Authenticate(model.Email, model.Password);
        //	if (user == null)
        //	{
        //		ModelState.AddModelError("InvalidCredentials", "Could not validate your credentials");
        //		return View(model);
        //	}

        //	return await SignInUser(user);
        //}

        [Route("salir")]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        //private async Task<IActionResult> SignInUser(User user)
        //{
        //	var claims = new List<Claim>
        //	{
        //		new Claim(ClaimTypes.NameIdentifier, user.Email),
        //		new Claim(ClaimTypes.Name, user.Username),
        //		new Claim(ClaimTypes.Email, user.Email),
        //	};
        //	var identity = new ClaimsIdentity(claims);
        //	var principal = new ClaimsPrincipal(identity);

        //	await HttpContext.SignInAsync(principal);

        //	return RedirectToAction("UserInformation", "Home");
        //}

        //[Route("loginexternal/{id}")]
        //public Task LogInExternal(string id)
        //{
        //	//return HttpContext.ChallengeAsync(id, new AuthenticationProperties { RedirectUri = "/userinfo" });
        //	return HttpContext.ChallengeAsync(id, new AuthenticationProperties { RedirectUri = "/auth/registerexternal" });
        //}

        //[Route("registerexternal")]
        //public async Task<IActionResult> RegisterExternal(string authprovider)
        //{
        //	var authResult = await HttpContext.AuthenticateAsync("TempCookie");
        //	if (!authResult.Succeeded)
        //	{
        //		return RedirectToAction("Index", "Home");
        //	}

        //	var user = await userService.AuthenticateExternal(authResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier));
        //	if (user != null)
        //	{
        //		return await SignInExternal(user);
        //	}

        //	return View(new RegisterExternalModel
        //	{
        //		Name = authResult.Principal.FindFirstValue(ClaimTypes.Name),
        //		Email = authResult.Principal.FindFirstValue(ClaimTypes.Email)
        //	});
        //}

        //[Route("registerexternal/{id}")]
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public async Task<IActionResult> RegisterExternal(string id, RegisterExternalModel model)
        //{
        //	var authResult = await HttpContext.AuthenticateAsync("TempCookie");
        //	if (!authResult.Succeeded)
        //	{
        //		return RedirectToAction("Index", "Home");
        //	}

        //	if (!ModelState.IsValid)
        //	{
        //		return View(model);
        //	}

        //	var user = await userService.AddExternal(authResult.Principal.FindFirstValue(ClaimTypes.NameIdentifier), model.Name, model.Email);

        //	return await SignInExternal(user);
        //}

        //private async Task<IActionResult> SignInExternal(User user)
        //{
        //	await HttpContext.SignOutAsync("TempCookie");
        //	return await SignInUser(user);
        //}



    }
}