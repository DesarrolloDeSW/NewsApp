using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class crear_lista_y_etiqueta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaId",
                table: "AppNoticias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppListas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alerta = table.Column<bool>(type: "bit", nullable: false),
                    ListaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppListas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppListas_AppListas_ListaId",
                        column: x => x.ListaId,
                        principalTable: "AppListas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppEtiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadenaClave = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ListaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppEtiquetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppEtiquetas_AppListas_ListaId",
                        column: x => x.ListaId,
                        principalTable: "AppListas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNoticias_ListaId",
                table: "AppNoticias",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppEtiquetas_ListaId",
                table: "AppEtiquetas",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppListas_ListaId",
                table: "AppListas",
                column: "ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNoticias_AppListas_ListaId",
                table: "AppNoticias",
                column: "ListaId",
                principalTable: "AppListas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppNoticias_AppListas_ListaId",
                table: "AppNoticias");

            migrationBuilder.DropTable(
                name: "AppEtiquetas");

            migrationBuilder.DropTable(
                name: "AppListas");

            migrationBuilder.DropIndex(
                name: "IX_AppNoticias_ListaId",
                table: "AppNoticias");

            migrationBuilder.DropColumn(
                name: "ListaId",
                table: "AppNoticias");
        }
    }
}
