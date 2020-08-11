using System.Collections.Generic;
using ToDo.Domain.Entities;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
	public interface IEmprestimoRepository
	{
		void Inserir(EmprestimoModel emprestimo);
		void Alterar(EmprestimoModel emprestimo);
		EmprestimoModel ById(int id);
		IEnumerable<EmprestimoModel> TodosEmprestimoAtivo(int? idUsuario = null);
		IEnumerable<EmprestimoModel> Todos();
	}
}
