using System.Collections.Generic;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Data.Context;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Infra.Data.Repository
{
	public class EmprestimoRepository : BaseRepository<Emprestimo, int>, IEmprestimoRepository
	{
		public EmprestimoRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		public void Inserir(EmprestimoModel emprestimo) => base.Inserir(emprestimo.ToEntity());

		public void Alterar(EmprestimoModel emprestimo) => base.Alterar(emprestimo.ToEntity());

		EmprestimoModel IEmprestimoRepository.ById(int id) => base.ById(id).ToModel();
		public IEnumerable<EmprestimoModel> TodosPorUsuario(int idUsuario) => Filter(t => t.IdUsuario == idUsuario).ToEnumerableModel();

		IEnumerable<EmprestimoModel> IEmprestimoRepository.Todos() => base.Todos().ToEnumerableModel();
	}
}
