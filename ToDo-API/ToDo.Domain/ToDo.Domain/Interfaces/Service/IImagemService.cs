using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IImagemService
	{
		string SalvarImagem(IFormFile file);
		Byte[] CarregarImagem(string guid);
		void RemoverImagem(string guid);
	}
}
