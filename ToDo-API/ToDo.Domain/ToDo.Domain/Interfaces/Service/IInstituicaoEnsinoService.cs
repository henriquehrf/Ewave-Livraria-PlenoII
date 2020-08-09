using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IInstituicaoEnsinoService
	{
		void Inserir(InstituicaoEnsinoModel instituicao);
		void Alterar(InstituicaoEnsinoModel instituicao);
		void Excluir(int Id);
		InstituicaoEnsinoModel InstituicaoEnsinoPorId(int id);
		IEnumerable<InstituicaoEnsinoModel> TodosInstituicoesEnsino();
		IEnumerable<InstituicaoEnsinoModel> BuscarInstituicoesPorNome(string nome);
	}
}
