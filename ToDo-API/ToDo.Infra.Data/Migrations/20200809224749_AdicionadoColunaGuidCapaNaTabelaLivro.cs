using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Infra.Data.Migrations
{
    public partial class AdicionadoColunaGuidCapaNaTabelaLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuidCapa",
                table: "Livro",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuidCapa",
                table: "Livro");
        }
    }
}
