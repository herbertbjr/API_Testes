using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTeste.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    QtdeParcelas = table.Column<int>(nullable: false),
                    VlrFinanciado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(nullable: false),
                    DtVencimento = table.Column<DateTime>(nullable: false),
                    DtPagamento = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestacao_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestacao_ContratoId",
                table: "Prestacao",
                column: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestacao");

            migrationBuilder.DropTable(
                name: "Contrato");
        }
    }
}
