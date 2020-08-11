using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;

namespace ToDo.Application.Controllers
{
	[ApiController]
	[Authorize("Bearer")]
	[Route("api/livro")]
	public class LivroController : Controller
	{
		private readonly ILivroService _livroService;

		public LivroController(ILivroService livroService) => _livroService = livroService;

		[HttpGet]
		public IActionResult RetornarTodosLivros()
		{
			try
			{
				var livros = _livroService.Todos();
				return Ok(livros);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}

		[HttpGet("{titulo}")]
		public IActionResult BuscarLivroPorTitulo(string titulo)
		{
			try
			{
				return Ok(_livroService.BuscarLivroPorTitulo(titulo));

			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost]
		public IActionResult Cadastrar([FromBody] LivroModel livroModel)
		{
			try
			{
				_livroService.Inserir(livroModel);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPut]
		public IActionResult Alterar([FromBody] LivroModel livroModel)
		{
			try
			{
				_livroService.Alterar(livroModel);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}


	}
}
