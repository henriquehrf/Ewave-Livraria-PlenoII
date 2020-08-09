using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using ToDo.Domain.Entities;
using ToDo.Infra.Data.Mapping;

namespace ToDo.Infra.Data.Context
{
	public class ToDoContext : DbContext
	{
		public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Usuario>(new UsuarioMapping().Configure);
			modelBuilder.Entity<InstituicaoEnsino>(new InstituicaoEnsinoMapping().Configure);
			modelBuilder.Entity<Livro>(new LivroMapping().Configure);
			modelBuilder.Entity<Emprestimo>(new EmprestimoMapping().Configure);


			var entites = Assembly
				.Load("ToDo.Domain")
				.GetTypes()
				.Where(w => w.Namespace == "ToDo.Domain.Entities" && w.BaseType.BaseType == typeof(Notifiable));

			foreach (var item in entites)
			{
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
			}
		}
	}
}
