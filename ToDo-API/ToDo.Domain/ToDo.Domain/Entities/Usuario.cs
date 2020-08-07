using System;
using System.Collections.Generic;
using ToDo.Domain.ValueTypes;

namespace ToDo.Domain.Entities
{
	public class Usuario : BaseEntity<int>
	{
		public Usuario(int id,
					   Nome nome,
					   Endereco endereco,
					   Cpf cpf,
					   Telefone telefone,
					   Email email,
					   string login,
					   string senha,
					   DateTime? dataMinimaProximoEmprestimo,
					   int idInstituicaoEnsino)
		{
			Id = id;
			Nome = nome;
			Endereco = endereco;
			Cpf = cpf;
			Telefone = telefone;
			Email = email;
			Login = login;
			Senha = senha;
			DataMinimaProximoEmprestimo = dataMinimaProximoEmprestimo;
			IdInstituicaoEnsino = idInstituicaoEnsino;

			AddNotifications(
				nome.Contract,
				endereco.Contract,
				cpf.Contract,
				telefone.Contract,
				email.Contract);
		}

		public Nome Nome { get; }
		public Endereco Endereco { get; }
		public Cpf Cpf { get; }
		public Telefone Telefone { get; }
		public Email Email { get; }
		public string Login { get; }
		public string Senha { get; }
		public DateTime? DataMinimaProximoEmprestimo { get; }

		public int IdInstituicaoEnsino { get; }

		public virtual InstituicaoEnsino InstituicaoEnsino { get; }

		public virtual ICollection<Emprestimo> Emprestimos { get; } = new HashSet<Emprestimo>();

	}
}
