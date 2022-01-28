using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Empresa.Projeto.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePermissao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValue: 1),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoUsuario",
                columns: table => new
                {
                    PermissoesId = table.Column<long>(type: "bigint", nullable: false),
                    UsuariosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoUsuario", x => new { x.PermissoesId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_PermissaoUsuario_Permissoes_PermissoesId",
                        column: x => x.PermissoesId,
                        principalTable: "Permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissaoUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoUsuario_UsuariosId",
                table: "PermissaoUsuario",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissaoUsuario");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
