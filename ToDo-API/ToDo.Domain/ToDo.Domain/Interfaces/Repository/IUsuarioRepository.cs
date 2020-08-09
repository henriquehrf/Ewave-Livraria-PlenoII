using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
	public interface IUsuarioRepository
	{
		void Inserir(UsuarioModel usuario);
		void Alterar(UsuarioModel usuario);
		void Excluir(int id);
		UsuarioModel UsuarioPorLogin(string login);
		IEnumerable<UsuarioModel> Todos();
		IEnumerable<UsuarioModel> UsuarioPorNome(string nome);
	}
}
