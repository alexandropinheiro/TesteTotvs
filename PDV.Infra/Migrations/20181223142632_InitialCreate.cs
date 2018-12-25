using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PDV.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DescricaoValor = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    ValorMonetario = table.Column<decimal>(nullable: false),
                    TipoValor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    ValorRecebido = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trocos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdVenda = table.Column<Guid>(nullable: false),
                    IdValor = table.Column<Guid>(nullable: false),
                    QuantidadeValor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trocos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trocos_Valores_IdValor",
                        column: x => x.IdValor,
                        principalTable: "Valores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trocos_Vendas_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trocos_IdValor",
                table: "Trocos",
                column: "IdValor");

            migrationBuilder.CreateIndex(
                name: "IX_Trocos_IdVenda",
                table: "Trocos",
                column: "IdVenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trocos");

            migrationBuilder.DropTable(
                name: "Valores");

            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
