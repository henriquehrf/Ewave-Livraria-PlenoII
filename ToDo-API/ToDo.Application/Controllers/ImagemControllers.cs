using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using ToDo.Domain.Interfaces.Service;
namespace ToDo.Application.Controllers
{
	[ApiController]
	[Authorize("Bearer")]
	[Route("api/imagem")]
	public class ImagemControllers : Controller
	{
		private readonly IImagemService _imagemService;

		public ImagemControllers(IImagemService imagemService)
		{
			_imagemService = imagemService;
		}

		[HttpPost]
		public IActionResult SalvarImagem([FromForm] IFormFile file)
		{
			try
			{
				return Ok(new { guid = _imagemService.SalvarImagem(file) });
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("{guid}")]
		public IActionResult RetornarImagem(string guid)
		{
			try
			{
				var imagem = _imagemService.CarregarImagem(guid);
				if (imagem == null)
					throw new FileNotFoundException("Imagem não encontrada!");

				return File(imagem, "image/jpeg");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{guid}")]
		public IActionResult RemoverImagem(string guid)
		{
			try
			{
				_imagemService.RemoverImagem(guid);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
