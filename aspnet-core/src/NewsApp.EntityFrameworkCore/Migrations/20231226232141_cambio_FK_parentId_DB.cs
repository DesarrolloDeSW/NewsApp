using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class cambio_FK_parentId_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppListas_AppListas_ListaId",
                table: "AppListas");

            migrationBuilder.DropIndex(
                name: "IX_AppListas_ListaId",
                table: "AppListas");

            migrationBuilder.DropColumn(
                name: "ListaId",
                table: "AppListas");

            migrationBuilder.CreateIndex(
                name: "IX_AppListas_ParentId",
                table: "AppListas",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppListas_AppListas_ParentId",
                table: "AppListas",
                column: "ParentId",
                principalTable: "AppListas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppListas_AppListas_ParentId",
                table: "AppListas");

            migrationBuilder.DropIndex(
                name: "IX_AppListas_ParentId",
                table: "AppListas");

            migrationBuilder.AddColumn<int>(
                name: "ListaId",
                table: "AppListas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppListas_ListaId",
                table: "AppListas",
                column: "ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppListas_AppListas_ListaId",
                table: "AppListas",
                column: "ListaId",
                principalTable: "AppListas",
                principalColumn: "Id");
        }
    }
}
