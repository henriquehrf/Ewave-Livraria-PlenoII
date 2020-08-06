using Microsoft.VisualBasic;
using System;
using ToDo.Domain.ValueTypes;

namespace ToDo.Domain.Entities
{
	public class Usuario : BaseEntity<int>
	{

		public Nome Nome { get; }
		public Endereco Endereco { get; }
		public Cpf Cpf { get; }
		public Telefone Telefone { get; }
		public Email Email { get; }
		public string Login { get; }
		public string Senha { get; }
		public DateTime? DataMinimaProximoEmprestimo { get; }

	}
}
