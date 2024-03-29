﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using Sistema_de_planos.Models;
using Duende.IdentityServer.EntityFramework.Options;
using EntityFrameworkCore.UseRowNumberForPaging;

namespace Sistema_de_planos.Infraestructura.Datos
{
    public partial class PlanosContext : DbContext //ApiAuthorizationDbContext<User>
    {
        public DbSet<Dominio.Entidades.Estado> Estados { get; set; }
        public DbSet<Dominio.Entidades.Historico> Historicos { get; set; }
        public DbSet<Dominio.Entidades.Plano> Planos { get; set; }
        public DbSet<Dominio.Entidades.User> Usuario { get; set; }
        public DbSet<Dominio.Entidades.Arancel> Arancel { get; set; }
        public DbSet<Dominio.Entidades.Zona> Zonas { get; set; }

        public DbSet<Dominio.Entidades.LastPlanoNumber> LastPlanoNumber { get; set; }
        public DbSet<Dominio.Entidades.PartidosArba> PartidosArba { get; set; }



        //public PlanosContext() { 
        //}

        //public PlanosContext(DbContextOptions<PlanosContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        //    : base(options, operationalStoreOptions)
        //{
        //}
        public PlanosContext()
        {
            
        }

        public PlanosContext(DbContextOptions<PlanosContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=www;Database=planos;User Id=aleidi;Password=aleidi1;MultipleActiveResultSets=true;",
                //option => option.UseRowNumberForPaging()
                //);
                
                //optionsBuilder.UseSqlServer("Server=srv-desarrollo;Database=planos;User Id=sa;Password=desarrollo;MultipleActiveResultSets=true;");
                //optionsBuilder.UseSqlServer("Server=SI-DESARROLLO05\\SQLEXPRESS; Database=Planos; Integrated Security=true; Multiple Active Result Sets=true;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
