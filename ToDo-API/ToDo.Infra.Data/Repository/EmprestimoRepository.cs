using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
	public class EmprestimoRepository : BaseRepository<Emprestimo, int>, IEmprestimoRepository
	{
		public EmprestimoRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}
	}
}
