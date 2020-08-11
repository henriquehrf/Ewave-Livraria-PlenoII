using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces;
using ToDo.Infra.Data.Repository;

namespace ToDo.Infra.CrossCutting.InversionOfControl
{
	public static class ToDoRepositoryDependency
	{
		public static void AddSqlRepositoryDependency(this IServiceCollection services)
		{
			services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
			services.AddScoped<ILivroRepository, LivroRepository>();
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			services.AddScoped<IInstituicaoEnsinoRepository, InstituicaoEnsinoRepository>();
		}
	}
}
