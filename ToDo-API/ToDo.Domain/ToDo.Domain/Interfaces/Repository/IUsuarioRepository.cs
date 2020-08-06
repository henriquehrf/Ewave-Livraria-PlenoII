using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
	public interface IUsuarioRepository
	{
		void Inserir(UsuarioModel usuario);
		void Alterar(UsuarioModel usuario);
		void Excluir(UsuarioModel usuario);
		UsuarioModel ById(int id);
		IEnumerable<UsuarioModel> Todos();
	}
}
