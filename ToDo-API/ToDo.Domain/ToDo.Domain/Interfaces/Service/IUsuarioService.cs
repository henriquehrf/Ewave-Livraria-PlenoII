using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IUsuarioService
	{
		void Inserir(UsuarioModel usuario);
		void Alterar(UsuarioModel usuario);
		void Excluir(int id);
		UsuarioModel UsuarioPorLogin(string login);
		IEnumerable<UsuarioModel> BuscarUsuarioPorNome(string nome);
		IEnumerable<UsuarioModel> TodosUsuarios();
	}
}
