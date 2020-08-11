using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Domain.Entities;
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

		protected virtual void Inserir(T obj)
		{
			_toDoContext.Set<T>().Add(obj);
			_toDoContext.SaveChanges();
		}

		protected virtual void Alterar(T obj)
		{
			_toDoContext.Entry(obj).State = EntityState.Modified;
			_toDoContext.SaveChanges();
		}

		protected virtual void Excluir(int id)
		{
			_toDoContext.Set<T>().Remove(ById(id));
			_toDoContext.SaveChanges();
		}

		protected virtual IList<T> Todos() => _toDoContext.Set<T>().ToList();

		protected virtual IList<T> Filter(Expression<Func<T, bool>> predicate) => _toDoContext.Set<T>().Where(predicate).ToList();

		protected virtual T ById(int id)
		{
			var obj = _toDoContext.Set<T>().Find(id);
			if(obj != null)
				_toDoContext.Entry<T>(obj).State = EntityState.Detached;

			return obj;
		}
			
	}
}
