using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Migrations
{
    /// <inheritdoc />
    public partial class AggiungiEta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCorso",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Matricola",
                table: "Studenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCorso",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "Matricola",
                table: "Studenti");
        }
    }
}
