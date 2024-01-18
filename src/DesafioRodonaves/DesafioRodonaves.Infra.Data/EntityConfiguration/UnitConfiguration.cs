using DesafioRodonaves.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DesafioRodonaves.Infra.Data.EntityConfiguration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            // Define o nome da tabela
            builder.ToTable("unidades");

            // Configura a geração de id pelo banco de dados
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("id");

            builder.Property(x => x.UnitCode).IsRequired().HasMaxLength(100).HasColumnName("codigo_da_unidade");
            builder.Property(x => x.UnitName).IsRequired().HasMaxLength(150).HasColumnName("nome_da_unidade");
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(true).HasColumnName("status");

            // Configuração da relação 1 para muitos entre Unit e Collaborator
            builder.HasMany(u => u.CollaboratorNavigation)
                .WithOne(c => c.UnitNavigation);

            // Configuração de index
            builder.HasIndex(x => x.UnitCode).IsUnique();
            builder.HasIndex(x => x.UnitName).IsUnique();





        }
    }
}
