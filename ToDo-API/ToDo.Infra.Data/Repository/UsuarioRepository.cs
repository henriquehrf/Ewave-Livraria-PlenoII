using System.Collections.Generic;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Data.Context;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Infra.Data.Repository
{
	public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
	{
		public UsuarioRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		public void Alterar(UsuarioModel usuario) => base.Alterar(usuario.ToEntity());

		public void Excluir(UsuarioModel usuario) => base.Excluir(usuario.Id);

		public void Inserir(UsuarioModel usuario) => base.Inserir(usuario.ToEntity());

		UsuarioModel IUsuarioRepository.ById(int id) => base.ById(id).ToModel();

		IEnumerable<UsuarioModel> IUsuarioRepository.Todos() => base.Todos().ToEnumerableModel();

	}
}
