﻿using DesafioRodonaves.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DesafioRodonaves.Infra.Data.EntityConfiguration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {

            // Configura a geração de id pelo banco de dados
            builder.Property(x => x.Id).IsRequired().HasColumnName("id");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UnitCode).IsRequired().HasMaxLength(100).HasColumnName("codigo_da_unidade");
            builder.Property(x => x.UnitName).IsRequired().HasMaxLength(150).HasColumnName("nome_da_unidade");


            // Configuração da relação 1 para 1 entre Unit e Collaborator
            builder.HasOne(u => u.Collaborator)
                .WithOne(c => c.Unit)
                .HasForeignKey<Collaborator>(u => u.Id)
                .IsRequired();
           


            // Configuração de index
            builder.HasIndex(x => x.UnitCode).IsUnique();
            builder.HasIndex(x => x.UnitName).IsUnique();





        }
    }
}