using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
	public interface IInstituicaoEnsinoRepository
	{
		void Inserir(InstituicaoEnsinoModel instituicao);
		void Alterar(InstituicaoEnsinoModel instituicao);
		void Excluir(int id);
		InstituicaoEnsinoModel ById(int id);
		IEnumerable<InstituicaoEnsinoModel> Todos();
		IEnumerable<InstituicaoEnsinoModel> BuscarInstituicoesPorNome(string nome);
	}
}
