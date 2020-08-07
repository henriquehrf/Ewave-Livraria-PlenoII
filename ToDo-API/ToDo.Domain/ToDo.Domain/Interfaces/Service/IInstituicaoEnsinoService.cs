using System.Collections.Generic;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IInstituicaoEnsinoService
	{
		void Inserir(InstituicaoEnsinoModel instituicao);
		void Alterar(InstituicaoEnsinoModel instituicao);
		void Excluir(InstituicaoEnsinoModel instituicao);
		InstituicaoEnsinoModel InstituicaoEnsinoPorId(int id);
		IEnumerable<InstituicaoEnsinoModel> TodosInstituicoesEnsino();
	}
}
