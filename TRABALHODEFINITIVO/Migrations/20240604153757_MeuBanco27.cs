using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRABALHODEFINITIVO.Migrations
{
    /// <inheritdoc />
    public partial class MeuBanco27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    AtorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.AtorId);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    MensagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.MensagemId);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdquirida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorCusto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diretor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoCapa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.FilmeId);
                    table.ForeignKey(
                        name: "FK_Filme_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmeAtores",
                columns: table => new
                {
                    FilmeAtoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    AtorId = table.Column<int>(type: "int", nullable: false),
                    Personagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeAtores", x => x.FilmeAtoresId);
                    table.ForeignKey(
                        name: "FK_FilmeAtores_Artista_AtorId",
                        column: x => x.AtorId,
                        principalTable: "Artista",
                        principalColumn: "AtorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeAtores_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "FilmeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filme_GeneroId",
                table: "Filme",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeAtores_AtorId",
                table: "FilmeAtores",
                column: "AtorId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeAtores_FilmeId",
                table: "FilmeAtores",
                column: "FilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeAtores");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Artista");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
