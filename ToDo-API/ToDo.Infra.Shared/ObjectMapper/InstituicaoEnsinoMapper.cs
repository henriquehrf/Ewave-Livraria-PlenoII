using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Models;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class InstituicaoEnsinoMapper
	{


		public static InstituicaoEnsino ToEntity(this InstituicaoEnsinoModel objModel) => new InstituicaoEnsino(id: objModel.Id,
																												nome: objModel.Nome,
																												endereco: objModel.Endereco,
																												cnpj: objModel.Cnpj,
																												telefone: objModel.Telefone);

		public static InstituicaoEnsinoModel ToModel(this InstituicaoEnsino objRepository) => new InstituicaoEnsinoModel()
		{
			Id = objRepository.Id,
			Nome = objRepository.Nome.ToString(),
			Endereco = objRepository.Endereco.ToString(),
			Cnpj = objRepository.Cnpj.ToString(),
			Telefone = objRepository.Telefone.ToString()
		};

		public static IEnumerable<InstituicaoEnsinoModel> ToEnumerableModel(this IList<InstituicaoEnsino> list) => new List<InstituicaoEnsinoModel>(list.Select(obj => ToModel(obj)));
	}
}
