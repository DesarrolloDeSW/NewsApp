using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class eliminaciónetiqueta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAlertas_AbpUsers_UsuarioId",
                table: "AppAlertas");

            migrationBuilder.DropIndex(
                name: "IX_AppAlertas_UsuarioId",
                table: "AppAlertas");

            migrationBuilder.DropColumn(
                name: "Etiquetas",
                table: "AppListas");

            migrationBuilder.RenameColumn(
                name: "Etiquetas",
                table: "AppAlertas",
                newName: "CadenaBusqueda");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "AppNotificaciones",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AppNotificaciones");

            migrationBuilder.RenameColumn(
                name: "CadenaBusqueda",
                table: "AppAlertas",
                newName: "Etiquetas");

            migrationBuilder.AddColumn<string>(
                name: "Etiquetas",
                table: "AppListas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppAlertas_UsuarioId",
                table: "AppAlertas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAlertas_AbpUsers_UsuarioId",
                table: "AppAlertas",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
