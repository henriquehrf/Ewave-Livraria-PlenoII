using System.Collections.Generic;

namespace ToDo.Domain.Entities
{
	public class Livro : BaseEntity<int>
	{
		public string Titulo { get; }
		public string Genero { get; }
		public string Autor { get; }
		public string Sinopse { get; }
		//public string Capa { get; }
		public bool Disponibilidade { get; }
		public bool Ativo { get; }

		public virtual ICollection<Emprestimo> Emprestimos { get; } = new HashSet<Emprestimo>();
	}
}
