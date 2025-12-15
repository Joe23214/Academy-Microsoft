using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScuolaAPIServer.Migrations
{
    /// <inheritdoc />
    public partial class RelazioniStudenteCorsoProfessore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorsoProfessore");

            migrationBuilder.DropTable(
                name: "CorsoStudente");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_Matricola",
                table: "Studenti");

            migrationBuilder.CreateTable(
                name: "ProfessoreCorso",
                columns: table => new
                {
                    ProfessoreId = table.Column<int>(type: "int", nullable: false),
                    CorsoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoreCorso", x => new { x.ProfessoreId, x.CorsoId });
                    table.ForeignKey(
                        name: "FK_ProfessoreCorso_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessoreCorso_Professori_ProfessoreId",
                        column: x => x.ProfessoreId,
                        principalTable: "Professori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudenteCorso",
                columns: table => new
                {
                    StudenteId = table.Column<int>(type: "int", nullable: false),
                    CorsoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudenteCorso", x => new { x.StudenteId, x.CorsoId });
                    table.ForeignKey(
                        name: "FK_StudenteCorso_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudenteCorso_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoreCorso_CorsoId",
                table: "ProfessoreCorso",
                column: "CorsoId");

            migrationBuilder.CreateIndex(
                name: "IX_StudenteCorso_CorsoId",
                table: "StudenteCorso",
                column: "CorsoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessoreCorso");

            migrationBuilder.DropTable(
                name: "StudenteCorso");

            migrationBuilder.CreateTable(
                name: "CorsoProfessore",
                columns: table => new
                {
                    CorsiId = table.Column<int>(type: "int", nullable: false),
                    ProfessoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoProfessore", x => new { x.CorsiId, x.ProfessoriId });
                    table.ForeignKey(
                        name: "FK_CorsoProfessore_Corsi_CorsiId",
                        column: x => x.CorsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoProfessore_Professori_ProfessoriId",
                        column: x => x.ProfessoriId,
                        principalTable: "Professori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorsoStudente",
                columns: table => new
                {
                    CorsiId = table.Column<int>(type: "int", nullable: false),
                    StudentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorsoStudente", x => new { x.CorsiId, x.StudentiId });
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Corsi_CorsiId",
                        column: x => x.CorsiId,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorsoStudente_Studenti_StudentiId",
                        column: x => x.StudentiId,
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
                name: "IX_CorsoProfessore_ProfessoriId",
                table: "CorsoProfessore",
                column: "ProfessoriId");

            migrationBuilder.CreateIndex(
                name: "IX_CorsoStudente_StudentiId",
                table: "CorsoStudente",
                column: "StudentiId");
        }
    }
}
