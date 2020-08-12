using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Infra.Data.Migrations
{
    public partial class AdicionadoColunaPerfilDoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfilUsuario",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerfilUsuario",
                table: "Usuario");
        }
    }
}
