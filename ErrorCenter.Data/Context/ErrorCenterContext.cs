using AceleraDev.CrossCutting.Utils;
using Dapper;
using ErrorCenter.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace ErrorCenter.Data.Context
{
    public class ErrorCenterContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ErrorCenterContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Error> Errors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorOccurrence> ErrorOccurrences { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Domain.Models.Environment> Environments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        internal string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null) property.SetMaxLength(255);
            }

            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            //{
            //    if (property.GetColumnType() == null) property.SetColumnType("decimal(18, 4)");
            //}

            // modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErrorCenterContext).Assembly);

            //Adiciona dados padrão de níveis
            modelBuilder.Entity<Level>().HasData(new Level { Id = 1, Name = "debug" });
            modelBuilder.Entity<Level>().HasData(new Level { Id = 2, Name = "warning" });
            modelBuilder.Entity<Level>().HasData(new Level { Id = 3, Name = "error" });

            //Adiciona dados padrão de ambiente
            modelBuilder.Entity<ErrorCenter.Domain.Models.Environment>().HasData(new ErrorCenter.Domain.Models.Environment { Id = 1, Name = "Produção"});
            modelBuilder.Entity<ErrorCenter.Domain.Models.Environment>().HasData(new ErrorCenter.Domain.Models.Environment { Id = 2, Name = "Homologação" });
            modelBuilder.Entity<ErrorCenter.Domain.Models.Environment>().HasData(new ErrorCenter.Domain.Models.Environment { Id = 3, Name = "Dev" });

            //Adiciona dados padrão de situação
            modelBuilder.Entity<Situation>().HasData(new Situation { Id = 1, Name = "Normal" });
            modelBuilder.Entity<Situation>().HasData(new Situation { Id = 2, Name = "Arquivado" });

            int idErro = 1;
            int idOcor = 1;

            for (int i=1; i <= 10; i++)
            {
                modelBuilder.Entity<User>().HasData(new User { Id = i, Email=$"user{i}@sp.com.br", 
                    Name=$"Usuário {i}", Password=$"{i}{i+1}{i+2}".ToHashMD5(), Token=Utils.GenerateToken()});


                for(int idEnv=1; idEnv<4;  idEnv++)
                {
                    for (int idLevel = 1; idLevel < 4; idLevel++)
                    {
                        /*
                        int qtdErros = idLevel + idEnv;

                        for (int j = 0; j < qtdErros; j++)
                        {
                            //adicina o erro
                            modelBuilder.Entity<Error>().HasData(new Error
                            {
                                Title = $"aceleration.Service.Service{i}{idEnv}{j}",
                                Code = (i * 10000) + (idEnv * 100) + j,
                                SituationId = 1,
                                Description = "bla bla bla bla",
                                EnvironmentId = idEnv,
                                Id = idErro,
                                LevelId = idLevel
                            });

                            modelBuilder.Entity<ErrorOccurrence>().HasData(new ErrorOccurrence
                            {
                                DateTime = DateTime.Now,
                                Details = "Det1\nDet2\ndetalhe 3\nDetalhe maior 4",
                                ErrorId = idErro,
                                Origin = $"192.168.2.{idErro}",
                                Id = idOcor++,
                                UserId = i,
                                EventCount = i * 2
                            }); ;

                            idErro++;
                        }
                        */
                    }
                }
            }
        }
    }
}
