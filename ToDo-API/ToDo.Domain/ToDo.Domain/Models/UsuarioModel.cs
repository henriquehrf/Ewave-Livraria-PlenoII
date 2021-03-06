﻿using System;
using ToDo.Domain.Enum;

namespace ToDo.Domain.Models
{
	public class UsuarioModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Cpf { get; set; }
		public int InstituicaoEnsinoId { get; set; }
		public string InstituicaoEnsinoDescricao { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public int PerfilUsuario { get; set; }
		public string PerfilUsuarioDescricao
		{
			get
			{
				if (PerfilUsuario == PerfilUsuarioEnum.Administrador.GetHashCode())
					return "Administrador";

				return "Usuário Comum";
			}
		}
		public string Login { get; set; }
		public string Senha { get; set; }
		public DateTime? DataSuspencao { get; set; }
	}
}
