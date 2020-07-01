using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiraData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    ValorBruto = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PercDescAVista = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    VlDescAVista = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    VlAVista = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Linha = table.Column<int>(nullable: true),
                    Categoria = table.Column<int>(nullable: true),
                    NCM = table.Column<string>(type: "varchar(50)", nullable: true),
                    TipoICMS = table.Column<int>(nullable: true),
                    CFOPICMS = table.Column<int>(nullable: true),
                    Origem = table.Column<int>(nullable: true),
                    CSTICMS = table.Column<int>(nullable: true),
                    AliquotaICMS = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    CSTPisCofins = table.Column<int>(nullable: true),
                    AliquotaPis = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    AliquotaCofins = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    DataHoraUltimaAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEan",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    EAN = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEan", x => new { x.ProdutoId, x.EAN });
                    table.ForeignKey(
                        name: "FK_ProdutoEan_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEstoque",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    TipoMedida = table.Column<int>(nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEstoque", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_ProdutoEstoque_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoImagem",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    Imagem = table.Column<byte[]>(nullable: true),
                    LinkImagem = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoImagem", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_ProdutoImagem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_TipoProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoProduto_ProdutoId",
                table: "TipoProduto",
                column: "ProdutoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoEan");

            migrationBuilder.DropTable(
                name: "ProdutoEstoque");

            migrationBuilder.DropTable(
                name: "ProdutoImagem");

            migrationBuilder.DropTable(
                name: "TipoProduto");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
