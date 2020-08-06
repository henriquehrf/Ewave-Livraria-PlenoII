using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Infra.Data.Migrations
{
    public partial class AddInstEnsino_Livro_Emprestimo_Relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdInstituicaoEnsino",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InstituicaoEnsino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(18)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituicaoEnsino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Genero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sinopse = table.Column<string>(type: "varchar(200)", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdLivro = table.Column<int>(nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "Datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Livro_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdInstituicaoEnsino",
                table: "Usuario",
                column: "IdInstituicaoEnsino");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdLivro",
                table: "Emprestimo",
                column: "IdLivro");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdUsuario",
                table: "Emprestimo",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_InstituicaoEnsino_IdInstituicaoEnsino",
                table: "Usuario",
                column: "IdInstituicaoEnsino",
                principalTable: "InstituicaoEnsino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_InstituicaoEnsino_IdInstituicaoEnsino",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "InstituicaoEnsino");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdInstituicaoEnsino",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdInstituicaoEnsino",
                table: "Usuario");
        }
    }
}
