using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraData.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codProc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codCnj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descrFase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoReu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exibProc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descServ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeComarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeReu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalPersonagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagensResumidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagensResumidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonagensResumidos_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagensResumidos_ProcessoId",
                table: "PersonagensResumidos",
                column: "ProcessoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagensResumidos");

            migrationBuilder.DropTable(
                name: "Processos");
        }
    }
}
