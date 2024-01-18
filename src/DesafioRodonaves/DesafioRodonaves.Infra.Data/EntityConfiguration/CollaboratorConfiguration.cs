using DesafioRodonaves.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DesafioRodonaves.Infra.Data.EntityConfiguration
{
    public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            // Define o nome da tabela
            builder.ToTable("colaboradores");

            // Configura a geração de id pelo banco de dados
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("id");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("nome");

            builder.Property(x => x.UnitId).IsRequired().HasColumnName("id_unidade");

            builder.Property(x => x.UserId).IsRequired().HasColumnName("id_usuario");

            // Configuração da relação 1 para muitos entre Unit e Collaborator
            builder.HasOne(c => c.Unit)
                .WithMany(u => u.Collaborator)
                .HasForeignKey(c => c.UnitId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(c => c.User)
                 .WithOne(u => u.Collaborator)
                 .HasForeignKey<Collaborator>(c => c.UserId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
