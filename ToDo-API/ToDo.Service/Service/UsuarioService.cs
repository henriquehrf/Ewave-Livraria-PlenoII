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

			ValidarCadastro(usuario);

			if (_notificationContext.Valid)
				_usuarioRepository.Inserir(usuario);
		}

		private void ValidarCadastro(UsuarioModel usuario)
		{
			if (string.IsNullOrWhiteSpace(usuario.Email) && string.IsNullOrWhiteSpace(usuario.Telefone))
				_notificationContext.AddNotification("Cadastro sem contato", "Para efetuar o cadastro de usuário deve informar Email e/ou Telefone!");
		}

		public void Alterar(UsuarioModel usuario)
		{
			_notificationContext.AddNotifications(usuario.ToEntity().Notifications);

			ValidarCadastro(usuario);

			if (!_notificationContext.Invalid)
				_usuarioRepository.Alterar(usuario);
		}

		public void Excluir(int id) => _usuarioRepository.Excluir(id);

		public UsuarioModel UsuarioPorLogin(string login) => _usuarioRepository.UsuarioPorLogin(login);
		public IEnumerable<UsuarioModel> TodosUsuarios() => _usuarioRepository.Todos();

		public IEnumerable<UsuarioModel> BuscarUsuarioPorNome(string nome)=> _usuarioRepository.UsuarioPorNome(nome);
		
	}
}
