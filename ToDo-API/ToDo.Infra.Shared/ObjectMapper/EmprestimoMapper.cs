using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Models;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class EmprestimoMapper
	{
		public static Emprestimo ToEntity(this EmprestimoModel objModel) => new Emprestimo(id: objModel.Id,
																						   idUsuario: objModel.IdUsuario,
																						   idLivro: objModel.IdLivro,
																						   dataDevolucao: objModel.DataDevolucao,
																						   dataPrevistaDevolucao: objModel.DataPrevistaDevolucao,
																						   dataEmprestimo: objModel.DataEmprestimo,
																						   status: objModel.Status);

		public static EmprestimoModel ToModel(this Emprestimo objRepository) => new EmprestimoModel()
		{
			Id = objRepository.Id,
			IdUsuario = objRepository.IdUsuario,
			IdLivro = objRepository.IdLivro,
			DataDevolucao = objRepository.DataDevolucao,
			DataPrevistaDevolucao = objRepository.DataPrevistaDevolucao,
			DataEmprestimo = objRepository.DataEmprestimo,
			Status = objRepository.Status,
			Usuario = objRepository.Usuario.ToModel(),
			Livro = objRepository.Livro.ToModel()
		};

		public static IEnumerable<EmprestimoModel> ToEnumerableModel(this IList<Emprestimo> list) => new List<EmprestimoModel>(list.Select(obj => ToModel(obj)));
	}
}
