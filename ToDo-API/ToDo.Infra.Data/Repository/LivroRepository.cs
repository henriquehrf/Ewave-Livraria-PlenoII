using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
	public class LivroRepository : BaseRepository<Livro, int>, ILivroRepository
	{
		public LivroRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}
	}
}
