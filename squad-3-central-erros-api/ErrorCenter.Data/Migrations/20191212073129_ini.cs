﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorCenter.Data.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENVIRONMENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENVIRONMENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LEVEL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEVEL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SITUATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITUATION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 200, nullable: false),
                    PASSWORD = table.Column<string>(maxLength: 50, nullable: false),
                    TOKEN = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ERROR",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<int>(nullable: false),
                    TITLE = table.Column<string>(maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 200, nullable: false),
                    EnvironmentId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    SituationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ERROR_ENVIRONMENT_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "ENVIRONMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_LEVEL_LevelId",
                        column: x => x.LevelId,
                        principalTable: "LEVEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_SITUATION_SituationId",
                        column: x => x.SituationId,
                        principalTable: "SITUATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ERROR_OCCURRENCE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORIGIN = table.Column<string>(maxLength: 200, nullable: false),
                    DETAILS = table.Column<string>(maxLength: 2000, nullable: false),
                    DATE_TIME = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ErrorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR_OCCURRENCE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_ERROR_ErrorId",
                        column: x => x.ErrorId,
                        principalTable: "ERROR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ERROR_OCCURRENCE_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ENVIRONMENT",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Produção" },
                    { 2, "Homologação" },
                    { 3, "Dev" }
                });

            migrationBuilder.InsertData(
                table: "LEVEL",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "debug" },
                    { 2, "warning" },
                    { 3, "error" }
                });

            migrationBuilder.InsertData(
                table: "SITUATION",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 2, "Arquivado" }
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "ID", "EMAIL", "NAME", "PASSWORD", "TOKEN" },
                values: new object[,]
                {
                    { 8, "user8@sp.com.br", "Usuário 8", "86a1fa88adb5c33bd7a68ac2f9f3f96b", "2c31f93a-25ec-4bff-b348-b71a899630db" },
                    { 7, "user7@sp.com.br", "Usuário 7", "68053af2923e00204c3ca7c6a3150cf7", "e618562a-2d05-4873-847b-d047d495a01f" },
                    { 6, "user6@sp.com.br", "Usuário 6", "9fe8593a8a330607d76796b35c64c600", "2ab0112a-fcf9-4dad-b98a-2121b2a6a5e7" },
                    { 5, "user5@sp.com.br", "Usuário 5", "99c5e07b4d5de9d18c350cdf64c5aa3d", "12a95959-668d-4b86-bc42-8f9bec0b4b84" },
                    { 1, "user1@sp.com.br", "Usuário 1", "202cb962ac59075b964b07152d234b70", "d5f94ff1-7b3c-4916-9258-5425f2326282" },
                    { 3, "user3@sp.com.br", "Usuário 3", "d81f9c1be2e08964bf9f24b15f0e4900", "1e0fb212-5fdb-4434-939c-f55e8ca52c7e" },
                    { 2, "user2@sp.com.br", "Usuário 2", "289dff07669d7a23de0ef88d2f7129e7", "39812756-2e19-4031-b072-00d08c2e2948" },
                    { 9, "user9@sp.com.br", "Usuário 9", "7cf08c3ddac57a6d4f28034f88bfb23e", "aebc544d-4e2c-444d-ae10-b011f6b2ec22" },
                    { 4, "user4@sp.com.br", "Usuário 4", "250cf8b51c773f3f8dc8b4be867a9a02", "92bbef4e-a2ca-4dec-bad9-f2b3c9fe4736" },
                    { 10, "user10@sp.com.br", "Usuário 10", "cdd773039f5b1a8f41949a1fccd0768f", "5391f1a0-ba80-435f-bb2c-6cf70c02fe87" }
                });

            migrationBuilder.InsertData(
                table: "ERROR",
                columns: new[] { "ID", "CODE", "DESCRIPTION", "EnvironmentId", "LevelId", "SituationId", "TITLE" },
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
                    { 173, 50303, "bla bla bla bla", 3, 2, 1, "aceleration.Service.Service533" }
                });

            migrationBuilder.InsertData(
                table: "ERROR",
                columns: new[] { "ID", "CODE", "DESCRIPTION", "EnvironmentId", "LevelId", "SituationId", "TITLE" },
                values: new object[,]
                {
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
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ID", "DATE_TIME", "DETAILS", "ErrorId", "ORIGIN", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 12, 12, 4, 31, 29, 18, DateTimeKind.Local).AddTicks(4669), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 1, "192.168.2.1", 1 },
                    { 245, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5450), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 245, "192.168.2.245", 7 },
                    { 244, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5343), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 244, "192.168.2.244", 7 },
                    { 243, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5236), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 243, "192.168.2.243", 7 },
                    { 242, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5121), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 242, "192.168.2.242", 7 },
                    { 241, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4967), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 241, "192.168.2.241", 7 },
                    { 240, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4864), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 240, "192.168.2.240", 7 },
                    { 239, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4757), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 239, "192.168.2.239", 7 },
                    { 238, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4655), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 238, "192.168.2.238", 7 },
                    { 246, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5553), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 246, "192.168.2.246", 7 },
                    { 237, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4548), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 237, "192.168.2.237", 7 },
                    { 235, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4334), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 235, "192.168.2.235", 7 },
                    { 234, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4227), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 234, "192.168.2.234", 7 },
                    { 233, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4052), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 233, "192.168.2.233", 7 },
                    { 232, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3945), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 232, "192.168.2.232", 7 },
                    { 231, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3842), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 231, "192.168.2.231", 7 },
                    { 230, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3735), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 230, "192.168.2.230", 7 },
                    { 229, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3633), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 229, "192.168.2.229", 7 },
                    { 228, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3526), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 228, "192.168.2.228", 7 },
                    { 236, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(4441), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 236, "192.168.2.236", 7 },
                    { 247, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5741), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 247, "192.168.2.247", 7 },
                    { 248, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5852), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 248, "192.168.2.248", 7 },
                    { 249, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(5959), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 249, "192.168.2.249", 7 },
                    { 268, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8349), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 268, "192.168.2.268", 8 },
                    { 267, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8242), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 267, "192.168.2.267", 8 },
                    { 266, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8093), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 266, "192.168.2.266", 8 },
                    { 265, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7990), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 265, "192.168.2.265", 8 },
                    { 264, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7887), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 264, "192.168.2.264", 8 },
                    { 263, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7785), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 263, "192.168.2.263", 8 },
                    { 262, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7678), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 262, "192.168.2.262", 8 },
                    { 261, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7575), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 261, "192.168.2.261", 8 },
                    { 260, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7473), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 260, "192.168.2.260", 8 },
                    { 259, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7366), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 259, "192.168.2.259", 8 },
                    { 258, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7255), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 258, "192.168.2.258", 8 },
                    { 257, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(7079), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 257, "192.168.2.257", 8 },
                    { 256, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(6921), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 256, "192.168.2.256", 8 },
                    { 255, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(6814), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 255, "192.168.2.255", 8 },
                    { 254, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(6711), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 254, "192.168.2.254", 8 },
                    { 253, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(6600), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 253, "192.168.2.253", 8 },
                    { 252, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(6322), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 252, "192.168.2.252", 7 },
                    { 251, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(6215), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 251, "192.168.2.251", 7 },
                    { 250, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(6066), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 250, "192.168.2.250", 7 },
                    { 227, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3419), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 227, "192.168.2.227", 7 },
                    { 269, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8452), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 269, "192.168.2.269", 8 },
                    { 226, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3312), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 226, "192.168.2.226", 7 },
                    { 224, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3038), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 224, "192.168.2.224", 7 },
                    { 200, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9977), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 200, "192.168.2.200", 6 },
                    { 199, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9874), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 199, "192.168.2.199", 6 },
                    { 198, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9767), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 198, "192.168.2.198", 6 },
                    { 197, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9664), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 197, "192.168.2.197", 6 },
                    { 196, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9557), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 196, "192.168.2.196", 6 },
                    { 195, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9455), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 195, "192.168.2.195", 6 },
                    { 194, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9352), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 194, "192.168.2.194", 6 },
                    { 193, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9245), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 193, "192.168.2.193", 6 },
                    { 201, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(122), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 201, "192.168.2.201", 6 },
                    { 192, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(9130), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 192, "192.168.2.192", 6 },
                    { 190, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8860), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 190, "192.168.2.190", 6 },
                    { 189, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8754), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 189, "192.168.2.189", 6 },
                    { 188, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8651), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 188, "192.168.2.188", 6 },
                    { 187, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8544), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 187, "192.168.2.187", 6 },
                    { 186, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8441), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 186, "192.168.2.186", 6 },
                    { 185, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8334), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 185, "192.168.2.185", 6 },
                    { 184, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8228), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 184, "192.168.2.184", 6 },
                    { 183, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8061), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 183, "192.168.2.183", 6 },
                    { 191, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(8963), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 191, "192.168.2.191", 6 },
                    { 202, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(229), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 202, "192.168.2.202", 6 },
                    { 203, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(336), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 203, "192.168.2.203", 6 },
                    { 204, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(443), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 204, "192.168.2.204", 6 },
                    { 223, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(2936), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 223, "192.168.2.223", 7 },
                    { 222, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(2833), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 222, "192.168.2.222", 7 },
                    { 221, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(2726), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 221, "192.168.2.221", 7 },
                    { 220, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(2624), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 220, "192.168.2.220", 7 },
                    { 219, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(2517), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 219, "192.168.2.219", 7 },
                    { 218, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(2410), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 218, "192.168.2.218", 7 },
                    { 217, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(2299), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 217, "192.168.2.217", 7 },
                    { 216, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(1897), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 216, "192.168.2.216", 6 },
                    { 215, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(1790), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 215, "192.168.2.215", 6 },
                    { 214, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(1687), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 214, "192.168.2.214", 6 },
                    { 213, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(1580), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 213, "192.168.2.213", 6 },
                    { 212, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(1473), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 212, "192.168.2.212", 6 },
                    { 211, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(1366), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 211, "192.168.2.211", 6 },
                    { 210, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(1255), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 210, "192.168.2.210", 6 },
                    { 209, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(960), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 209, "192.168.2.209", 6 },
                    { 208, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(857), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 208, "192.168.2.208", 6 },
                    { 207, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(751), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 207, "192.168.2.207", 6 },
                    { 206, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(648), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 206, "192.168.2.206", 6 },
                    { 205, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(545), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 205, "192.168.2.205", 6 },
                    { 225, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(3205), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 225, "192.168.2.225", 7 },
                    { 182, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(7954), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 182, "192.168.2.182", 6 },
                    { 270, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8555), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 270, "192.168.2.270", 8 },
                    { 272, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8764), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 272, "192.168.2.272", 8 },
                    { 335, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6428), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 335, "192.168.2.335", 10 },
                    { 334, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6325), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 334, "192.168.2.334", 10 },
                    { 333, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6218), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 333, "192.168.2.333", 10 },
                    { 332, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6107), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 332, "192.168.2.332", 10 },
                    { 331, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(5914), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 331, "192.168.2.331", 10 },
                    { 330, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(5812), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 330, "192.168.2.330", 10 },
                    { 329, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(5654), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 329, "192.168.2.329", 10 },
                    { 328, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(5516), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 328, "192.168.2.328", 10 },
                    { 336, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6535), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 336, "192.168.2.336", 10 },
                    { 327, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(5409), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 327, "192.168.2.327", 10 },
                    { 325, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(5196), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 325, "192.168.2.325", 10 },
                    { 324, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4841), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 324, "192.168.2.324", 9 },
                    { 323, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4734), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 323, "192.168.2.323", 9 },
                    { 322, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4627), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 322, "192.168.2.322", 9 },
                    { 321, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4524), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 321, "192.168.2.321", 9 },
                    { 320, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4422), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 320, "192.168.2.320", 9 },
                    { 319, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4315), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 319, "192.168.2.319", 9 },
                    { 318, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4212), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 318, "192.168.2.318", 9 },
                    { 326, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(5307), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 326, "192.168.2.326", 10 },
                    { 337, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6637), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 337, "192.168.2.337", 10 },
                    { 338, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6740), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 338, "192.168.2.338", 10 },
                    { 339, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6842), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 339, "192.168.2.339", 10 },
                    { 358, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(9092), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 358, "192.168.2.358", 10 },
                    { 357, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8925), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 357, "192.168.2.357", 10 },
                    { 356, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8822), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 356, "192.168.2.356", 10 },
                    { 355, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8720), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 355, "192.168.2.355", 10 },
                    { 354, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8613), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 354, "192.168.2.354", 10 },
                    { 353, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8510), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 353, "192.168.2.353", 10 },
                    { 352, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8408), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 352, "192.168.2.352", 10 },
                    { 351, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8301), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 351, "192.168.2.351", 10 },
                    { 350, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8194), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 350, "192.168.2.350", 10 },
                    { 349, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(8078), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 349, "192.168.2.349", 10 },
                    { 348, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7826), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 348, "192.168.2.348", 10 },
                    { 347, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7723), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 347, "192.168.2.347", 10 },
                    { 346, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7621), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 346, "192.168.2.346", 10 },
                    { 345, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7514), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 345, "192.168.2.345", 10 },
                    { 344, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7411), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 344, "192.168.2.344", 10 },
                    { 343, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7309), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 343, "192.168.2.343", 10 },
                    { 342, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7202), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 342, "192.168.2.342", 10 },
                    { 341, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(7095), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 341, "192.168.2.341", 10 },
                    { 340, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(6949), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 340, "192.168.2.340", 10 },
                    { 317, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(4105), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 317, "192.168.2.317", 9 },
                    { 271, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8661), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 271, "192.168.2.271", 8 },
                    { 316, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3973), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 316, "192.168.2.316", 9 },
                    { 314, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3669), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 314, "192.168.2.314", 9 },
                    { 290, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(902), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 290, "192.168.2.290", 9 },
                    { 289, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(795), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 289, "192.168.2.289", 9 },
                    { 288, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(517), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 288, "192.168.2.288", 8 },
                    { 287, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(415), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 287, "192.168.2.287", 8 },
                    { 286, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(308), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 286, "192.168.2.286", 8 },
                    { 285, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(205), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 285, "192.168.2.285", 8 },
                    { 284, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(98), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 284, "192.168.2.284", 8 },
                    { 283, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9953), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 283, "192.168.2.283", 8 },
                    { 291, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1073), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 291, "192.168.2.291", 9 },
                    { 282, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9846), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 282, "192.168.2.282", 8 },
                    { 280, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9641), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 280, "192.168.2.280", 8 },
                    { 279, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9534), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 279, "192.168.2.279", 8 },
                    { 278, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9431), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 278, "192.168.2.278", 8 },
                    { 277, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9329), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 277, "192.168.2.277", 8 },
                    { 276, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9222), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 276, "192.168.2.276", 8 },
                    { 275, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9115), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 275, "192.168.2.275", 8 },
                    { 274, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8974), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 274, "192.168.2.274", 8 },
                    { 273, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(8867), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 273, "192.168.2.273", 8 },
                    { 281, new DateTime(2019, 12, 12, 4, 31, 29, 23, DateTimeKind.Local).AddTicks(9743), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 281, "192.168.2.281", 8 },
                    { 292, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1184), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 292, "192.168.2.292", 9 },
                    { 293, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1291), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 293, "192.168.2.293", 9 },
                    { 294, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1394), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 294, "192.168.2.294", 9 },
                    { 313, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3566), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 313, "192.168.2.313", 9 },
                    { 312, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3459), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 312, "192.168.2.312", 9 },
                    { 311, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3357), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 311, "192.168.2.311", 9 },
                    { 310, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3250), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 310, "192.168.2.310", 9 },
                    { 309, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3143), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 309, "192.168.2.309", 9 },
                    { 308, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3036), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 308, "192.168.2.308", 9 },
                    { 307, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2792), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 307, "192.168.2.307", 9 },
                    { 306, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2690), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 306, "192.168.2.306", 9 },
                    { 305, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2587), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 305, "192.168.2.305", 9 },
                    { 304, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2480), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 304, "192.168.2.304", 9 },
                    { 303, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2378), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 303, "192.168.2.303", 9 },
                    { 302, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2275), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 302, "192.168.2.302", 9 },
                    { 301, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2172), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 301, "192.168.2.301", 9 },
                    { 300, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(2065), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 300, "192.168.2.300", 9 },
                    { 299, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1954), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 299, "192.168.2.299", 9 },
                    { 298, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1809), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 298, "192.168.2.298", 9 },
                    { 297, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1706), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 297, "192.168.2.297", 9 },
                    { 296, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1604), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 296, "192.168.2.296", 9 },
                    { 295, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(1501), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 295, "192.168.2.295", 9 },
                    { 315, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(3772), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 315, "192.168.2.315", 9 },
                    { 181, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(7843), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 181, "192.168.2.181", 6 },
                    { 180, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(7565), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 180, "192.168.2.180", 5 },
                    { 179, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(7458), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 179, "192.168.2.179", 5 },
                    { 64, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3602), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 64, "192.168.2.64", 2 },
                    { 63, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3500), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 63, "192.168.2.63", 2 },
                    { 62, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3397), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 62, "192.168.2.62", 2 },
                    { 61, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3290), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 61, "192.168.2.61", 2 },
                    { 60, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3188), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 60, "192.168.2.60", 2 },
                    { 59, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3081), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 59, "192.168.2.59", 2 },
                    { 58, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2935), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 58, "192.168.2.58", 2 },
                    { 57, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2828), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 57, "192.168.2.57", 2 },
                    { 65, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3714), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 65, "192.168.2.65", 2 },
                    { 56, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2721), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 56, "192.168.2.56", 2 },
                    { 54, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2516), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 54, "192.168.2.54", 2 },
                    { 53, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2409), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 53, "192.168.2.53", 2 },
                    { 52, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2307), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 52, "192.168.2.52", 2 },
                    { 51, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2200), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 51, "192.168.2.51", 2 },
                    { 50, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2050), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 50, "192.168.2.50", 2 },
                    { 49, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1943), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 49, "192.168.2.49", 2 },
                    { 48, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1836), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 48, "192.168.2.48", 2 },
                    { 47, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1665), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 47, "192.168.2.47", 2 },
                    { 55, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(2619), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 55, "192.168.2.55", 2 },
                    { 66, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3876), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 66, "192.168.2.66", 2 },
                    { 67, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(3987), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 67, "192.168.2.67", 2 },
                    { 68, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(4090), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 68, "192.168.2.68", 2 },
                    { 87, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6497), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 87, "192.168.2.87", 3 },
                    { 86, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6390), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 86, "192.168.2.86", 3 },
                    { 85, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6288), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 85, "192.168.2.85", 3 },
                    { 84, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6181), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 84, "192.168.2.84", 3 },
                    { 83, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6078), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 83, "192.168.2.83", 3 },
                    { 82, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5971), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 82, "192.168.2.82", 3 },
                    { 81, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5860), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 81, "192.168.2.81", 3 },
                    { 80, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5685), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 80, "192.168.2.80", 3 },
                    { 79, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5518), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 79, "192.168.2.79", 3 },
                    { 78, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5411), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 78, "192.168.2.78", 3 },
                    { 77, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5309), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 77, "192.168.2.77", 3 },
                    { 76, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5202), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 76, "192.168.2.76", 3 },
                    { 75, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(5099), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 75, "192.168.2.75", 3 },
                    { 74, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(4992), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 74, "192.168.2.74", 3 },
                    { 73, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(4881), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 73, "192.168.2.73", 3 },
                    { 72, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(4509), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 72, "192.168.2.72", 2 },
                    { 71, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(4402), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 71, "192.168.2.71", 2 },
                    { 70, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(4299), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 70, "192.168.2.70", 2 },
                    { 69, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(4197), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 69, "192.168.2.69", 2 },
                    { 46, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1558), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 46, "192.168.2.46", 2 },
                    { 88, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6600), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 88, "192.168.2.88", 3 },
                    { 45, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1451), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 45, "192.168.2.45", 2 },
                    { 43, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1238), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 43, "192.168.2.43", 2 },
                    { 19, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7479), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 19, "192.168.2.19", 1 },
                    { 18, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7325), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 18, "192.168.2.18", 1 },
                    { 17, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7214), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 17, "192.168.2.17", 1 },
                    { 16, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7102), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 16, "192.168.2.16", 1 },
                    { 15, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6995), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 15, "192.168.2.15", 1 },
                    { 14, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6889), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 14, "192.168.2.14", 1 },
                    { 13, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6782), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 13, "192.168.2.13", 1 },
                    { 12, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6670), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 12, "192.168.2.12", 1 },
                    { 20, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7586), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 20, "192.168.2.20", 1 },
                    { 11, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6559), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 11, "192.168.2.11", 1 },
                    { 9, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6251), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 9, "192.168.2.9", 1 },
                    { 8, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6136), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 8, "192.168.2.8", 1 },
                    { 7, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6025), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 7, "192.168.2.7", 1 },
                    { 6, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(5905), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 6, "192.168.2.6", 1 },
                    { 5, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(5772), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 5, "192.168.2.5", 1 },
                    { 4, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(5541), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 4, "192.168.2.4", 1 },
                    { 3, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(5404), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 3, "192.168.2.3", 1 },
                    { 2, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(4921), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 2, "192.168.2.2", 1 },
                    { 10, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(6367), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 10, "192.168.2.10", 1 },
                    { 21, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7693), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 21, "192.168.2.21", 1 },
                    { 22, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7799), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 22, "192.168.2.22", 1 },
                    { 23, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(7902), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 23, "192.168.2.23", 1 },
                    { 42, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1126), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 42, "192.168.2.42", 2 },
                    { 41, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(925), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 41, "192.168.2.41", 2 },
                    { 40, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(823), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 40, "192.168.2.40", 2 },
                    { 39, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(712), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 39, "192.168.2.39", 2 },
                    { 38, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(605), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 38, "192.168.2.38", 2 },
                    { 37, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(489), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 37, "192.168.2.37", 2 },
                    { 36, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(9377), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 36, "192.168.2.36", 1 },
                    { 35, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(9270), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 35, "192.168.2.35", 1 },
                    { 34, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(9121), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 34, "192.168.2.34", 1 },
                    { 33, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(9010), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 33, "192.168.2.33", 1 },
                    { 32, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8898), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 32, "192.168.2.32", 1 },
                    { 31, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8792), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 31, "192.168.2.31", 1 },
                    { 30, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8689), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 30, "192.168.2.30", 1 },
                    { 29, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8582), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 29, "192.168.2.29", 1 },
                    { 28, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8479), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 28, "192.168.2.28", 1 },
                    { 27, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8325), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 27, "192.168.2.27", 1 },
                    { 26, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8219), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 26, "192.168.2.26", 1 },
                    { 25, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8112), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 25, "192.168.2.25", 1 },
                    { 24, new DateTime(2019, 12, 12, 4, 31, 29, 20, DateTimeKind.Local).AddTicks(8009), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 24, "192.168.2.24", 1 },
                    { 44, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(1349), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 44, "192.168.2.44", 2 },
                    { 89, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6702), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 89, "192.168.2.89", 3 },
                    { 90, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6873), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 90, "192.168.2.90", 3 },
                    { 91, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(6985), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 91, "192.168.2.91", 3 },
                    { 155, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4648), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 155, "192.168.2.155", 5 },
                    { 154, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4541), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 154, "192.168.2.154", 5 },
                    { 153, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4438), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 153, "192.168.2.153", 5 },
                    { 152, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4331), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 152, "192.168.2.152", 5 },
                    { 151, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4220), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 151, "192.168.2.151", 5 },
                    { 150, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4053), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 150, "192.168.2.150", 5 },
                    { 149, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(3951), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 149, "192.168.2.149", 5 },
                    { 148, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(3844), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 148, "192.168.2.148", 5 },
                    { 156, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4750), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 156, "192.168.2.156", 5 },
                    { 147, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(3741), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 147, "192.168.2.147", 5 },
                    { 145, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(3523), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 145, "192.168.2.145", 5 },
                    { 144, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(3232), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 144, "192.168.2.144", 4 },
                    { 143, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(3083), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 143, "192.168.2.143", 4 },
                    { 142, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2980), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 142, "192.168.2.142", 4 },
                    { 141, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2877), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 141, "192.168.2.141", 4 },
                    { 140, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2775), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 140, "192.168.2.140", 4 },
                    { 139, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2668), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 139, "192.168.2.139", 4 },
                    { 138, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2565), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 138, "192.168.2.138", 4 },
                    { 146, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(3634), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 146, "192.168.2.146", 5 },
                    { 157, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4857), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 157, "192.168.2.157", 5 },
                    { 158, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(4960), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 158, "192.168.2.158", 5 },
                    { 159, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5063), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 159, "192.168.2.159", 5 },
                    { 178, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(7355), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 178, "192.168.2.178", 5 },
                    { 177, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(7248), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 177, "192.168.2.177", 5 },
                    { 176, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(7099), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 176, "192.168.2.176", 5 },
                    { 175, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6996), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 175, "192.168.2.175", 5 },
                    { 174, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6889), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 174, "192.168.2.174", 5 },
                    { 173, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6786), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 173, "192.168.2.173", 5 },
                    { 172, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6679), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 172, "192.168.2.172", 5 },
                    { 171, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6577), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 171, "192.168.2.171", 5 },
                    { 170, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6470), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 170, "192.168.2.170", 5 },
                    { 169, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6363), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 169, "192.168.2.169", 5 },
                    { 168, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6248), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 168, "192.168.2.168", 5 },
                    { 167, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(6077), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 167, "192.168.2.167", 5 },
                    { 166, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5974), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 166, "192.168.2.166", 5 },
                    { 165, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5867), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 165, "192.168.2.165", 5 },
                    { 164, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5704), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 164, "192.168.2.164", 5 },
                    { 163, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5533), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 163, "192.168.2.163", 5 },
                    { 162, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5426), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 162, "192.168.2.162", 5 },
                    { 161, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5319), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 161, "192.168.2.161", 5 },
                    { 160, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(5212), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 160, "192.168.2.160", 5 },
                    { 137, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2463), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 137, "192.168.2.137", 4 },
                    { 136, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2356), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 136, "192.168.2.136", 4 },
                    { 135, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2240), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 135, "192.168.2.135", 4 },
                    { 134, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(2086), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 134, "192.168.2.134", 4 },
                    { 110, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(9384), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 110, "192.168.2.110", 4 },
                    { 109, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(9277), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 109, "192.168.2.109", 4 },
                    { 108, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8965), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 108, "192.168.2.108", 3 },
                    { 107, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8849), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 107, "192.168.2.107", 3 },
                    { 106, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8601), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 106, "192.168.2.106", 3 },
                    { 105, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8494), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 105, "192.168.2.105", 3 },
                    { 104, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8392), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 104, "192.168.2.104", 3 },
                    { 103, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8285), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 103, "192.168.2.103", 3 },
                    { 102, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8182), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 102, "192.168.2.102", 3 },
                    { 101, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(8075), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 101, "192.168.2.101", 3 },
                    { 100, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7968), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 100, "192.168.2.100", 3 },
                    { 99, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7866), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 99, "192.168.2.99", 3 },
                    { 98, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7746), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 98, "192.168.2.98", 3 },
                    { 97, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7613), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 97, "192.168.2.97", 3 },
                    { 96, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7506), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 96, "192.168.2.96", 3 },
                    { 95, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7404), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 95, "192.168.2.95", 3 },
                    { 94, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7301), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 94, "192.168.2.94", 3 },
                    { 93, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7194), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 93, "192.168.2.93", 3 },
                    { 92, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(7087), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 92, "192.168.2.92", 3 },
                    { 111, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(9491), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 111, "192.168.2.111", 4 },
                    { 359, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(9203), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 359, "192.168.2.359", 10 },
                    { 112, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(9602), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 112, "192.168.2.112", 4 },
                    { 114, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(9884), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 114, "192.168.2.114", 4 },
                    { 133, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1979), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 133, "192.168.2.133", 4 },
                    { 132, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1877), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 132, "192.168.2.132", 4 },
                    { 131, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1774), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 131, "192.168.2.131", 4 },
                    { 130, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1667), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 130, "192.168.2.130", 4 },
                    { 129, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1556), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 129, "192.168.2.129", 4 },
                    { 128, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1402), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 128, "192.168.2.128", 4 },
                    { 127, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1299), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 127, "192.168.2.127", 4 },
                    { 126, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1197), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 126, "192.168.2.126", 4 },
                    { 125, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(1094), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 125, "192.168.2.125", 4 },
                    { 124, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(987), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 124, "192.168.2.124", 4 }
                });

            migrationBuilder.InsertData(
                table: "ERROR_OCCURRENCE",
                columns: new[] { "ID", "DATE_TIME", "DETAILS", "ErrorId", "ORIGIN", "UserId" },
                values: new object[,]
                {
                    { 123, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(880), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 123, "192.168.2.123", 4 },
                    { 122, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(731), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 122, "192.168.2.122", 4 },
                    { 121, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(628), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 121, "192.168.2.121", 4 },
                    { 120, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(521), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 120, "192.168.2.120", 4 },
                    { 119, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(419), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 119, "192.168.2.119", 4 },
                    { 118, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(316), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 118, "192.168.2.118", 4 },
                    { 117, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(209), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 117, "192.168.2.117", 4 },
                    { 116, new DateTime(2019, 12, 12, 4, 31, 29, 22, DateTimeKind.Local).AddTicks(102), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 116, "192.168.2.116", 4 },
                    { 115, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(9995), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 115, "192.168.2.115", 4 },
                    { 113, new DateTime(2019, 12, 12, 4, 31, 29, 21, DateTimeKind.Local).AddTicks(9704), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 113, "192.168.2.113", 4 },
                    { 360, new DateTime(2019, 12, 12, 4, 31, 29, 24, DateTimeKind.Local).AddTicks(9306), @"Det1
                Det2
                detalhe 3
                Detalhe maior 4", 360, "192.168.2.360", 10 }
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
                name: "IX_ERROR_OCCURRENCE_ErrorId",
                table: "ERROR_OCCURRENCE",
                column: "ErrorId");

            migrationBuilder.CreateIndex(
                name: "IX_ERROR_OCCURRENCE_UserId",
                table: "ERROR_OCCURRENCE",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ERROR_OCCURRENCE");

            migrationBuilder.DropTable(
                name: "ERROR");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "ENVIRONMENT");

            migrationBuilder.DropTable(
                name: "LEVEL");

            migrationBuilder.DropTable(
                name: "SITUATION");
        }
    }
}