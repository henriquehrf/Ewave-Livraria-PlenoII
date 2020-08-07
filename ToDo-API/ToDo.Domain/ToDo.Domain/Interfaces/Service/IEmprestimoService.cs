using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IEmprestimoService
	{
		void Inserir(EmprestimoModel emprestimo);
		void Devolver(EmprestimoModel emprestimo);
		EmprestimoModel ById(int id);
		IEnumerable<EmprestimoModel> TodosPorUsuario(int idUsuario);
		IEnumerable<EmprestimoModel> Todos();
	}
}
