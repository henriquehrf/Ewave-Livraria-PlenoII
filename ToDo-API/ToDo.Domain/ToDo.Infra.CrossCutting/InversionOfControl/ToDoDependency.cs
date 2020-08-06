using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.CrossCutting.InversionOfControl
{
	public static class ToDoDependency
	{
		public static void AddDependencySql(this IServiceCollection services)
		{
			services.AddDbContext<ToDoContext>(context =>
			{
				context.UseSqlServer("Server=DESKTOP-5J4DB80\\SQLEXPRESS;Database=LivrariaToDo;integrated security=true;");
			});
		}
	}
}
