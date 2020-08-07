using Microsoft.AspNetCore.Mvc;
using System;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace ToDo.Application.Controllers
{
	[ApiController]
	[Authorize("Bearer")]
	[Route("api/emprestimo")]
	public class EmprestimoController : Controller
	{
		private readonly IEmprestimoService _emprestimoService;

		public EmprestimoController(IEmprestimoService emprestimoService) => _emprestimoService = emprestimoService;

		[HttpGet("{idUsuario}")]
		public IActionResult RetornarTodosEmprestimoPorUsuario([FromRoute] int idUsuario)
		{
			try
			{
				return Ok(_emprestimoService.TodosPorUsuario(idUsuario));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost]
		public IActionResult Cadastrar([FromBody] EmprestimoModel emprestimoModel)
		{
			try
			{
				_emprestimoService.Inserir(emprestimoModel);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPut]
		public IActionResult Devolver([FromBody] EmprestimoModel emprestimoModel)
		{
			try
			{
				_emprestimoService.Devolver(emprestimoModel);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

	}
}
