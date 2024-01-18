using DesafioRodonaves.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.HasOne(u => u.UnitNavigation)
                .WithMany(c => c.CollaboratorNavigation)
                .HasForeignKey(u => u.UnitId)
                .IsRequired();

            // Configuração da relação 1 para 1 entre User e Collaborator
            builder.HasOne(u => u.UserNavigation)
                .WithOne(c => c.CollaboratorNavigation)
                .HasForeignKey<Collaborator>(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
