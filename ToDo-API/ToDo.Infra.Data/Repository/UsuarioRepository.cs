using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

		public void Excluir(int id) => base.Excluir(id);

		public void Inserir(UsuarioModel usuario) => base.Inserir(usuario.ToEntity());

		UsuarioModel IUsuarioRepository.UsuarioPorLogin(string login) => Filter(u => u.Login == login).SingleOrDefault()?.ToModel();

		IEnumerable<UsuarioModel> IUsuarioRepository.Todos()
		{
			return _toDoContext.Usuarios.Include(u => u.InstituicaoEnsino).ToList().ToEnumerableModel();
		}

		public IEnumerable<UsuarioModel> UsuarioPorNome(string nome)
		{
			if (string.IsNullOrWhiteSpace(nome)) return Todos().ToEnumerableModel();

			//TODO: Investigar EF Linq Error after change from dotnet Core 2.2.6 to 3.0.0

			return Todos().Where(t=>t.Nome.ToString().ToLowerInvariant().Contains(nome.ToLowerInvariant())).ToList().ToEnumerableModel();
		}

		public UsuarioModel UsuarioPorId(int id) => base.ById(id).ToModel();
		
	}
}
