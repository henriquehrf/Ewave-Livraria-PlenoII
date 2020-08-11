using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using ToDo.Domain.Interfaces.Service;

namespace ToDo.Service.Service
{
	public class ImagemService : IImagemService
	{
		private readonly string SERVER_PATH = "C:\\Images\\";
		public byte[] CarregarImagem(string guid)
		{
			var pathFile = string.Concat(SERVER_PATH, guid, "\\");

			if (!Directory.Exists(pathFile))
				return default;

			return File.ReadAllBytes(Directory.GetFiles(pathFile).SingleOrDefault());
		}

		public void RemoverImagem(string guid)
		{
			var pathFile = string.Concat(SERVER_PATH, guid.ToString(), "\\");

			if (!Directory.Exists(pathFile))
				return;

			Directory.Delete(pathFile);
		}

		public string SalvarImagem(IFormFile file)
		{
			var guid = Guid.NewGuid().ToString();
			var pathFile = string.Concat(SERVER_PATH, guid.ToString(), "\\");

			if (!Directory.Exists(pathFile))
				Directory.CreateDirectory(pathFile);

			string path = Path.Combine(pathFile, file.FileName);
			using var stream = new FileStream(path, FileMode.Create);
			file.CopyTo(stream);

			return guid;
		}
	}
}
