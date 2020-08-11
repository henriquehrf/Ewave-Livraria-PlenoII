using System;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace ToDo.Application.Controllers
{
	[ApiController]
	[Authorize("Bearer")]
	[Route("api/instituicao-ensino")]
	public class InstituicaoEnsinoController : Controller
	{
		private readonly IInstituicaoEnsinoService _institucaoEnsinoService;
		public InstituicaoEnsinoController(IInstituicaoEnsinoService institucaoEnsinoService) => _institucaoEnsinoService = institucaoEnsinoService;

		[HttpGet]
		public IActionResult RetornarTodosInstituicoesEnsino()
		{
			try
			{
				var instituicoes = _institucaoEnsinoService.TodosInstituicoesEnsino();
				return Ok(instituicoes);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}

		[HttpGet("{nome}")]
		public IActionResult RetornarInstituicaoEnsinoPeloNome(string nome)
		{
			try
			{
				var instituicoes = _institucaoEnsinoService.BuscarInstituicoesPorNome(nome);
				return Ok(instituicoes);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}

		[HttpPost]
		public IActionResult Cadastrar([FromBody] InstituicaoEnsinoModel instituicaoEnsinoModel)
		{
			try
			{
				_institucaoEnsinoService.Inserir(instituicaoEnsinoModel);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPut]
		public IActionResult Alterar([FromBody] InstituicaoEnsinoModel instituicaoEnsinoModel)
		{
			try
			{
				_institucaoEnsinoService.Alterar(instituicaoEnsinoModel);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Excluir(int id)
		{
			try
			{
				_institucaoEnsinoService.Excluir(id);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
