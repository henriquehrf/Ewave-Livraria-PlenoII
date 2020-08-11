using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Infra.Data.Migrations
{
    public partial class AdicionadoColunaDataPrevistaDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrevistaDevolucao",
                table: "Emprestimo",
                type: "Datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPrevistaDevolucao",
                table: "Emprestimo");
        }
    }
}
