﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa.Projeto.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadForm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TamanhoEmBytes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ExtensaoArquivo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NomeArquivoOriginal = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoRelativo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoAbsoluto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissaoId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Apelido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Senha = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemUsuario",
                columns: table => new
                {
                    OrdensId = table.Column<long>(type: "bigint", nullable: false),
                    UsuariosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemUsuario", x => new { x.OrdensId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_OrdemUsuario_Ordem_OrdensId",
                        column: x => x.OrdensId,
                        principalTable: "Ordem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemUsuario_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemUsuario_UsuariosId",
                table: "OrdemUsuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PermissaoId",
                table: "Usuario",
                column: "PermissaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemUsuario");

            migrationBuilder.DropTable(
                name: "UploadForm");

            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Permissao");
        }
    }
}
