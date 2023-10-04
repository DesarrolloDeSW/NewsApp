using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class crear_fuente_y_noticia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNoticias_Fuente_FuenteId",
                table: "AppNoticias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fuente",
                table: "Fuente");

            migrationBuilder.RenameTable(
                name: "Fuente",
                newName: "AppFuentes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFuentes",
                table: "AppFuentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNoticias_AppFuentes_FuenteId",
                table: "AppNoticias",
                column: "FuenteId",
                principalTable: "AppFuentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNoticias_AppFuentes_FuenteId",
                table: "AppNoticias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFuentes",
                table: "AppFuentes");

            migrationBuilder.RenameTable(
                name: "AppFuentes",
                newName: "Fuente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fuente",
                table: "Fuente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNoticias_Fuente_FuenteId",
                table: "AppNoticias",
                column: "FuenteId",
                principalTable: "Fuente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
