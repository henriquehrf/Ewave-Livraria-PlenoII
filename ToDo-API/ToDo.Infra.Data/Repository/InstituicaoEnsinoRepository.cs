using System.Collections.Generic;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Data.Context;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Infra.Data.Repository
{
	public class InstituicaoEnsinoRepository : BaseRepository<InstituicaoEnsino, int>, IInstituicaoEnsinoRepository
	{
		public InstituicaoEnsinoRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		public void Inserir(InstituicaoEnsinoModel instituicao) => base.Inserir(instituicao.ToEntity());

		public void Alterar(InstituicaoEnsinoModel instituicao) => base.Alterar(instituicao.ToEntity());

		public void Excluir(InstituicaoEnsinoModel instituicao) => base.Excluir(instituicao.Id);

		InstituicaoEnsinoModel IInstituicaoEnsinoRepository.ById(int id) => base.ById(id).ToModel();

		IEnumerable<InstituicaoEnsinoModel> IInstituicaoEnsinoRepository.Todos() => base.Todos().ToEnumerableModel();
	}
}
