using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Service.Service;
using Xunit;

namespace Todo.Service.Test
{
	public class SolicitarEmprestimoTest
	{
		private readonly Mock<IUsuarioRepository> _usuarioRepository;
		private readonly Mock<ILivroRepository> _livroRepository;
		private readonly Mock<IEmprestimoRepository> _emprestimoRepository;
		private readonly NotificationContext _notificationContext;

		public SolicitarEmprestimoTest()
		{
			_usuarioRepository = new Mock<IUsuarioRepository>();
			_livroRepository = new Mock<ILivroRepository>();
			_emprestimoRepository = new Mock<IEmprestimoRepository>();
			_notificationContext = new NotificationContext();
		}

		[Theory]
		[MemberData(nameof(ParametrosEsperados))]
		public void AoSolicitarEmprestimoDeveValidarRegraDeNegocio(EmprestimoModel emprestimo,
																	UsuarioModel usuario,
																	LivroModel livro,
																	IEnumerable<EmprestimoModel> emprestimos,
																	bool EhUmEmprestimoValido)
		{
			_usuarioRepository.Setup(e => e.UsuarioPorId(emprestimo.IdUsuario)).Returns(usuario);
			_livroRepository.Setup(e => e.ById(emprestimo.IdLivro)).Returns(livro);
			_emprestimoRepository.Setup(e => e.TodosEmprestimoAtivo(emprestimo.IdUsuario)).Returns(emprestimos);
			var emprestimoService = new EmprestimoService(_emprestimoRepository.Object,
											_usuarioRepository.Object,
											_livroRepository.Object,
											_notificationContext); ;

			emprestimoService.Inserir(emprestimo);
			_notificationContext.Valid.Should().Be(EhUmEmprestimoValido);

		}

		public static IEnumerable<object[]> ParametrosEsperados()
		{
			yield return new object[]
			{
				new EmprestimoModel()
				{
					IdUsuario = 1,
					IdLivro = 1
				},
				new UsuarioModel
				{
					Id=1,
					Nome= "Fulano",
					DataSuspencao = DateTime.Now.AddDays(5)
				},
				new LivroModel
				{
					Id=1,
					Titulo ="Dom Casmurro",
					Disponibilidade = true
				},
				new List<EmprestimoModel>(),
				false
			};
			yield return new object[]
			{
				new EmprestimoModel()
				{
					IdUsuario = 1,
					IdLivro = 1
				},
				new UsuarioModel
				{
					Id=1,
					Nome= "Fulano",
					DataSuspencao = null
				},
				new LivroModel
				{
					Id=1,
					Titulo ="Dom Casmurro",
					Disponibilidade = false
				},
				new List<EmprestimoModel>(),
				false
			};
			yield return new object[]
			{
				new EmprestimoModel()
				{
					IdUsuario = 1,
					IdLivro = 1
				},
				new UsuarioModel
				{
					Id=1,
					Nome= "Fulano",
					DataSuspencao = null
				},
				new LivroModel
				{
					Id=1,
					Titulo ="Dom Casmurro",
					Disponibilidade = true
				},
				new List<EmprestimoModel>(),
				true
			};
			yield return new object[]
			{
				new EmprestimoModel()
				{
					IdUsuario = 1,
					IdLivro = 1
				},
				new UsuarioModel
				{
					Id=1,
					Nome= "Fulano",
					DataSuspencao = null
				},
				new LivroModel
				{
					Id=1,
					Titulo ="Dom Casmurro",
					Disponibilidade = true
				},
				new List<EmprestimoModel>(){ new EmprestimoModel(), new EmprestimoModel()},
				false
			};
		}
	}
}
