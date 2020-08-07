using System;
using System.Collections.Generic;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;

namespace ToDo.Service.Service
{
	public class EmprestimoService : IEmprestimoService
	{
		private readonly IEmprestimoRepository _emprestimoRepository;

		public EmprestimoService(IEmprestimoRepository emprestimoRepository)
		{
			_emprestimoRepository = emprestimoRepository;
		}

		public void Inserir(EmprestimoModel emprestimo) => _emprestimoRepository.Inserir(emprestimo);

		public EmprestimoModel ById(int id) => _emprestimoRepository.ById(id);

		public IEnumerable<EmprestimoModel> Todos() => _emprestimoRepository.Todos();

		public IEnumerable<EmprestimoModel> TodosPorUsuario(int idUsuario) => _emprestimoRepository.TodosPorUsuario(idUsuario);

		public void Devolver(EmprestimoModel emprestimo)
		{
			emprestimo.DataDevolucao = DateTime.Now;
			emprestimo.Status = StatusEmprestimoEnum.Devolvido.GetHashCode();

			_emprestimoRepository.Alterar(emprestimo);
		}

	}
}
