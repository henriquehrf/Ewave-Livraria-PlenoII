using System;
using System.Collections.Generic;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;
using ToDo.Infra.Shared.NotificationContext;

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

		public void Alterar(UsuarioModel usuario) => _usuarioRepository.Alterar(usuario);

		public void Excluir(UsuarioModel usuario) => _usuarioRepository.Excluir(usuario);

		public void Inserir(UsuarioModel usuario) => _usuarioRepository.Inserir(usuario);

		public UsuarioModel UsuarioPorId(int id) => _usuarioRepository.ById(id);
		public IEnumerable<UsuarioModel> TodosUsuarios() => _usuarioRepository.Todos();
	}
}
