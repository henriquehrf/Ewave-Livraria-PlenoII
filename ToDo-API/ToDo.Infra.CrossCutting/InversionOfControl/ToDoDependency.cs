﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.CrossCutting.InversionOfControl
{
	public static class ToDoDependency
	{
		public static void AddDependencySql(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ToDoContext>(context =>
			{
				context.UseSqlServer(configuration["ConnectionString"]);
			});
		}
	}
}
