using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcoX9.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    TELEFONE = table.Column<string>(nullable: true),
                    SENHA = table.Column<string>(nullable: true),
                    FLAG_SIT = table.Column<string>(nullable: true),
                    FLAG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ocorrencias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COD_OCO = table.Column<string>(nullable: true),
                    DESC_OCO = table.Column<string>(nullable: true),
                    DT_OCO = table.Column<DateTime>(nullable: false),
                    FOTO = table.Column<string>(nullable: true),
                    FLAG_SIT = table.Column<string>(nullable: true),
                    FLAG = table.Column<string>(nullable: true),
                    UsuariosId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ocorrencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_ocorrencias_tb_usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "tb_usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ocorrencias_UsuariosId",
                table: "tb_ocorrencias",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ocorrencias");

            migrationBuilder.DropTable(
                name: "tb_usuarios");
        }
    }
}
