using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
	public class InstituicaoEnsinoRepository : BaseRepository<InstituicaoEnsino, int>, IInstituicaoEnsinoRepository
	{
		public InstituicaoEnsinoRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}
	}
}
