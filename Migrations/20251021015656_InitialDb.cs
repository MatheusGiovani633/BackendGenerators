using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendGenerators.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Cod_Medico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    CRM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Cod_Medico);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrdemServicoCaixa",
                columns: table => new
                {
                    Cod_OrdemServicocaixa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cod_Classificacao = table.Column<int>(type: "int", nullable: false),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    Cod_Usuario = table.Column<int>(type: "int", nullable: false),
                    Cod_Vendedor = table.Column<int>(type: "int", nullable: false),
                    Cod_Receita = table.Column<int>(type: "int", nullable: false),
                    Cod_Transacao = table.Column<int>(type: "int", nullable: false),
                    NumeroOrdemServico = table.Column<int>(type: "int", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataPrevisao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataPrevisaoFornecedor = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cod_Laboratorio = table.Column<int>(type: "int", nullable: false),
                    Cod_lenteOD = table.Column<int>(type: "int", nullable: false),
                    Cod_lenteOE = table.Column<int>(type: "int", nullable: false),
                    Cod_armacao = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<double>(type: "double", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false),
                    Cod_Servico = table.Column<int>(type: "int", nullable: false),
                    QuantidadeServico = table.Column<int>(type: "int", nullable: false),
                    ValorDesconto = table.Column<double>(type: "double", nullable: false),
                    ValorAcrescimo = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicoCaixa", x => x.Cod_OrdemServicocaixa);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Identificador = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Razaosocial = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celular = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celular2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cpf = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sexo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cep = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InscricaoEstadual = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InscricaoMunicipal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoCNPJ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Cod_Pessoa);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Cod_Receita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cod_Pessoa = table.Column<int>(type: "int", nullable: false),
                    Cod_OrdemServicocaixa = table.Column<int>(type: "int", nullable: false),
                    Cod_Vendedor = table.Column<int>(type: "int", nullable: false),
                    Cod_Medico = table.Column<int>(type: "int", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataPrescricao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAviamento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LenteOD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LenteOE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    esfericoOD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    esfericoOE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    cilindricoOD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    cilindricoOE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    eixoOD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    eixoOE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AdicaoOD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AdicaoOE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DNPOD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DNPOE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    COOD = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    COOE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Cod_Receita);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "OrdemServicoCaixa");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
