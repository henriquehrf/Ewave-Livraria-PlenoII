using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.Infra.CrossCutting.Filter;
using ToDo.Infra.CrossCutting.InversionOfControl;

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
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
			app.UseSwaggerDependency();

			//app.UseAuthorization();

		}
	}
}
