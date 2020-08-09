using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;

namespace ToDo.Application.Controllers
{
	[ApiController]
	//[Authorize("Bearer")]
	[Route("api/usuario")]
	public class UsuarioController : Controller
	{
		private readonly IUsuarioService _usuarioService;
		public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;

		[HttpGet]
		public IActionResult RetornarTodosUsuarios()
		{
			try
			{
				var usuario = _usuarioService.TodosUsuarios();
				return Ok(usuario);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}

		[HttpGet("{nome}")]
		public IActionResult RetornarUsuarioPeloNome(string nome)
		{
			try
			{
				var usuarios = _usuarioService.BuscarUsuarioPorNome(nome);
				return Ok(usuarios);
			}
			catch (Exception ex)
			{

				return BadRequest(ex);
			}
		}

		[HttpPost]
		public IActionResult Cadastrar([FromBody] UsuarioModel usuarioModel)
		{
			try
			{
				_usuarioService.Inserir(usuarioModel);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPut]
		public IActionResult Alterar([FromBody] UsuarioModel usuarioModel)
		{
			try
			{
				_usuarioService.Alterar(usuarioModel);

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
				_usuarioService.Excluir(id);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}
