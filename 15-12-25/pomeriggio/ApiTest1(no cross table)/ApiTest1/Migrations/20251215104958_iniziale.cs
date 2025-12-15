using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class iniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Docenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eta = table.Column<int>(type: "int", nullable: false),
                    Matricola = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
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
                name: "IX_CorsoDocente_corsiId",
                table: "CorsoDocente",
                column: "corsiId");

            migrationBuilder.CreateIndex(
                name: "IX_CorsoStudente_studentiId",
                table: "CorsoStudente",
                column: "studentiId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_Matricola",
                table: "Studenti",
                column: "Matricola",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorsoDocente");

            migrationBuilder.DropTable(
                name: "CorsoStudente");

            migrationBuilder.DropTable(
                name: "Docenti");

            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
