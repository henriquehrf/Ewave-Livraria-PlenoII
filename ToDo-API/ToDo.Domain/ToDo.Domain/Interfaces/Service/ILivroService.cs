using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Service
{
	public interface ILivroService
	{
		void Inserir(LivroModel livro);
		void Alterar(LivroModel livro);
		LivroModel ById(int id);
		IEnumerable<LivroModel> Todos();
		IEnumerable<LivroModel> BuscarLivroPorTitulo(string titulo);
	}
}
