using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroPessoa.Migrations
{
    public partial class InserindoTipoTabelaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoTipo",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoTipo",
                table: "Enderecos");
        }
    }
}
