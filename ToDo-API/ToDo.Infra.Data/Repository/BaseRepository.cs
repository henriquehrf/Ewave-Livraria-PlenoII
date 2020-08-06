using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repository
{
	public class BaseRepository<T, K> where T : BaseEntity<K>
	{
		protected readonly ToDoContext _toDoContext;

		public BaseRepository(ToDoContext toDoContext)
		{
			_toDoContext = toDoContext;
		}

		protected virtual void Insert(T obj)
		{
			_toDoContext.Set<T>().Add(obj);
			_toDoContext.SaveChanges();
		}

		protected virtual void Update(T obj)
		{
			_toDoContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_toDoContext.SaveChanges();
		}

		protected virtual void Delete(int id)
		{
			_toDoContext.Set<T>().Remove(Select(id));
			_toDoContext.SaveChanges();
		}

		protected virtual IList<T> Select() => _toDoContext.Set<T>().ToList();

		protected virtual T Select(int id) =>
			_toDoContext.Set<T>().Find(id);
	}
}
