﻿// <auto-generated />
using System;
using ErrorCenter.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErrorCenter.Data.Migrations
{
    [DbContext(typeof(ErrorCenterContext))]
    [Migration("20191216051324_ini-pg")]
    partial class inipg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ErrorCenter.Domain.Models.Environment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("environment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Produção"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Homologação"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dev"
                        });
                });

            modelBuilder.Entity("ErrorCenter.Domain.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("EnvironmentId")
                        .HasColumnType("integer");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer");

                    b.Property<int>("SituationId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("LevelId");

                    b.HasIndex("SituationId");

                    b.ToTable("ERROR");
                });

            modelBuilder.Entity("ErrorCenter.Domain.Models.ErrorOccurrence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Details")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int>("ErrorId")
                        .HasColumnType("integer");

                    b.Property<int>("EventCount")
                        .HasColumnType("integer");

                    b.Property<string>("Origin")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ErrorId");

                    b.HasIndex("UserId");

                    b.ToTable("Error_Occurrence");
                });

            modelBuilder.Entity("ErrorCenter.Domain.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("level");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "debug"
                        },
                        new
                        {
                            Id = 2,
                            Name = "warning"
                        },
                        new
                        {
                            Id = 3,
                            Name = "error"
                        });
                });

            modelBuilder.Entity("ErrorCenter.Domain.Models.Situation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("situation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Normal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Arquivado"
                        });
                });

            modelBuilder.Entity("ErrorCenter.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Token")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user1@sp.com.br",
                            Name = "Usuário 1",
                            Password = "202cb962ac59075b964b07152d234b70",
                            Token = "d959891e-dfaa-40cb-860c-c0c9855788a8"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user2@sp.com.br",
                            Name = "Usuário 2",
                            Password = "289dff07669d7a23de0ef88d2f7129e7",
                            Token = "ba9e481f-e138-4511-a79e-cf4de0b9beb5"
                        },
                        new
                        {
                            Id = 3,
                            Email = "user3@sp.com.br",
                            Name = "Usuário 3",
                            Password = "d81f9c1be2e08964bf9f24b15f0e4900",
                            Token = "d61dbf56-2b56-4a3c-b973-4b97083aa60d"
                        },
                        new
                        {
                            Id = 4,
                            Email = "user4@sp.com.br",
                            Name = "Usuário 4",
                            Password = "250cf8b51c773f3f8dc8b4be867a9a02",
                            Token = "409c38f4-b167-45f0-921b-d0dcb264239b"
                        },
                        new
                        {
                            Id = 5,
                            Email = "user5@sp.com.br",
                            Name = "Usuário 5",
                            Password = "99c5e07b4d5de9d18c350cdf64c5aa3d",
                            Token = "f1b5b2a6-3b23-4a5a-a59e-3c9f2e681201"
                        },
                        new
                        {
                            Id = 6,
                            Email = "user6@sp.com.br",
                            Name = "Usuário 6",
                            Password = "9fe8593a8a330607d76796b35c64c600",
                            Token = "dc7cd8ba-7dbf-4189-b327-4307a0b03259"
                        },
                        new
                        {
                            Id = 7,
                            Email = "user7@sp.com.br",
                            Name = "Usuário 7",
                            Password = "68053af2923e00204c3ca7c6a3150cf7",
                            Token = "7c25113d-a0c5-42c3-b94f-6ee738ad4fc9"
                        },
                        new
                        {
                            Id = 8,
                            Email = "user8@sp.com.br",
                            Name = "Usuário 8",
                            Password = "86a1fa88adb5c33bd7a68ac2f9f3f96b",
                            Token = "f59a0a65-bad7-4cdd-a540-2f83bb35dde7"
                        },
                        new
                        {
                            Id = 9,
                            Email = "user9@sp.com.br",
                            Name = "Usuário 9",
                            Password = "7cf08c3ddac57a6d4f28034f88bfb23e",
                            Token = "fa50b2cf-e6d6-4d2d-a149-82545ca50674"
                        },
                        new
                        {
                            Id = 10,
                            Email = "user10@sp.com.br",
                            Name = "Usuário 10",
                            Password = "cdd773039f5b1a8f41949a1fccd0768f",
                            Token = "30a4f12b-ce3d-46c1-91f3-97be8fbada46"
                        });
                });

            modelBuilder.Entity("ErrorCenter.Domain.Models.Error", b =>
                {
                    b.HasOne("ErrorCenter.Domain.Models.Environment", "Environment")
                        .WithMany("Errors")
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErrorCenter.Domain.Models.Level", "Level")
                        .WithMany("Errors")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErrorCenter.Domain.Models.Situation", "Situation")
                        .WithMany("Errors")
                        .HasForeignKey("SituationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ErrorCenter.Domain.Models.ErrorOccurrence", b =>
                {
                    b.HasOne("ErrorCenter.Domain.Models.Error", "Error")
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("ErrorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErrorCenter.Domain.Models.User", "User")
                        .WithMany("ErrorOccurrences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
