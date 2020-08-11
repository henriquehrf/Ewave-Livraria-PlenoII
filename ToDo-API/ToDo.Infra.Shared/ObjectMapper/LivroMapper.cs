using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Models;

namespace ToDo.Infra.Shared.ObjectMapper
{
	public static class LivroMapper
	{
		public static Livro ToEntity(this LivroModel objModel) => new Livro(id: objModel.Id,
																			titulo: objModel.Titulo,
																			genero: objModel.Genero,
																			autor: objModel.Autor,
																			sinopse: objModel.Sinopse,
																			disponibilidade: objModel.Disponibilidade,
																			ativo: objModel.Ativo,
																			guidCapa: objModel.GuidCapa);

		public static LivroModel ToModel(this Livro objRepository) => new LivroModel()
		{
			Id = objRepository.Id,
			Titulo = objRepository.Titulo,
			Genero = objRepository.Genero,
			Autor = objRepository.Sinopse,
			Disponibilidade = objRepository.Disponibilidade,
			Sinopse = objRepository.Sinopse,
			Ativo = objRepository.Ativo,
			GuidCapa = objRepository.GuidCapa
		};

		public static IEnumerable<LivroModel> ToEnumerableModel(this IList<Livro> list) => new List<LivroModel>(list.Select(obj => ToModel(obj)));
	}
}
