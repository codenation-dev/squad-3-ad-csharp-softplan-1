﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErrorCenter.Data.Migrations
{
    public partial class inipg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "environment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_environment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "situation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_situation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Token = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ERROR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    EnvironmentId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    SituationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ERROR_environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_situation_SituationId",
                        column: x => x.SituationId,
                        principalTable: "situation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Error_Occurrence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Origin = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Details = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ErrorId = table.Column<int>(nullable: false),
                    EventCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error_Occurrence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Error_Occurrence_ERROR_ErrorId",
                        column: x => x.ErrorId,
                        principalTable: "ERROR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Error_Occurrence_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "environment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Produção" },
                    { 2, "Homologação" },
                    { 3, "Dev" }
                });

            migrationBuilder.InsertData(
                table: "level",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "debug" },
                    { 2, "warning" },
                    { 3, "error" }
                });

            migrationBuilder.InsertData(
                table: "situation",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 2, "Arquivado" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Email", "Name", "Password", "Token" },
                values: new object[,]
                {
                    { 8, "user8@sp.com.br", "Usuário 8", "86a1fa88adb5c33bd7a68ac2f9f3f96b", "54df8320-083f-4da7-aea4-d56126e6894b" },
                    { 7, "user7@sp.com.br", "Usuário 7", "68053af2923e00204c3ca7c6a3150cf7", "d1fe7bdf-6855-46b3-a470-f5851551ed04" },
                    { 6, "user6@sp.com.br", "Usuário 6", "9fe8593a8a330607d76796b35c64c600", "adc4d2d6-55b1-4511-b630-53e2120e692c" },
                    { 5, "user5@sp.com.br", "Usuário 5", "99c5e07b4d5de9d18c350cdf64c5aa3d", "81eeefe1-8310-4b94-970f-43844eb4a0a9" },
                    { 1, "user1@sp.com.br", "Usuário 1", "202cb962ac59075b964b07152d234b70", "f909afb2-a549-497b-b30b-3a32ae22888a" },
                    { 3, "user3@sp.com.br", "Usuário 3", "d81f9c1be2e08964bf9f24b15f0e4900", "6d8ee5ad-614c-4804-a3f8-33fcd0b8a506" },
                    { 2, "user2@sp.com.br", "Usuário 2", "289dff07669d7a23de0ef88d2f7129e7", "13fd83ca-3ab0-49a4-9e26-fb6f45f696b8" },
                    { 9, "user9@sp.com.br", "Usuário 9", "7cf08c3ddac57a6d4f28034f88bfb23e", "f73aed4b-90f3-41f6-a626-3737677628bc" },
                    { 4, "user4@sp.com.br", "Usuário 4", "250cf8b51c773f3f8dc8b4be867a9a02", "ef52aa39-527c-40f9-ac7c-13d334ecf2a6" },
                    { 10, "user10@sp.com.br", "Usuário 10", "cdd773039f5b1a8f41949a1fccd0768f", "38ddf0af-4f4d-44d4-bdaa-b7a8fde04b68" }
                });

            migrationBuilder.InsertData(
                table: "ERROR",
                columns: new[] { "Id", "Code", "Description", "EnvironmentId", "LevelId", "SituationId", "Title" },
                values: new object[,]
                {
                    { 1, 10100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service110" },
                    { 245, 70303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service733" },
                    { 244, 70302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service732" },
                    { 243, 70301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service731" },
                    { 242, 70300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service730" },
                    { 241, 70303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service733" },
                    { 240, 70302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service732" },
                    { 239, 70301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service731" },
                    { 238, 70300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service730" },
                    { 246, 70304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service734" },
                    { 237, 70204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service724" },
                    { 235, 70202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service722" },
                    { 234, 70201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service721" },
                    { 233, 70200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service720" },
                    { 232, 70203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service723" },
                    { 231, 70202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service722" },
                    { 230, 70201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service721" },
                    { 229, 70200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service720" },
                    { 228, 70202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service722" },
                    { 236, 70203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service723" },
                    { 247, 70300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service730" },
                    { 248, 70301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service731" },
                    { 249, 70302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service732" },
                    { 268, 80203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service823" },
                    { 267, 80202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service822" },
                    { 266, 80201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service821" },
                    { 265, 80200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service820" },
                    { 264, 80202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service822" },
                    { 263, 80201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service821" },
                    { 262, 80200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service820" },
                    { 261, 80103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service813" },
                    { 260, 80102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service812" },
                    { 259, 80101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service811" },
                    { 258, 80100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service810" },
                    { 257, 80102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service812" },
                    { 256, 80101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service811" },
                    { 255, 80100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service810" },
                    { 254, 80101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service811" },
                    { 253, 80100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service810" },
                    { 252, 70305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service735" },
                    { 251, 70304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service734" },
                    { 250, 70303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service733" },
                    { 227, 70201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service721" },
                    { 269, 80200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service820" },
                    { 226, 70200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service720" },
                    { 224, 70102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service712" },
                    { 200, 60203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service623" },
                    { 199, 60202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service622" },
                    { 198, 60201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service621" },
                    { 197, 60200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service620" },
                    { 196, 60203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service623" },
                    { 195, 60202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service622" },
                    { 194, 60201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service621" },
                    { 193, 60200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service620" },
                    { 201, 60204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service624" },
                    { 192, 60202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service622" },
                    { 190, 60200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service620" },
                    { 189, 60103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service613" },
                    { 188, 60102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service612" },
                    { 187, 60101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service611" },
                    { 186, 60100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service610" },
                    { 185, 60102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service612" },
                    { 184, 60101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service611" },
                    { 183, 60100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service610" },
                    { 191, 60201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service621" },
                    { 202, 60300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service630" },
                    { 203, 60301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service631" },
                    { 204, 60302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service632" },
                    { 223, 70101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service711" },
                    { 222, 70100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service710" },
                    { 221, 70102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service712" },
                    { 220, 70101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service711" },
                    { 219, 70100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service710" },
                    { 218, 70101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service711" },
                    { 217, 70100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service710" },
                    { 216, 60305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service635" },
                    { 215, 60304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service634" },
                    { 214, 60303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service633" },
                    { 213, 60302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service632" },
                    { 212, 60301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service631" },
                    { 211, 60300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service630" },
                    { 210, 60304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service634" },
                    { 209, 60303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service633" },
                    { 208, 60302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service632" },
                    { 207, 60301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service631" },
                    { 206, 60300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service630" },
                    { 205, 60303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service633" },
                    { 225, 70103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service713" },
                    { 182, 60101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service611" },
                    { 270, 80201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service821" },
                    { 272, 80203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service823" },
                    { 335, 100201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service1021" },
                    { 334, 100200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service1020" },
                    { 333, 100103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service1013" },
                    { 332, 100102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service1012" },
                    { 331, 100101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service1011" },
                    { 330, 100100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service1010" },
                    { 329, 100102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service1012" },
                    { 328, 100101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service1011" },
                    { 336, 100202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service1022" },
                    { 327, 100100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service1010" },
                    { 325, 100100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service1010" },
                    { 324, 90305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service935" },
                    { 323, 90304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service934" },
                    { 322, 90303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service933" },
                    { 321, 90302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service932" },
                    { 320, 90301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service931" },
                    { 319, 90300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service930" },
                    { 318, 90304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service934" },
                    { 326, 100101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service1011" },
                    { 337, 100200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service1020" },
                    { 338, 100201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service1021" },
                    { 339, 100202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service1022" },
                    { 358, 100303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service1033" },
                    { 357, 100302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service1032" },
                    { 356, 100301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service1031" },
                    { 355, 100300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service1030" },
                    { 354, 100304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service1034" },
                    { 353, 100303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service1033" },
                    { 352, 100302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service1032" },
                    { 351, 100301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service1031" },
                    { 350, 100300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service1030" },
                    { 349, 100303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service1033" },
                    { 348, 100302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service1032" },
                    { 347, 100301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service1031" },
                    { 346, 100300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service1030" },
                    { 345, 100204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service1024" },
                    { 344, 100203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service1023" },
                    { 343, 100202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service1022" },
                    { 342, 100201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service1021" },
                    { 341, 100200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service1020" },
                    { 340, 100203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service1023" },
                    { 317, 90303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service933" },
                    { 271, 80202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service822" },
                    { 316, 90302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service932" },
                    { 314, 90300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service930" },
                    { 290, 90101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service911" },
                    { 289, 90100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service910" },
                    { 288, 80305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service835" },
                    { 287, 80304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service834" },
                    { 286, 80303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service833" },
                    { 285, 80302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service832" },
                    { 284, 80301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service831" },
                    { 283, 80300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service830" },
                    { 291, 90100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service910" },
                    { 282, 80304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service834" },
                    { 280, 80302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service832" },
                    { 279, 80301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service831" },
                    { 278, 80300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service830" },
                    { 277, 80303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service833" },
                    { 276, 80302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service832" },
                    { 275, 80301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service831" },
                    { 274, 80300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service830" },
                    { 273, 80204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service824" },
                    { 281, 80303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service833" },
                    { 292, 90101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service911" },
                    { 293, 90102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service912" },
                    { 294, 90100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service910" },
                    { 313, 90303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service933" },
                    { 312, 90302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service932" },
                    { 311, 90301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service931" },
                    { 310, 90300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service930" },
                    { 309, 90204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service924" },
                    { 308, 90203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service923" },
                    { 307, 90202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service922" },
                    { 306, 90201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service921" },
                    { 305, 90200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service920" },
                    { 304, 90203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service923" },
                    { 303, 90202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service922" },
                    { 302, 90201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service921" },
                    { 301, 90200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service920" },
                    { 300, 90202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service922" },
                    { 299, 90201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service921" },
                    { 298, 90200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service920" },
                    { 297, 90103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service913" },
                    { 296, 90102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service912" },
                    { 295, 90101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service911" },
                    { 315, 90301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service931" },
                    { 181, 60100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service610" },
                    { 180, 50305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service535" },
                    { 179, 50304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service534" },
                    { 64, 20302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service232" },
                    { 63, 20301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service231" },
                    { 62, 20300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service230" },
                    { 61, 20303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service233" },
                    { 60, 20302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service232" },
                    { 59, 20301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service231" },
                    { 58, 20300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service230" },
                    { 57, 20204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service224" },
                    { 65, 20303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service233" },
                    { 56, 20203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service223" },
                    { 54, 20201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service221" },
                    { 53, 20200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service220" },
                    { 52, 20203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service223" },
                    { 51, 20202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service222" },
                    { 50, 20201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service221" },
                    { 49, 20200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service220" },
                    { 48, 20202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service222" },
                    { 47, 20201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service221" },
                    { 55, 20202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service222" },
                    { 66, 20304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service234" },
                    { 67, 20300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service230" },
                    { 68, 20301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service231" },
                    { 87, 30202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service322" },
                    { 86, 30201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service321" },
                    { 85, 30200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service320" },
                    { 84, 30202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service322" },
                    { 83, 30201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service321" },
                    { 82, 30200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service320" },
                    { 81, 30103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service313" },
                    { 80, 30102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service312" },
                    { 79, 30101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service311" },
                    { 78, 30100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service310" },
                    { 77, 30102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service312" },
                    { 76, 30101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service311" },
                    { 75, 30100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service310" },
                    { 74, 30101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service311" },
                    { 73, 30100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service310" },
                    { 72, 20305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service235" },
                    { 71, 20304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service234" },
                    { 70, 20303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service233" },
                    { 69, 20302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service232" },
                    { 46, 20200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service220" },
                    { 88, 30203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service323" },
                    { 45, 20103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service213" },
                    { 43, 20101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service211" },
                    { 19, 10202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service122" },
                    { 18, 10201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service121" },
                    { 17, 10200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service120" },
                    { 16, 10203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service123" },
                    { 15, 10202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service122" },
                    { 14, 10201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service121" },
                    { 13, 10200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service120" },
                    { 12, 10202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service122" },
                    { 20, 10203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service123" },
                    { 11, 10201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service121" },
                    { 9, 10103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service113" },
                    { 8, 10102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service112" },
                    { 7, 10101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service111" },
                    { 6, 10100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service110" },
                    { 5, 10102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service112" },
                    { 4, 10101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service111" },
                    { 3, 10100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service110" },
                    { 2, 10101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service111" },
                    { 10, 10200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service120" },
                    { 21, 10204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service124" },
                    { 22, 10300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service130" },
                    { 23, 10301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service131" },
                    { 42, 20100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service210" },
                    { 41, 20102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service212" },
                    { 40, 20101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service211" },
                    { 39, 20100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service210" },
                    { 38, 20101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service211" },
                    { 37, 20100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service210" },
                    { 36, 10305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service135" },
                    { 35, 10304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service134" },
                    { 34, 10303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service133" },
                    { 33, 10302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service132" },
                    { 32, 10301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service131" },
                    { 31, 10300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service130" },
                    { 30, 10304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service134" },
                    { 29, 10303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service133" },
                    { 28, 10302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service132" },
                    { 27, 10301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service131" },
                    { 26, 10300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service130" },
                    { 25, 10303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service133" },
                    { 24, 10302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service132" },
                    { 44, 20102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service212" },
                    { 89, 30200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service320" },
                    { 90, 30201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service321" },
                    { 91, 30202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service322" },
                    { 155, 50201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service521" },
                    { 154, 50200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service520" },
                    { 153, 50103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service513" },
                    { 152, 50102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service512" },
                    { 151, 50101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service511" },
                    { 150, 50100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service510" },
                    { 149, 50102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service512" },
                    { 148, 50101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service511" },
                    { 156, 50202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service522" },
                    { 147, 50100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service510" },
                    { 145, 50100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service510" },
                    { 144, 40305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service435" },
                    { 143, 40304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service434" },
                    { 142, 40303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service433" },
                    { 141, 40302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service432" },
                    { 140, 40301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service431" },
                    { 139, 40300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service430" },
                    { 138, 40304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service434" },
                    { 146, 50101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service511" },
                    { 157, 50200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service520" },
                    { 158, 50201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service521" },
                    { 159, 50202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service522" },
                    { 178, 50303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service533" },
                    { 177, 50302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service532" },
                    { 176, 50301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service531" },
                    { 175, 50300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service530" },
                    { 174, 50304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service534" },
                    { 173, 50303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service533" },
                    { 172, 50302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service532" },
                    { 171, 50301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service531" },
                    { 170, 50300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service530" },
                    { 169, 50303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service533" },
                    { 168, 50302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service532" },
                    { 167, 50301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service531" },
                    { 166, 50300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service530" },
                    { 165, 50204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service524" },
                    { 164, 50203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service523" },
                    { 163, 50202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service522" },
                    { 162, 50201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service521" },
                    { 161, 50200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service520" },
                    { 160, 50203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service523" },
                    { 137, 40303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service433" },
                    { 136, 40302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service432" },
                    { 135, 40301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service431" },
                    { 134, 40300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service430" },
                    { 110, 40101, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service411" },
                    { 109, 40100, "bla bla bla bla", 1, 1, 1, "aceleration.Service.Service410" },
                    { 108, 30305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service335" },
                    { 107, 30304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service334" },
                    { 106, 30303, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service333" },
                    { 105, 30302, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service332" },
                    { 104, 30301, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service331" },
                    { 103, 30300, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service330" },
                    { 102, 30304, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service334" },
                    { 101, 30303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service333" },
                    { 100, 30302, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service332" },
                    { 99, 30301, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service331" },
                    { 98, 30300, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service330" },
                    { 97, 30303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service333" },
                    { 96, 30302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service332" },
                    { 95, 30301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service331" },
                    { 94, 30300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service330" },
                    { 93, 30204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service324" },
                    { 92, 30203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service323" },
                    { 111, 40100, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service410" },
                    { 359, 100304, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service1034" },
                    { 112, 40101, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service411" },
                    { 114, 40100, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service410" },
                    { 133, 40303, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service433" },
                    { 132, 40302, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service432" },
                    { 131, 40301, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service431" },
                    { 130, 40300, "bla bla bla bla", 3, 1, 1, "aceleration.Service.Service430" },
                    { 129, 40204, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service424" },
                    { 128, 40203, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service423" },
                    { 127, 40202, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service422" },
                    { 126, 40201, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service421" },
                    { 125, 40200, "bla bla bla bla", 2, 3, 1, "aceleration.Service.Service420" },
                    { 124, 40203, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service423" },
                    { 123, 40202, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service422" },
                    { 122, 40201, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service421" },
                    { 121, 40200, "bla bla bla bla", 2, 2, 1, "aceleration.Service.Service420" },
                    { 120, 40202, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service422" },
                    { 119, 40201, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service421" },
                    { 118, 40200, "bla bla bla bla", 2, 1, 1, "aceleration.Service.Service420" },
                    { 117, 40103, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service413" },
                    { 116, 40102, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service412" },
                    { 115, 40101, "bla bla bla bla", 1, 3, 1, "aceleration.Service.Service411" },
                    { 113, 40102, "bla bla bla bla", 1, 2, 1, "aceleration.Service.Service412" },
                    { 360, 100305, "bla bla bla bla", 3, 3, 1, "aceleration.Service.Service1035" }
                });

            migrationBuilder.InsertData(
                table: "Error_Occurrence",
                columns: new[] { "Id", "DateTime", "Details", "ErrorId", "EventCount", "Origin", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 12, 15, 18, 33, 44, 656, DateTimeKind.Local).AddTicks(6840), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 1, 2, "192.168.2.1", 1 },
                    { 245, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(351), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 245, 14, "192.168.2.245", 7 },
                    { 244, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(247), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 244, 14, "192.168.2.244", 7 },
                    { 243, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(143), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 243, 14, "192.168.2.243", 7 },
                    { 242, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(39), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 242, 14, "192.168.2.242", 7 },
                    { 241, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9934), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 241, 14, "192.168.2.241", 7 },
                    { 240, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9828), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 240, 14, "192.168.2.240", 7 },
                    { 239, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9711), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 239, 14, "192.168.2.239", 7 },
                    { 238, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9544), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 238, 14, "192.168.2.238", 7 },
                    { 246, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(456), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 246, 14, "192.168.2.246", 7 },
                    { 237, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9438), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 237, 14, "192.168.2.237", 7 },
                    { 235, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9229), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 235, 14, "192.168.2.235", 7 },
                    { 234, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9124), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 234, 14, "192.168.2.234", 7 },
                    { 233, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9021), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 233, 14, "192.168.2.233", 7 },
                    { 232, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8915), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 232, 14, "192.168.2.232", 7 },
                    { 231, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8805), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 231, 14, "192.168.2.231", 7 },
                    { 230, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8629), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 230, 14, "192.168.2.230", 7 },
                    { 229, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8525), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 229, 14, "192.168.2.229", 7 },
                    { 228, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8420), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 228, 14, "192.168.2.228", 7 },
                    { 236, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(9334), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 236, 14, "192.168.2.236", 7 },
                    { 247, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(560), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 247, 14, "192.168.2.247", 7 },
                    { 248, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(734), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 248, 14, "192.168.2.248", 7 },
                    { 249, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(843), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 249, 14, "192.168.2.249", 7 },
                    { 268, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3236), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 268, 16, "192.168.2.268", 8 },
                    { 267, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3131), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 267, 16, "192.168.2.267", 8 },
                    { 266, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3026), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 266, 16, "192.168.2.266", 8 },
                    { 265, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2922), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 265, 16, "192.168.2.265", 8 },
                    { 264, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2816), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 264, 16, "192.168.2.264", 8 },
                    { 263, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2705), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 263, 16, "192.168.2.263", 8 },
                    { 262, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2534), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 262, 16, "192.168.2.262", 8 },
                    { 261, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2428), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 261, 16, "192.168.2.261", 8 },
                    { 260, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2324), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 260, 16, "192.168.2.260", 8 },
                    { 259, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2218), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 259, 16, "192.168.2.259", 8 },
                    { 258, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(2110), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 258, 16, "192.168.2.258", 8 },
                    { 257, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(1928), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 257, 16, "192.168.2.257", 8 },
                    { 256, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(1813), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 256, 16, "192.168.2.256", 8 },
                    { 255, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(1704), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 255, 16, "192.168.2.255", 8 },
                    { 254, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(1525), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 254, 16, "192.168.2.254", 8 },
                    { 253, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(1416), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 253, 16, "192.168.2.253", 8 },
                    { 252, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(1157), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 252, 14, "192.168.2.252", 7 },
                    { 251, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(1053), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 251, 14, "192.168.2.251", 7 },
                    { 250, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(949), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 250, 14, "192.168.2.250", 7 },
                    { 227, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8316), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 227, 14, "192.168.2.227", 7 },
                    { 269, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3341), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 269, 16, "192.168.2.269", 8 },
                    { 226, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8212), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 226, 14, "192.168.2.226", 7 },
                    { 224, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8002), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 224, 14, "192.168.2.224", 7 },
                    { 200, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4992), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 200, 12, "192.168.2.200", 6 },
                    { 199, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4885), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 199, 12, "192.168.2.199", 6 },
                    { 198, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4756), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 198, 12, "192.168.2.198", 6 },
                    { 197, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4489), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 197, 12, "192.168.2.197", 6 },
                    { 196, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4385), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 196, 12, "192.168.2.196", 6 },
                    { 195, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4281), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 195, 12, "192.168.2.195", 6 },
                    { 194, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4178), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 194, 12, "192.168.2.194", 6 },
                    { 193, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(4074), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 193, 12, "192.168.2.193", 6 },
                    { 201, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5097), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 201, 12, "192.168.2.201", 6 },
                    { 192, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3968), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 192, 12, "192.168.2.192", 6 },
                    { 190, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3758), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 190, 12, "192.168.2.190", 6 },
                    { 189, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3574), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 189, 12, "192.168.2.189", 6 },
                    { 188, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3470), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 188, 12, "192.168.2.188", 6 },
                    { 187, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3367), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 187, 12, "192.168.2.187", 6 },
                    { 186, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3264), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 186, 12, "192.168.2.186", 6 },
                    { 185, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3160), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 185, 12, "192.168.2.185", 6 },
                    { 184, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3057), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 184, 12, "192.168.2.184", 6 },
                    { 183, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(2951), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 183, 12, "192.168.2.183", 6 },
                    { 191, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(3865), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 191, 12, "192.168.2.191", 6 },
                    { 202, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5202), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 202, 12, "192.168.2.202", 6 },
                    { 203, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5306), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 203, 12, "192.168.2.203", 6 },
                    { 204, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5410), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 204, 12, "192.168.2.204", 6 },
                    { 223, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(7896), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 223, 14, "192.168.2.223", 7 },
                    { 222, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(7786), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 222, 14, "192.168.2.222", 7 },
                    { 221, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(7607), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 221, 14, "192.168.2.221", 7 },
                    { 220, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(7502), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 220, 14, "192.168.2.220", 7 },
                    { 219, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(7397), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 219, 14, "192.168.2.219", 7 },
                    { 218, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(7290), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 218, 14, "192.168.2.218", 7 },
                    { 217, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(7177), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 217, 14, "192.168.2.217", 7 },
                    { 216, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6854), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 216, 12, "192.168.2.216", 6 },
                    { 215, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6725), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 215, 12, "192.168.2.215", 6 },
                    { 214, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6531), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 214, 12, "192.168.2.214", 6 },
                    { 213, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6427), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 213, 12, "192.168.2.213", 6 },
                    { 212, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6323), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 212, 12, "192.168.2.212", 6 },
                    { 211, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6218), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 211, 12, "192.168.2.211", 6 },
                    { 210, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6114), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 210, 12, "192.168.2.210", 6 },
                    { 209, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(6010), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 209, 12, "192.168.2.209", 6 },
                    { 208, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5904), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 208, 12, "192.168.2.208", 6 },
                    { 207, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5795), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 207, 12, "192.168.2.207", 6 },
                    { 206, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5617), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 206, 12, "192.168.2.206", 6 },
                    { 205, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(5513), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 205, 12, "192.168.2.205", 6 },
                    { 225, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(8108), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 225, 14, "192.168.2.225", 7 },
                    { 182, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(2846), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 182, 12, "192.168.2.182", 6 },
                    { 270, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3445), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 270, 16, "192.168.2.270", 8 },
                    { 272, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3767), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 272, 16, "192.168.2.272", 8 },
                    { 335, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1308), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 335, 20, "192.168.2.335", 10 },
                    { 334, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1204), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 334, 20, "192.168.2.334", 10 },
                    { 333, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1100), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 333, 20, "192.168.2.333", 10 },
                    { 332, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(996), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 332, 20, "192.168.2.332", 10 },
                    { 331, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(891), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 331, 20, "192.168.2.331", 10 },
                    { 330, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(786), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 330, 20, "192.168.2.330", 10 },
                    { 329, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(681), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 329, 20, "192.168.2.329", 10 },
                    { 328, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(573), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 328, 20, "192.168.2.328", 10 },
                    { 336, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1412), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 336, 20, "192.168.2.336", 10 },
                    { 327, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(392), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 327, 20, "192.168.2.327", 10 },
                    { 325, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(178), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 325, 20, "192.168.2.325", 10 },
                    { 324, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9913), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 324, 18, "192.168.2.324", 9 },
                    { 323, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9808), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 323, 18, "192.168.2.323", 9 },
                    { 322, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9704), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 322, 18, "192.168.2.322", 9 },
                    { 321, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9588), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 321, 18, "192.168.2.321", 9 },
                    { 320, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9424), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 320, 18, "192.168.2.320", 9 },
                    { 319, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9321), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 319, 18, "192.168.2.319", 9 },
                    { 318, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9218), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 318, 18, "192.168.2.318", 9 },
                    { 326, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(287), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 326, 20, "192.168.2.326", 10 },
                    { 337, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1631), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 337, 20, "192.168.2.337", 10 },
                    { 338, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1741), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 338, 20, "192.168.2.338", 10 },
                    { 339, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1846), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 339, 20, "192.168.2.339", 10 },
                    { 358, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3978), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 358, 20, "192.168.2.358", 10 },
                    { 357, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3873), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 357, 20, "192.168.2.357", 10 },
                    { 356, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3769), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 356, 20, "192.168.2.356", 10 },
                    { 355, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3665), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 355, 20, "192.168.2.355", 10 },
                    { 354, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3557), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 354, 20, "192.168.2.354", 10 },
                    { 353, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3382), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 353, 20, "192.168.2.353", 10 },
                    { 352, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3279), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 352, 20, "192.168.2.352", 10 },
                    { 351, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3176), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 351, 20, "192.168.2.351", 10 },
                    { 350, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(3073), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 350, 20, "192.168.2.350", 10 },
                    { 349, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2968), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 349, 20, "192.168.2.349", 10 },
                    { 348, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2864), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 348, 20, "192.168.2.348", 10 },
                    { 347, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2759), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 347, 20, "192.168.2.347", 10 },
                    { 346, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2653), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 346, 20, "192.168.2.346", 10 },
                    { 345, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2541), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 345, 20, "192.168.2.345", 10 },
                    { 344, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2366), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 344, 20, "192.168.2.344", 10 },
                    { 343, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2265), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 343, 20, "192.168.2.343", 10 },
                    { 342, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2159), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 342, 20, "192.168.2.342", 10 },
                    { 341, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(2056), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 341, 20, "192.168.2.341", 10 },
                    { 340, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(1951), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 340, 20, "192.168.2.340", 10 },
                    { 317, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9115), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 317, 18, "192.168.2.317", 9 },
                    { 271, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3547), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 271, 16, "192.168.2.271", 8 },
                    { 316, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(9010), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 316, 18, "192.168.2.316", 9 },
                    { 314, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8801), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 314, 18, "192.168.2.314", 9 },
                    { 290, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(5964), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 290, 18, "192.168.2.290", 9 },
                    { 289, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(5853), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 289, 18, "192.168.2.289", 9 },
                    { 288, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(5516), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 288, 16, "192.168.2.288", 8 },
                    { 287, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(5413), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 287, 16, "192.168.2.287", 8 },
                    { 286, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(5309), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 286, 16, "192.168.2.286", 8 },
                    { 285, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(5204), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 285, 16, "192.168.2.285", 8 },
                    { 284, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(5099), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 284, 16, "192.168.2.284", 8 },
                    { 283, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4994), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 283, 16, "192.168.2.283", 8 },
                    { 291, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6070), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 291, 18, "192.168.2.291", 9 },
                    { 282, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4888), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 282, 16, "192.168.2.282", 8 },
                    { 280, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4667), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 280, 16, "192.168.2.280", 8 },
                    { 279, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4502), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 279, 16, "192.168.2.279", 8 },
                    { 278, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4398), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 278, 16, "192.168.2.278", 8 },
                    { 277, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4294), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 277, 16, "192.168.2.277", 8 },
                    { 276, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4191), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 276, 16, "192.168.2.276", 8 },
                    { 275, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4087), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 275, 16, "192.168.2.275", 8 },
                    { 274, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3983), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 274, 16, "192.168.2.274", 8 },
                    { 273, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(3878), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 273, 16, "192.168.2.273", 8 },
                    { 281, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(4783), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 281, 16, "192.168.2.281", 8 },
                    { 292, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6174), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 292, 18, "192.168.2.292", 9 },
                    { 293, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6279), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 293, 18, "192.168.2.293", 9 },
                    { 294, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6383), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 294, 18, "192.168.2.294", 9 },
                    { 313, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8692), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 313, 18, "192.168.2.313", 9 },
                    { 312, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8511), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 312, 18, "192.168.2.312", 9 },
                    { 311, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8409), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 311, 18, "192.168.2.311", 9 },
                    { 310, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8305), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 310, 18, "192.168.2.310", 9 },
                    { 309, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8203), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 309, 18, "192.168.2.309", 9 },
                    { 308, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8101), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 308, 18, "192.168.2.308", 9 },
                    { 307, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7998), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 307, 18, "192.168.2.307", 9 },
                    { 306, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7895), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 306, 18, "192.168.2.306", 9 },
                    { 305, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7790), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 305, 18, "192.168.2.305", 9 },
                    { 304, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7681), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 304, 18, "192.168.2.304", 9 },
                    { 303, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7505), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 303, 18, "192.168.2.303", 9 },
                    { 302, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7398), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 302, 18, "192.168.2.302", 9 },
                    { 301, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7294), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 301, 18, "192.168.2.301", 9 },
                    { 300, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7188), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 300, 18, "192.168.2.300", 9 },
                    { 299, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(7057), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 299, 18, "192.168.2.299", 9 },
                    { 298, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6952), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 298, 18, "192.168.2.298", 9 },
                    { 297, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6846), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 297, 18, "192.168.2.297", 9 },
                    { 296, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6737), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 296, 18, "192.168.2.296", 9 },
                    { 295, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(6488), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 295, 18, "192.168.2.295", 9 },
                    { 315, new DateTime(2019, 12, 15, 18, 33, 44, 662, DateTimeKind.Local).AddTicks(8907), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 315, 18, "192.168.2.315", 9 },
                    { 181, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(2734), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 181, 12, "192.168.2.181", 6 },
                    { 180, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(2403), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 180, 10, "192.168.2.180", 5 },
                    { 179, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(2300), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 179, 10, "192.168.2.179", 5 },
                    { 64, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8145), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 64, 4, "192.168.2.64", 2 },
                    { 63, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8038), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 63, 4, "192.168.2.63", 2 },
                    { 62, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7932), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 62, 4, "192.168.2.62", 2 },
                    { 61, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7825), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 61, 4, "192.168.2.61", 2 },
                    { 60, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7718), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 60, 4, "192.168.2.60", 2 },
                    { 59, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7610), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 59, 4, "192.168.2.59", 2 },
                    { 58, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7500), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 58, 4, "192.168.2.58", 2 },
                    { 57, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7318), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 57, 4, "192.168.2.57", 2 },
                    { 65, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8337), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 65, 4, "192.168.2.65", 2 },
                    { 56, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7210), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 56, 4, "192.168.2.56", 2 },
                    { 54, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6969), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 54, 4, "192.168.2.54", 2 },
                    { 53, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6864), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 53, 4, "192.168.2.53", 2 },
                    { 52, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6758), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 52, 4, "192.168.2.52", 2 },
                    { 51, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6652), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 51, 4, "192.168.2.51", 2 },
                    { 50, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6545), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 50, 4, "192.168.2.50", 2 },
                    { 49, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6434), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 49, 4, "192.168.2.49", 2 },
                    { 48, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6248), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 48, 4, "192.168.2.48", 2 },
                    { 47, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(6092), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 47, 4, "192.168.2.47", 2 },
                    { 55, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(7075), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 55, 4, "192.168.2.55", 2 },
                    { 66, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8455), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 66, 4, "192.168.2.66", 2 },
                    { 67, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8564), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 67, 4, "192.168.2.67", 2 },
                    { 68, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8671), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 68, 4, "192.168.2.68", 2 },
                    { 87, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1034), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 87, 6, "192.168.2.87", 3 },
                    { 86, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(928), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 86, 6, "192.168.2.86", 3 },
                    { 85, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(822), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 85, 6, "192.168.2.85", 3 },
                    { 84, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(715), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 84, 6, "192.168.2.84", 3 },
                    { 83, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(609), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 83, 6, "192.168.2.83", 3 },
                    { 82, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(504), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 82, 6, "192.168.2.82", 3 },
                    { 81, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(397), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 81, 6, "192.168.2.81", 3 },
                    { 80, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(291), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 80, 6, "192.168.2.80", 3 },
                    { 79, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(169), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 79, 6, "192.168.2.79", 3 },
                    { 78, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 78, 6, "192.168.2.78", 3 },
                    { 77, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(9896), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 77, 6, "192.168.2.77", 3 },
                    { 76, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(9788), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 76, 6, "192.168.2.76", 3 },
                    { 75, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(9683), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 75, 6, "192.168.2.75", 3 },
                    { 74, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(9577), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 74, 6, "192.168.2.74", 3 },
                    { 73, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(9462), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 73, 6, "192.168.2.73", 3 },
                    { 72, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(9092), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 72, 4, "192.168.2.72", 2 },
                    { 71, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8987), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 71, 4, "192.168.2.71", 2 },
                    { 70, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8881), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 70, 4, "192.168.2.70", 2 },
                    { 69, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(8777), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 69, 4, "192.168.2.69", 2 },
                    { 46, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5987), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 46, 4, "192.168.2.46", 2 },
                    { 88, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1311), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 88, 6, "192.168.2.88", 3 },
                    { 45, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5880), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 45, 4, "192.168.2.45", 2 },
                    { 43, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5666), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 43, 4, "192.168.2.43", 2 },
                    { 19, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1750), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 19, 2, "192.168.2.19", 1 },
                    { 18, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1641), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 18, 2, "192.168.2.18", 1 },
                    { 17, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1464), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 17, 2, "192.168.2.17", 1 },
                    { 16, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1354), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 16, 2, "192.168.2.16", 1 },
                    { 15, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1248), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 15, 2, "192.168.2.15", 1 },
                    { 14, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1143), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 14, 2, "192.168.2.14", 1 },
                    { 13, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1037), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 13, 2, "192.168.2.13", 1 },
                    { 12, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(932), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 12, 2, "192.168.2.12", 1 },
                    { 20, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1856), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 20, 2, "192.168.2.20", 1 },
                    { 11, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(825), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 11, 2, "192.168.2.11", 1 },
                    { 9, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(520), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 9, 2, "192.168.2.9", 1 },
                    { 8, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(406), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 8, 2, "192.168.2.8", 1 },
                    { 7, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(299), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 7, 2, "192.168.2.7", 1 },
                    { 6, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(190), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 6, 2, "192.168.2.6", 1 },
                    { 5, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(70), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 5, 2, "192.168.2.5", 1 },
                    { 4, new DateTime(2019, 12, 15, 18, 33, 44, 658, DateTimeKind.Local).AddTicks(9937), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 4, 2, "192.168.2.4", 1 },
                    { 3, new DateTime(2019, 12, 15, 18, 33, 44, 658, DateTimeKind.Local).AddTicks(9807), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 3, 2, "192.168.2.3", 1 },
                    { 2, new DateTime(2019, 12, 15, 18, 33, 44, 658, DateTimeKind.Local).AddTicks(9542), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 2, 2, "192.168.2.2", 1 },
                    { 10, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(713), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 10, 2, "192.168.2.10", 1 },
                    { 21, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(1960), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 21, 2, "192.168.2.21", 1 },
                    { 22, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2064), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 22, 2, "192.168.2.22", 1 },
                    { 23, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2169), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 23, 2, "192.168.2.23", 1 },
                    { 42, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5559), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 42, 4, "192.168.2.42", 2 },
                    { 41, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5450), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 41, 4, "192.168.2.41", 2 },
                    { 40, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5327), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 40, 4, "192.168.2.40", 2 },
                    { 39, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5146), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 39, 4, "192.168.2.39", 2 },
                    { 38, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5036), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 38, 4, "192.168.2.38", 2 },
                    { 37, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(4917), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 37, 4, "192.168.2.37", 2 },
                    { 36, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(3759), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 36, 2, "192.168.2.36", 1 },
                    { 35, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(3653), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 35, 2, "192.168.2.35", 1 },
                    { 34, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(3544), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 34, 2, "192.168.2.34", 1 },
                    { 33, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(3363), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 33, 2, "192.168.2.33", 1 },
                    { 32, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(3253), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 32, 2, "192.168.2.32", 1 },
                    { 31, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(3148), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 31, 2, "192.168.2.31", 1 },
                    { 30, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(3043), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 30, 2, "192.168.2.30", 1 },
                    { 29, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2938), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 29, 2, "192.168.2.29", 1 },
                    { 28, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2835), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 28, 2, "192.168.2.28", 1 },
                    { 27, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2727), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 27, 2, "192.168.2.27", 1 },
                    { 26, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2599), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 26, 2, "192.168.2.26", 1 },
                    { 25, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2379), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 25, 2, "192.168.2.25", 1 },
                    { 24, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(2275), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 24, 2, "192.168.2.24", 1 },
                    { 44, new DateTime(2019, 12, 15, 18, 33, 44, 659, DateTimeKind.Local).AddTicks(5772), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 44, 4, "192.168.2.44", 2 },
                    { 89, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1425), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 89, 6, "192.168.2.89", 3 },
                    { 90, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1534), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 90, 6, "192.168.2.90", 3 },
                    { 91, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1639), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 91, 6, "192.168.2.91", 3 },
                    { 155, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9595), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 155, 10, "192.168.2.155", 5 },
                    { 154, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9492), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 154, 10, "192.168.2.154", 5 },
                    { 153, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9387), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 153, 10, "192.168.2.153", 5 },
                    { 152, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9282), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 152, 10, "192.168.2.152", 5 },
                    { 151, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9179), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 151, 10, "192.168.2.151", 5 },
                    { 150, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9075), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 150, 10, "192.168.2.150", 5 },
                    { 149, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(8964), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 149, 10, "192.168.2.149", 5 },
                    { 148, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(8737), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 148, 10, "192.168.2.148", 5 },
                    { 156, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9696), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 156, 10, "192.168.2.156", 5 },
                    { 147, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(8632), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 147, 10, "192.168.2.147", 5 },
                    { 145, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(8418), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 145, 10, "192.168.2.145", 5 },
                    { 144, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(8155), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 144, 8, "192.168.2.144", 4 },
                    { 143, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(8051), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 143, 8, "192.168.2.143", 4 },
                    { 142, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7942), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 142, 8, "192.168.2.142", 4 },
                    { 141, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7756), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 141, 8, "192.168.2.141", 4 },
                    { 140, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7652), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 140, 8, "192.168.2.140", 4 },
                    { 139, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7549), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 139, 8, "192.168.2.139", 4 },
                    { 138, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7444), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 138, 8, "192.168.2.138", 4 },
                    { 146, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(8528), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 146, 10, "192.168.2.146", 5 },
                    { 157, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9873), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 157, 10, "192.168.2.157", 5 },
                    { 158, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(9985), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 158, 10, "192.168.2.158", 5 },
                    { 159, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(89), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 159, 10, "192.168.2.159", 5 },
                    { 178, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(2196), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 178, 10, "192.168.2.178", 5 },
                    { 177, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(2093), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 177, 10, "192.168.2.177", 5 },
                    { 176, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1989), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 176, 10, "192.168.2.176", 5 },
                    { 175, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1884), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 175, 10, "192.168.2.175", 5 },
                    { 174, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1769), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 174, 10, "192.168.2.174", 5 },
                    { 173, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1610), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 173, 10, "192.168.2.173", 5 },
                    { 172, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1506), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 172, 10, "192.168.2.172", 5 },
                    { 171, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1401), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 171, 10, "192.168.2.171", 5 },
                    { 170, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1298), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 170, 10, "192.168.2.170", 5 },
                    { 169, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1195), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 169, 10, "192.168.2.169", 5 },
                    { 168, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(1092), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 168, 10, "192.168.2.168", 5 },
                    { 167, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(986), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 167, 10, "192.168.2.167", 5 },
                    { 166, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(877), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 166, 10, "192.168.2.166", 5 },
                    { 165, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(707), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 165, 10, "192.168.2.165", 5 },
                    { 164, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(605), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 164, 10, "192.168.2.164", 5 },
                    { 163, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(503), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 163, 10, "192.168.2.163", 5 },
                    { 162, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(400), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 162, 10, "192.168.2.162", 5 },
                    { 161, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(297), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 161, 10, "192.168.2.161", 5 },
                    { 160, new DateTime(2019, 12, 15, 18, 33, 44, 661, DateTimeKind.Local).AddTicks(193), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 160, 10, "192.168.2.160", 5 },
                    { 137, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7338), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 137, 8, "192.168.2.137", 4 },
                    { 136, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7231), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 136, 8, "192.168.2.136", 4 },
                    { 135, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(7099), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 135, 8, "192.168.2.135", 4 },
                    { 134, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6995), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 134, 8, "192.168.2.134", 4 },
                    { 110, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4145), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 110, 8, "192.168.2.110", 4 },
                    { 109, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4035), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 109, 8, "192.168.2.109", 4 },
                    { 108, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(3711), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 108, 6, "192.168.2.108", 3 },
                    { 107, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(3607), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 107, 6, "192.168.2.107", 3 },
                    { 106, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(3499), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 106, 6, "192.168.2.106", 3 },
                    { 105, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(3389), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 105, 6, "192.168.2.105", 3 },
                    { 104, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(3209), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 104, 6, "192.168.2.104", 3 },
                    { 103, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(3102), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 103, 6, "192.168.2.103", 3 },
                    { 102, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2997), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 102, 6, "192.168.2.102", 3 },
                    { 101, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2893), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 101, 6, "192.168.2.101", 3 },
                    { 100, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2786), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 100, 6, "192.168.2.100", 3 },
                    { 99, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2679), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 99, 6, "192.168.2.99", 3 },
                    { 98, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2572), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 98, 6, "192.168.2.98", 3 },
                    { 97, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2462), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 97, 6, "192.168.2.97", 3 },
                    { 96, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2166), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 96, 6, "192.168.2.96", 3 },
                    { 95, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(2061), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 95, 6, "192.168.2.95", 3 },
                    { 94, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1956), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 94, 6, "192.168.2.94", 3 },
                    { 93, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1851), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 93, 6, "192.168.2.93", 3 },
                    { 92, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(1745), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 92, 6, "192.168.2.92", 3 },
                    { 111, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4249), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 111, 8, "192.168.2.111", 4 },
                    { 359, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(4081), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 359, 20, "192.168.2.359", 10 },
                    { 112, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4432), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 112, 8, "192.168.2.112", 4 },
                    { 114, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4650), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 114, 8, "192.168.2.114", 4 },
                    { 133, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6879), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 133, 8, "192.168.2.133", 4 },
                    { 132, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6712), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 132, 8, "192.168.2.132", 4 },
                    { 131, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6607), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 131, 8, "192.168.2.131", 4 },
                    { 130, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6499), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 130, 8, "192.168.2.130", 4 },
                    { 129, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6382), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 129, 8, "192.168.2.129", 4 },
                    { 128, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6197), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 128, 8, "192.168.2.128", 4 },
                    { 127, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(6093), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 127, 8, "192.168.2.127", 4 },
                    { 126, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5988), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 126, 8, "192.168.2.126", 4 },
                    { 125, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5884), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 125, 8, "192.168.2.125", 4 },
                    { 124, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5778), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 124, 8, "192.168.2.124", 4 },
                    { 123, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5673), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 123, 8, "192.168.2.123", 4 },
                    { 122, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5566), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 122, 8, "192.168.2.122", 4 },
                    { 121, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5460), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 121, 8, "192.168.2.121", 4 },
                    { 120, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5341), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 120, 8, "192.168.2.120", 4 },
                    { 119, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5176), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 119, 8, "192.168.2.119", 4 },
                    { 118, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(5072), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 118, 8, "192.168.2.118", 4 },
                    { 117, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4967), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 117, 8, "192.168.2.117", 4 },
                    { 116, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4861), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 116, 8, "192.168.2.116", 4 },
                    { 115, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4756), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 115, 8, "192.168.2.115", 4 },
                    { 113, new DateTime(2019, 12, 15, 18, 33, 44, 660, DateTimeKind.Local).AddTicks(4543), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 113, 8, "192.168.2.113", 4 },
                    { 360, new DateTime(2019, 12, 15, 18, 33, 44, 663, DateTimeKind.Local).AddTicks(4184), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 360, 20, "192.168.2.360", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_EnvironmentId",
                table: "ERROR",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_LevelId",
                table: "ERROR",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_SituationId",
                table: "ERROR",
                column: "SituationId");

            migrationBuilder.CreateIndex(
                name: "IX_Error_Occurrence_ErrorId",
                table: "Error_Occurrence",
                column: "ErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_Error_Occurrence_UserId",
                table: "Error_Occurrence",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Error_Occurrence");

            migrationBuilder.DropTable(
                name: "ERROR");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "environment");

            migrationBuilder.DropTable(
                name: "level");

            migrationBuilder.DropTable(
                name: "situation");
        }
    }
}
