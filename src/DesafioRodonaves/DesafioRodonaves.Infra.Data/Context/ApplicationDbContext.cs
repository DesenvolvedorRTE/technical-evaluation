﻿using DesafioRodonaves.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DesafioRodonaves.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        // Configura contexto do banco de dados
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext) { }

        // Configurar o mapeamento das entidades para o banco de dados
        public DbSet<Unit> Units { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }


        // Realiza a aplicação automatica das configurações de entidades que são definidas nas pasta EntityConfiguration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
