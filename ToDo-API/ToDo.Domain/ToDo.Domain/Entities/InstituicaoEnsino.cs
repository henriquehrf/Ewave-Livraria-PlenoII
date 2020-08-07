using System.Collections.Generic;
using ToDo.Domain.ValueTypes;

namespace ToDo.Domain.Entities
{
	public class InstituicaoEnsino : BaseEntity<int>
	{
		public InstituicaoEnsino(int id, Nome nome, Endereco endereco, Cnpj cnpj, Telefone telefone)
		{
			Id = id;
			Nome = nome;
			Endereco = endereco;
			Cnpj = cnpj;
			Telefone = telefone;

			AddNotifications(
				nome.Contract,
				endereco.Contract,
				cnpj.Contract,
				telefone.Contract
				);
		}

		public Nome Nome { get; }
		public Endereco Endereco { get; }
		public Cnpj Cnpj { get; }
		public Telefone Telefone { get; }

		public virtual ICollection<Usuario> Usuarios { get; } = new HashSet<Usuario>();
	}
}
