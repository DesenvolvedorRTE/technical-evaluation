
using DesafioRodonaves.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioRodonaves.Infra.Data.EntityConfiguration
{
    public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Collaborator> builder)
        {
            // Define o nome da tabela
            builder.ToTable("colaboradores");

            // Configura a geração de id pelo banco de dados
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("id");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnName("nome");

            builder.Property(x => x.UnitId).IsRequired().HasColumnName("id_unidade");

            builder.Property(x => x.UserId).IsRequired().HasColumnName("id_usuario");

            // Configuração da relação 1 para 1 entre Unit e Collaborator
            builder.HasOne(u => u.UnitNavigation)
                .WithOne(c => c.CollaboratorNavigation)
                .HasForeignKey<Unit>(u => u.Id)
                .IsRequired();

            // Configuração da relação 1 para 1 entre User e Collaborator
            builder.HasOne(u => u.UserNavigation)
                .WithOne(c => c.CollaboratorNavigation)
                .HasForeignKey<Collaborator>(u => u.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
    
}
