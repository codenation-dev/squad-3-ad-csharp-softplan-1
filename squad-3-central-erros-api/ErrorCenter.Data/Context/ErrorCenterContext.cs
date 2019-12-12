using AceleraDev.CrossCutting.Utils;
using ErrorCenter.Data.Config;
using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ErrorCenter.Data.Context
{
    public class ErrorCenterContext : DbContext
    {
        public ErrorCenterContext(DbContextOptions options) : base(options)
        {
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
            modelBuilder.Entity<Level>().HasData(new Level { LevelId = 1, LevelName = "debug" });
            modelBuilder.Entity<Level>().HasData(new Level { LevelId = 2, LevelName = "warning" });
            modelBuilder.Entity<Level>().HasData(new Level { LevelId = 3, LevelName = "error" });

            //Adiciona dados padrão de ambiente
            modelBuilder.Entity<ErrorCenter.Domain.Models.Environment>().HasData(new ErrorCenter.Domain.Models.Environment { Environment_Id = 1, EnvironmentName = "Produção"});
            modelBuilder.Entity<ErrorCenter.Domain.Models.Environment>().HasData(new ErrorCenter.Domain.Models.Environment { Environment_Id = 2, EnvironmentName = "Homologação" });
            modelBuilder.Entity<ErrorCenter.Domain.Models.Environment>().HasData(new ErrorCenter.Domain.Models.Environment { Environment_Id = 3, EnvironmentName = "Dev" });

            //Adiciona dados padrão de situação
            modelBuilder.Entity<Situation>().HasData(new Situation { SituationId = 1, SituationName = "Normal" });
            modelBuilder.Entity<Situation>().HasData(new Situation { SituationId = 2, SituationName = "Arquivado" });

            int idErro = 1;
            int idOcor = 1;

            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = i,
                    Email = $"user{i}@sp.com.br",
                    Name = $"Usuário {i}",
                    Password = $"{i}{i + 1}{i + 2}".ToHashMD5(),
                    Token = Utils.GenerateToken()
                });


                for (int idEnv = 1; idEnv < 4; idEnv++)
                {
                    for (int idLevel = 1; idLevel < 4; idLevel++)
                    {
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

                            /*
                            int qtdOcorrencias = (idLevel * 2);
                            //adicona as ocorrencias
                            for (int k = 0; k < qtdOcorrencias; k++)
                            {
                            */
                                modelBuilder.Entity<ErrorOccurrence>().HasData(new ErrorOccurrence
                                {
                                    DateTime = DateTime.Now,
                                    Details = "Det1\nDet2\ndetalhe 3\nDetalhe maior 4",
                                    ErrorId = idErro,
                                    Origin = $"192.168.2.{idErro}",
                                    ErrorOccurrenceId = idOcor++,
                                    UserId = i
                                }); ;
                            /*
                            }
                            */
                            idErro++;
                        }

                    }
                }
            }
        }
    }
}
