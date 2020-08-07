using System;

namespace ToDo.Domain.Entities
{
	public class Emprestimo : BaseEntity<int>
	{
		public Emprestimo(int id, int idUsuario, int idLivro, DateTime dataEmprestimo, DateTime? dataDevolucao, int status)
		{
			Id = id;
			IdUsuario = idUsuario;
			IdLivro = idLivro;
			DataEmprestimo = dataEmprestimo;
			DataDevolucao = dataDevolucao;
			Status = status;
		}

		public int IdUsuario { get; }
		public int IdLivro { get; }
		public DateTime DataEmprestimo { get; }
		public DateTime? DataDevolucao { get; }
		public int Status { get; }

		public virtual Usuario Usuario { get; }
		public virtual Livro Livro { get; }
	}
}
