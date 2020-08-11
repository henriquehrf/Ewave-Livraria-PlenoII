using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;

namespace ToDo.Service.Service
{
	public class LivroService : ILivroService
	{
		private readonly ILivroRepository _livroRepository;

		public LivroService(ILivroRepository livroRepository)
		{
			_livroRepository = livroRepository;
		}

		public void Inserir(LivroModel livro) => _livroRepository.Inserir(livro);

		public void Alterar(LivroModel livro) => _livroRepository.Alterar(livro);

		public LivroModel ById(int id) => _livroRepository.ById(id);

		public IEnumerable<LivroModel> Todos() => _livroRepository.Todos();

		public IEnumerable<LivroModel> BuscarLivroPorTitulo(string titulo) => _livroRepository.BuscarLivroPorTitulo(titulo);
	}
}
