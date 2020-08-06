﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.Mapping
{
	public class LivroMapping : IEntityTypeConfiguration<Livro>
	{
		public void Configure(EntityTypeBuilder<Livro> builder)
		{
			builder.ToTable("Livro");

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Titulo)
			   .IsRequired()
			   .HasColumnName("Titulo")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Genero)
			   .IsRequired()
			   .HasColumnName("Genero")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Autor)
			   .IsRequired()
			   .HasColumnName("Autor")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Sinopse)
			   .IsRequired()
			   .HasColumnName("Sinopse")
			   .HasColumnType("varchar(200)");

			builder.Property(prop => prop.Disponibilidade)
			   .IsRequired()
			   .HasColumnName("Disponibilidade")
			   .HasColumnType("bit");

			builder.Property(prop => prop.Ativo)
			   .IsRequired()
			   .HasColumnName("Ativo")
			   .HasColumnType("bit");



		}
	}
}
