using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfDemo.Migrations
{
    /// <inheritdoc />
    public partial class FixDocenteId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Docenti",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Docenti",
                newName: "ID");
        }
    }
}
