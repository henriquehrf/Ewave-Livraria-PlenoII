using System.Collections.Generic;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Service.Service
{
	public class InstituicaoEnsinoService : IInstituicaoEnsinoService
	{
		private readonly IInstituicaoEnsinoRepository _instituicaoEnsinoRepository;
		private readonly NotificationContext _notificationContext;

		public InstituicaoEnsinoService(IInstituicaoEnsinoRepository instituicaoEnsinoRepository, NotificationContext notificationContext)
		{
			_instituicaoEnsinoRepository = instituicaoEnsinoRepository;
			_notificationContext = notificationContext;
		}

		public void Inserir(InstituicaoEnsinoModel instituicao)
		{
			_notificationContext.AddNotifications(instituicao.ToEntity().Notifications);

			if (!_notificationContext.Invalid)
				_instituicaoEnsinoRepository.Inserir(instituicao);
		}

		public void Alterar(InstituicaoEnsinoModel instituicao)
		{
			_notificationContext.AddNotifications(instituicao.ToEntity().Notifications);

			if (!_notificationContext.Invalid)
				_instituicaoEnsinoRepository.Alterar(instituicao);
		}

		public void Excluir(InstituicaoEnsinoModel instituicao) => _instituicaoEnsinoRepository.Excluir(instituicao);


		public InstituicaoEnsinoModel InstituicaoEnsinoPorId(int id) => _instituicaoEnsinoRepository.ById(id);

		public IEnumerable<InstituicaoEnsinoModel> TodosInstituicoesEnsino() => _instituicaoEnsinoRepository.Todos();
	}
}
