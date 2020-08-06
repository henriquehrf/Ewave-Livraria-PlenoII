using System;

namespace ToDo.Domain.Entities
{
	public class Emprestimo : BaseEntity<int>
	{
		public int IdUsuario { get; }
		public int IdLivro { get; }
		public DateTime DataEmprestimo { get; }
		public DateTime? DataDevolucao { get; }
		public int Status { get; }

		public virtual Usuario Usuario { get; }
		public virtual Livro Livro { get; }
	}
}
