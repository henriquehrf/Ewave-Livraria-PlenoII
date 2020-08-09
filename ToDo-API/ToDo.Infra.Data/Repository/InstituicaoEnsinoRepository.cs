using System.Collections.Generic;
using System.Linq;
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

		public void Excluir(int id) => base.Excluir(id);

		InstituicaoEnsinoModel IInstituicaoEnsinoRepository.ById(int id) => base.ById(id).ToModel();

		IEnumerable<InstituicaoEnsinoModel> IInstituicaoEnsinoRepository.Todos() => base.Todos().ToEnumerableModel();

		public IEnumerable<InstituicaoEnsinoModel> BuscarInstituicoesPorNome(string nome)
		{
			if (string.IsNullOrWhiteSpace(nome)) return Todos().ToEnumerableModel();

			//TODO: Investigar EF Linq Error after change from dotnet Core 2.2.6 to 3.0.0

			return Todos().Where(t=>t.Nome.ToString().ToLowerInvariant().Contains(nome.ToLowerInvariant())).ToList().ToEnumerableModel();
		}
	}
}
