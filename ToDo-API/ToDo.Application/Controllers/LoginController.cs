using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;

namespace ToDo.Application.Controllers
{
	[Route("api/login")]
	public class LoginController : Controller
	{
		private readonly ILoginService _loginService;

		public LoginController(ILoginService loginService) => _loginService = loginService;

		[AllowAnonymous]
		[HttpPost]
		public IActionResult EfetuarLogin(
			[FromBody] CredenciaisModel credenciais)
		{
			return Ok(_loginService.EfetuarLogin(credenciais));
		}
	}
}
