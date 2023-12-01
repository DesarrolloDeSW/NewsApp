using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class cambio_acceso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoHTTP",
                table: "AppAccesosAPI");

            migrationBuilder.RenameColumn(
                name: "Error",
                table: "AppAccesosAPI",
                newName: "ErrorMessage");

            migrationBuilder.AddColumn<int>(
                name: "ErrorCode",
                table: "AppAccesosAPI",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorCode",
                table: "AppAccesosAPI");

            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                table: "AppAccesosAPI",
                newName: "Error");

            migrationBuilder.AddColumn<int>(
                name: "CodigoHTTP",
                table: "AppAccesosAPI",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
