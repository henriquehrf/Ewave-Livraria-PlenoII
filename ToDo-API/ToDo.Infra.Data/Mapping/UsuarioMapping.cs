﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.Mapping
{
	public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
	{

		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuario");

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Nome)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Nome")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Endereco)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Endereco")
			   .HasColumnType("varchar(200)");

			builder.Property(prop => prop.Cpf)
			  .HasConversion(prop => prop.ToString(), prop => prop)
			  .IsRequired()
			  .HasColumnName("Cpf")
			  .HasColumnType("varchar(14)");

			builder.Property(prop => prop.Telefone)
			  .HasConversion(prop => prop.ToString(), prop => prop)
			  .HasColumnName("Telefone")
			  .HasColumnType("varchar(20)");

			builder.Property(prop => prop.Email)
			  .HasConversion(prop => prop.ToString(), prop => prop)
			  .HasColumnName("Email")
			  .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Login)
			  .IsRequired()
			  .HasColumnName("Login")
			  .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Senha)
			  .IsRequired()
			  .HasColumnName("Senha")
			  .HasColumnType("varchar(100)");

			builder.Property(prop => prop.DataSuspencao)
			  .HasColumnName("DataMinimaProximoEmprestimo")
			  .HasColumnType("datetime");

			builder.Property(prop => prop.PerfilUsuario)
			  .IsRequired()
			  .HasColumnName("PerfilUsuario")
			  .HasColumnType("int");

			builder.HasOne(prop => prop.InstituicaoEnsino)
				.WithMany(prop => prop.Usuarios)
				.HasPrincipalKey(prop => prop.Id)
				.HasForeignKey(prop => prop.IdInstituicaoEnsino);
		}
	}
}
