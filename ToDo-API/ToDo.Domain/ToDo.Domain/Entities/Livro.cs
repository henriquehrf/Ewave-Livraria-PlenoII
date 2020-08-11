using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Entities
{
	public class Livro : BaseEntity<int>
	{
		public Livro(int id, string titulo, string genero, string autor, string sinopse,string guidCapa, bool disponibilidade, bool ativo)
		{
			Id = id;
			Titulo = titulo;
			Genero = genero;
			Autor = autor;
			Sinopse = sinopse;
			Disponibilidade = disponibilidade;
			Ativo = ativo;
			GuidCapa = guidCapa;
		}

		public string Titulo { get; }
		public string Genero { get; }
		public string Autor { get; }
		public string Sinopse { get; }
		public string GuidCapa { get; }
		public bool Disponibilidade { get; }
		public bool Ativo { get; }

		public virtual ICollection<Emprestimo> Emprestimos { get; } = new HashSet<Emprestimo>();
	}
}
