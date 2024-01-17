
using DesafioRodonaves.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioRodonaves.Infra.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configura a geração de id pelo banco de dados
            builder.Property(x => x.Id).IsRequired().HasColumnName("id");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Property(x => x.Login).IsRequired().HasMaxLength(100).HasColumnName("nome_do_usuario");

            builder.Property(x => x.Password).IsRequired().HasMaxLength(150).HasColumnName("senha");

            builder.Property(x => x.Status).IsRequired().HasDefaultValue(true);

            // Configuração da relação 1 para 1 entre user e Collaborator
            builder.HasOne(u => u.Collaborator)
                .WithOne(c => c.User)
                .HasForeignKey<Collaborator>(u => u.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); ;


        }

    }

}
    
