using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class cambio_entidad_lista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppListas_AbpUsers_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropIndex(
                name: "IX_AppListas_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropColumn(
                name: "UrlImagen",
                table: "AppNoticias");

            migrationBuilder.DropColumn(
                name: "Visto",
                table: "AppNoticias");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "AppListas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagen",
                table: "AppNoticias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Visto",
                table: "AppNoticias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "AppListas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppListas_UsuarioId",
                table: "AppListas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppListas_AbpUsers_UsuarioId",
                table: "AppListas",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
