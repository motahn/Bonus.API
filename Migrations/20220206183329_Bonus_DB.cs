using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bonus.API.Migrations
{
    public partial class Bonus_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIOS",
                columns: table => new
                {
                    ID_FUNCIONARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NU_MATRICULA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TX_NOME_COMPLETO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TX_AREA_ATUACAO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TX_CARGO = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NU_SALARIO_BRUTO = table.Column<double>(type: "float", nullable: false),
                    DT_ADMISSAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIOS", x => x.ID_FUNCIONARIO);
                });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIOS",
                columns: new[] { "ID_FUNCIONARIO", "TX_AREA_ATUACAO", "TX_CARGO", "NU_MATRICULA", "DT_ADMISSAO", "TX_NOME_COMPLETO", "NU_SALARIO_BRUTO" },
                values: new object[,]
                {
                    { 1, "Diretoria", "Funcionário", "123", new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gordon Gekko", 9000.0 },
                    { 2, "Diretoria", "Funcionário", "456", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bud Fox", 8000.0 },
                    { 3, "Relacionamento com cliente", "Funcionário", "886", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darien Taylor", 7000.0 },
                    { 4, "Contabilidade", "Estagiário", "658", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kate Gekko", 2000.0 },
                    { 5, "Financeiro", "Funcionário", "358", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carl Fox", 5000.0 },
                    { 6, "Tecnologia", "Estagiário", "873", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roger Bames", 1000.0 },
                    { 7, "Serviços gerais", "Funcionário", "325", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candice Rogers", 2000.0 },
                    { 8, "Tecnologia", "Funcionário", "863", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stone Livingston", 4000.0 },
                    { 9, "Financeiro", "Funcionário", "286", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harold Salt", 5000.0 },
                    { 10, "Relacionamento com cliente", "Estagiário", "458", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rudy Gekko", 1000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIOS");
        }
    }
}
