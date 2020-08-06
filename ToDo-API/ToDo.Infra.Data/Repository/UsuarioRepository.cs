using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
	public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
	{
		public UsuarioRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}
	}
}
