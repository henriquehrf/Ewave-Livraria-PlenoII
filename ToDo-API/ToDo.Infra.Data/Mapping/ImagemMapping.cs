using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.Mapping
{
	public class ImagemMapping : IEntityTypeConfiguration<Imagem>
	{
		public void Configure(EntityTypeBuilder<Imagem> builder)
		{
			builder.ToTable("Imagem");

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Nome)
				.IsRequired()
			   .HasColumnName("Nome")
			   .HasColumnType("varchar(200)");

			builder.Property(prop => prop.Dados)
				.IsRequired()
				.HasColumnName("Dados")
				.HasColumnType("image");

			builder.Property(prop => prop.ContentType)
				.IsRequired()
				.HasColumnName("ContentType")
				.HasColumnType("varchar(200)");
		}
	}
}
