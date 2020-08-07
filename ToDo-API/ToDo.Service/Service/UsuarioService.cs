using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Service.Service
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly NotificationContext _notificationContext;

		public UsuarioService(IUsuarioRepository usuarioRepository, NotificationContext notificationContext)
		{
			_usuarioRepository = usuarioRepository;
			_notificationContext = notificationContext;
		}

		public void Inserir(UsuarioModel usuario)
		{
			_notificationContext.AddNotifications(usuario.ToEntity().Notifications);

			if (!_notificationContext.Invalid)
				_usuarioRepository.Inserir(usuario);
		}
		public void Alterar(UsuarioModel usuario)
		{
			_notificationContext.AddNotifications(usuario.ToEntity().Notifications);

			if (!_notificationContext.Invalid)
				_usuarioRepository.Alterar(usuario);
		}

		public void Excluir(UsuarioModel usuario) => _usuarioRepository.Excluir(usuario);

		public UsuarioModel UsuarioPorLogin(string login) => _usuarioRepository.UsuarioPorLogin(login);
		public IEnumerable<UsuarioModel> TodosUsuarios() => _usuarioRepository.Todos();
	}
}
