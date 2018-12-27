using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PDV.Infra.Migrations
{
    public partial class Initial : Migration
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

            migrationBuilder.InsertData(
                table: "Valores",
                columns: new[] { "Id", "DescricaoValor", "TipoValor", "ValorMonetario" },
                values: new object[,]
                {
                    { new Guid("3ec29908-ac3d-4355-b2b8-fca39af8a1d4"), "R$100,00", 1, 100m },
                    { new Guid("bfdcfe55-ced4-44c8-8f81-3f662ee403b2"), "R$50,00", 1, 50m },
                    { new Guid("83c50805-a8c4-470b-af8a-5afb2eb6e955"), "R$20,00", 1, 20m },
                    { new Guid("ba2bd123-70c3-4bb1-a5f6-f4f25437b47a"), "R$10,00", 1, 10m },
                    { new Guid("1ef801ee-b2e0-489c-82b3-78a48ef266d3"), "R$0,50", 0, 0.5m },
                    { new Guid("bac10056-b884-4d95-aa68-e6797794c6d2"), "R$0,10", 0, 0.1m },
                    { new Guid("8894a636-4ba3-4476-8224-a1da4a69a4e8"), "R$0,05", 0, 0.05m },
                    { new Guid("aa9d62aa-9fe4-4a45-b223-7da7447ed377"), "R$0,01", 0, 0.01m }
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
