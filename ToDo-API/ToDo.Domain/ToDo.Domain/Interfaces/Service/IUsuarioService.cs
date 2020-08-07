using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IUsuarioService
	{
		void Inserir(UsuarioModel usuario);
		void Alterar(UsuarioModel usuario);
		void Excluir(UsuarioModel usuario);
		UsuarioModel UsuarioPorLogin(string login);
		IEnumerable<UsuarioModel> TodosUsuarios();
	}
}
