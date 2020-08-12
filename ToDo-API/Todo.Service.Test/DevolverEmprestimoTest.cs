using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Service.Service;
using Xunit;

namespace Todo.Service.Test
{
	public class DevolverEmprestimoTest
	{
		private readonly Mock<IUsuarioRepository> _usuarioRepository;
		private readonly Mock<ILivroRepository> _livroRepository;
		private readonly Mock<IEmprestimoRepository> _emprestimoRepository;
		private readonly NotificationContext _notificationContext;

		public DevolverEmprestimoTest()
		{
			_usuarioRepository = new Mock<IUsuarioRepository>();
			_livroRepository = new Mock<ILivroRepository>();
			_emprestimoRepository = new Mock<IEmprestimoRepository>();
			_notificationContext = new NotificationContext();
		}

		[Theory]
		[MemberData(nameof(ParametrosEsperados))]
		public void AoDevolverEmprestimoDeveValidarRegraDeNegocio(EmprestimoModel emprestimo,
																	UsuarioModel usuario,
																	LivroModel livro,
																	DateTime? dataSuspencao)
		{
			_usuarioRepository.Setup(e => e.UsuarioPorId(emprestimo.IdUsuario)).Returns(usuario);
			_livroRepository.Setup(e => e.ById(emprestimo.IdLivro)).Returns(livro);
			var emprestimoService = new EmprestimoService(_emprestimoRepository.Object,
											_usuarioRepository.Object,
											_livroRepository.Object,
											_notificationContext); ;

			emprestimoService.Devolver(emprestimo);
			livro.Disponibilidade.Should().BeTrue();
			usuario.DataSuspencao.Should().BeOneOf(dataSuspencao);
			emprestimo.DataDevolucao.Should().BeSameDateAs(DateTime.Today);
			emprestimo.Status.Should().Be(StatusEmprestimoEnum.Devolvido.GetHashCode());
		}

		public static IEnumerable<object[]> ParametrosEsperados()
		{
			yield return new object[]
			{
				new EmprestimoModel()
				{
					IdUsuario = 1,
					IdLivro = 1,
					DataPrevistaDevolucao= DateTime.Today,
					DataEmprestimo= DateTime.Today.AddDays(-30),
					Status = StatusEmprestimoEnum.Aberto.GetHashCode()
				},
				new UsuarioModel
				{
					Id=1,
					Nome= "Fulano",
					DataSuspencao =null
				},
				new LivroModel
				{
					Id=1,
					Titulo ="Dom Casmurro",
					Disponibilidade = false
				},
				null
			};

			yield return new object[]
			{
				new EmprestimoModel()
				{
					IdUsuario = 1,
					IdLivro = 1,
					DataPrevistaDevolucao= new DateTime(year:2019,month:9,day:11),
					DataEmprestimo= new DateTime(year:2019,month:8,day:11),
					Status = StatusEmprestimoEnum.Aberto.GetHashCode()
				},
				new UsuarioModel
				{
					Id=1,
					Nome= "Fulano",
					DataSuspencao =null
				},
				new LivroModel
				{
					Id=1,
					Titulo ="Dom Casmurro",
					Disponibilidade = false
				},
				DateTime.Today.AddDays(30)
			};
			yield return new object[]
			{
				new EmprestimoModel()
				{
					IdUsuario = 1,
					IdLivro = 1,
					DataPrevistaDevolucao= DateTime.Today.AddDays(28),
					DataEmprestimo=DateTime.Today.AddDays(-2),
					Status = StatusEmprestimoEnum.Aberto.GetHashCode()
				},
				new UsuarioModel
				{
					Id=1,
					Nome= "Fulano",
					DataSuspencao =null
				},
				new LivroModel
				{
					Id=1,
					Titulo ="Dom Casmurro",
					Disponibilidade = false
				},
				null
			};
		}
	}
}
