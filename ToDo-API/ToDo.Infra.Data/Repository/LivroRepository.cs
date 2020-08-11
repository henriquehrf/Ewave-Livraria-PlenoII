using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Data.Context;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Infra.Data.Repository
{
	public class LivroRepository : BaseRepository<Livro, int>, ILivroRepository
	{
		public LivroRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		public void Inserir(LivroModel livro) => base.Inserir(livro.ToEntity());

		public void Alterar(LivroModel livro) => base.Alterar(livro.ToEntity());


		LivroModel ILivroRepository.ById(int id) => base.ById(id).ToModel();

		IEnumerable<LivroModel> ILivroRepository.Todos() => base.Todos().ToEnumerableModel();

		public IEnumerable<LivroModel> BuscarLivroPorTitulo(string titulo)
		{
			if (string.IsNullOrWhiteSpace(titulo)) return Todos().ToEnumerableModel();

			//TODO: Investigar EF Linq Error after change from dotnet Core 2.2.6 to 3.0.0

			return Todos().Where(t => t.Titulo.ToString().ToLowerInvariant().Contains(titulo.ToLowerInvariant())).ToList().ToEnumerableModel();
		}
	}
}
