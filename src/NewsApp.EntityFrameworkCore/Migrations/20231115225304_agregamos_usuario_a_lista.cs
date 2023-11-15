using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class agregamos_usuario_a_lista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "AppListas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppListas_AbpUsers_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropIndex(
                name: "IX_AppListas_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AppListas");
        }
    }
}
