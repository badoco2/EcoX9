using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoX9.Migrations
{
    public partial class tipos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CHAPA",
                table: "tb_usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "tb_usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BAIRRO",
                table: "tb_ocorrencias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DESC_INFRA",
                table: "tb_ocorrencias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ENDERECO",
                table: "tb_ocorrencias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PONTO_REF",
                table: "tb_ocorrencias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Tipo_OcorrenciaID",
                table: "tb_ocorrencias",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TiposId",
                table: "tb_ocorrencias",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Tipo_Ocorrencia",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME_TIPO = table.Column<string>(nullable: true),
                    DESC_TIPO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Ocorrencia", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ocorrencias_Tipo_OcorrenciaID",
                table: "tb_ocorrencias",
                column: "Tipo_OcorrenciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_ocorrencias_Tipo_Ocorrencia_Tipo_OcorrenciaID",
                table: "tb_ocorrencias",
                column: "Tipo_OcorrenciaID",
                principalTable: "Tipo_Ocorrencia",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_ocorrencias_Tipo_Ocorrencia_Tipo_OcorrenciaID",
                table: "tb_ocorrencias");

            migrationBuilder.DropTable(
                name: "Tipo_Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_tb_ocorrencias_Tipo_OcorrenciaID",
                table: "tb_ocorrencias");

            migrationBuilder.DropColumn(
                name: "CHAPA",
                table: "tb_usuarios");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "tb_usuarios");

            migrationBuilder.DropColumn(
                name: "BAIRRO",
                table: "tb_ocorrencias");

            migrationBuilder.DropColumn(
                name: "DESC_INFRA",
                table: "tb_ocorrencias");

            migrationBuilder.DropColumn(
                name: "ENDERECO",
                table: "tb_ocorrencias");

            migrationBuilder.DropColumn(
                name: "PONTO_REF",
                table: "tb_ocorrencias");

            migrationBuilder.DropColumn(
                name: "Tipo_OcorrenciaID",
                table: "tb_ocorrencias");

            migrationBuilder.DropColumn(
                name: "TiposId",
                table: "tb_ocorrencias");
        }
    }
}
