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

		[HttpGet()]
		public IActionResult RetornarTodosEmprestimo()
		{
			try
			{
				return Ok(_emprestimoService.TodosEmprestimoAtivo());
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("{idUsuario}")]
		public IActionResult RetornarTodosEmprestimoAtivoPorUsuario([FromRoute] int idUsuario)
		{
			try
			{
				return Ok(_emprestimoService.TodosEmprestimoAtivo(idUsuario));
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost()]
		public IActionResult Cadastrar([FromBody] EmprestimoModel emprestimo)
		{
			try
			{
				_emprestimoService.Inserir(emprestimo);

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
