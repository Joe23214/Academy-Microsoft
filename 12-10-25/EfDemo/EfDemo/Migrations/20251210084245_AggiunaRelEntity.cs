using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Migrations
{
    /// <inheritdoc />
    public partial class AggiunaRelEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCorso",
                table: "Studenti");

            migrationBuilder.AlterColumn<string>(
                name: "Matricola",
                table: "Studenti",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codiceCorso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorsoDocente",
                columns: table => new
                {
                    DocentiId = table.Column<int>(type: "int", nullable: false),
                    corsiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoDocente", x => new { x.DocentiId, x.corsiId });
                    table.ForeignKey(
                        name: "FK_CorsoDocente_Corsi_corsiId",
                        column: x => x.corsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoDocente_Docenti_DocentiId",
                        column: x => x.DocentiId,
                        principalTable: "Docenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorsoStudente",
                columns: table => new
                {
                    CorsiId = table.Column<int>(type: "int", nullable: false),
                    studentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoStudente", x => new { x.CorsiId, x.studentiId });
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Corsi_CorsiId",
                        column: x => x.CorsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Studenti_studentiId",
                        column: x => x.studentiId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_Matricola",
                table: "Studenti",
                column: "Matricola",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorsoDocente_corsiId",
                table: "CorsoDocente",
                column: "corsiId");

            migrationBuilder.CreateIndex(
                name: "IX_CorsoStudente_studentiId",
                table: "CorsoStudente",
                column: "studentiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorsoDocente");

            migrationBuilder.DropTable(
                name: "CorsoStudente");

            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_Matricola",
                table: "Studenti");

            migrationBuilder.AlterColumn<string>(
                name: "Matricola",
                table: "Studenti",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "IdCorso",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
