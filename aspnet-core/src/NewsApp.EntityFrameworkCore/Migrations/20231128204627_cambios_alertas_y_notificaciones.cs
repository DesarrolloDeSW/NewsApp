using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class cambios_alertas_y_notificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNotificaciones_AppAlertas_AlertaId",
                table: "AppNotificaciones");

            migrationBuilder.DropIndex(
                name: "IX_AppNotificaciones_AlertaId",
                table: "AppNotificaciones");

            migrationBuilder.DropColumn(
                name: "AlertaId",
                table: "AppNotificaciones");

            migrationBuilder.RenameColumn(
                name: "Mensaje",
                table: "AppNotificaciones",
                newName: "CadenaBusqueda");

            migrationBuilder.AddColumn<bool>(
                name: "Leida",
                table: "AppNotificaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leida",
                table: "AppNotificaciones");

            migrationBuilder.RenameColumn(
                name: "CadenaBusqueda",
                table: "AppNotificaciones",
                newName: "Mensaje");

            migrationBuilder.AddColumn<int>(
                name: "AlertaId",
                table: "AppNotificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppNotificaciones_AlertaId",
                table: "AppNotificaciones",
                column: "AlertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNotificaciones_AppAlertas_AlertaId",
                table: "AppNotificaciones",
                column: "AlertaId",
                principalTable: "AppAlertas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
