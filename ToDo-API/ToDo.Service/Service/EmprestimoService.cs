using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class EmprestimoService : IEmprestimoService
	{
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly ILivroRepository _livroRepository;
		private readonly NotificationContext _notificationContext;

		public EmprestimoService(IEmprestimoRepository emprestimoRepository, IUsuarioRepository usuarioRepository, ILivroRepository livroRepository, NotificationContext notificationContext)
		{
			_emprestimoRepository = emprestimoRepository;
			_usuarioRepository = usuarioRepository;
			_livroRepository = livroRepository;
			_notificationContext = notificationContext;
		}

		public void Inserir(EmprestimoModel emprestimo)
		{
			var usuario = _usuarioRepository.UsuarioPorId(emprestimo.IdUsuario);
			var usuarioEstaSuspenso = (usuario.DataSuspencao > DateTime.Now);
			if (usuarioEstaSuspenso)
			{
				_notificationContext.AddNotification("Suspensao", "Usuário encontra-se suspenso!");
				return;
			}

			var livro = _livroRepository.ById(emprestimo.IdLivro);

			if (!livro.Disponibilidade)
			{
				_notificationContext.AddNotification("Indisponivel", "Livro encontra-se indisponível, atualize a págine e tente novamente!");
				return;
			}

			if (_emprestimoRepository.TodosEmprestimoAtivo(usuario.Id).Count() >= 2)
			{
				_notificationContext.AddNotification("Limite de Emprestimo", "Este usuário já possui o limite de emprestimo!");
				return;
			}

			emprestimo.DataEmprestimo = DateTime.Now;
			emprestimo.DataPrevistaDevolucao = DateTime.Now.AddDays(30);
			emprestimo.Status = StatusEmprestimoEnum.Aberto.GetHashCode();
			emprestimo.IdUsuario = usuario.Id;
			livro.Disponibilidade = false;


			_emprestimoRepository.Inserir(emprestimo);
			_livroRepository.Alterar(livro);

		}

		public EmprestimoModel ById(int id) => _emprestimoRepository.ById(id);

		public IEnumerable<EmprestimoModel> Todos() => _emprestimoRepository.Todos();

		public IEnumerable<EmprestimoModel> TodosEmprestimoAtivo(int? idUsuario) => _emprestimoRepository.TodosEmprestimoAtivo(idUsuario);

		public void Devolver(EmprestimoModel emprestimo)
		{

			emprestimo.DataDevolucao = DateTime.Now;
			emprestimo.Status = StatusEmprestimoEnum.Devolvido.GetHashCode();
			_emprestimoRepository.Alterar(emprestimo);

			var livro = _livroRepository.ById(emprestimo.Livro.Id);
			livro.Disponibilidade = true;
			_livroRepository.Alterar(livro);

			if (emprestimo.DataPrevistaDevolucao < DateTime.Now)
			{
				var usuario = _usuarioRepository.UsuarioPorId(emprestimo.IdUsuario);
				usuario.DataSuspencao = DateTime.Now.AddDays(30);
				_usuarioRepository.Alterar(usuario);
			}
		}

	}
}
