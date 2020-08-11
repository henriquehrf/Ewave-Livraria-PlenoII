using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Infra.CrossCutting.Filter;
using ToDo.Infra.CrossCutting.InversionOfControl;
using ToDo.Infra.CrossCutting.Token;

namespace ToDo.Application
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddControllers().AddNewtonsoftJson();

			services.AddMvc(config =>
			{
				config.EnableEndpointRouting = false;
				config.Filters.Add<NotificationFilter>();
			});
			services.AddDependencySql();
			services.AddSqlRepositoryDependency();
			services.AddServiceDependency();
			services.AddSwaggerDependency();
			services.AddNotificationDependency();
			services.ConfigureToken(Configuration);

			
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwaggerDependency();

			app.UseCors(builder => builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());
			app.UseMvc();

		}
	}
}
