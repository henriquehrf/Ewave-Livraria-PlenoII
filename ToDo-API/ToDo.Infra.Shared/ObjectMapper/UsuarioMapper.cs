using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Models;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class UsuarioMapper
	{
		public static Usuario ToEntity(this UsuarioModel objModel) => new Usuario(id: objModel.Id,
																				  nome: objModel.Nome,
																				  endereco: objModel.Endereco,
																				  cpf: objModel.Cpf,
																				  idInstituicaoEnsino: objModel.IdInstrituicaoEnsino,
																				  telefone: objModel.Telefone,
																				  email: objModel.Email,
																				  login: objModel.Login,
																				  senha: objModel.Senha,
																				  dataMinimaProximoEmprestimo: objModel.DataProxEmprestimo
																				  );

		public static UsuarioModel ToModel(this Usuario objRepository) => new UsuarioModel()
		{
			Id = objRepository.Id,
			Nome = objRepository.Nome.ToString(),
			Endereco = objRepository.Endereco.ToString(),
			Cpf = objRepository.Cpf.ToString(),
			IdInstrituicaoEnsino = objRepository.IdInstituicaoEnsino,
			Telefone = objRepository.Telefone.ToString(),
			Email = objRepository.Email.ToString(),
			Login = objRepository.Login,
			Senha = objRepository.Senha,
			DataProxEmprestimo = objRepository.DataMinimaProximoEmprestimo
		};

		public static IEnumerable<UsuarioModel> ToEnumerableModel(this IList<Usuario> list) => new List<UsuarioModel>(list.Select(obj => ToModel(obj)));
	}
}
