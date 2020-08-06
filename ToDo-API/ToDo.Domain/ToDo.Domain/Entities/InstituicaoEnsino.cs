using System.Collections.Generic;
using ToDo.Domain.ValueTypes;

namespace ToDo.Domain.Entities
{
	public class InstituicaoEnsino : BaseEntity<int>
	{
		public Nome Nome { get; }
		public Endereco Endereco { get; }
		public Cnpj Cnpj { get; }
		public Telefone Telefone { get; }

		public virtual ICollection<Usuario> Usuarios { get; } = new HashSet<Usuario>();
	}
}
