using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class cambio_todas_entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppEtiquetas");

            migrationBuilder.DropTable(
                name: "AppIdiomasPreferencia");

            migrationBuilder.DropColumn(
                name: "Clave",
                table: "AppUsuarios");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "AppUltimasVisitas");

            migrationBuilder.DropColumn(
                name: "UrlNoticia",
                table: "AppUltimasVisitas");

            migrationBuilder.AddColumn<int>(
                name: "IdiomaId",
                table: "AppUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoticiaId",
                table: "AppUltimasVisitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "AppUltimasVisitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Etiquetas",
                table: "AppListas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppAlertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    Etiquetas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAlertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAlertas_AppUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AppUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppIdiomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppIdiomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNotificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNotificaciones_AppAlertas_AlertaId",
                        column: x => x.AlertaId,
                        principalTable: "AppAlertas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsuarios_IdiomaId",
                table: "AppUsuarios",
                column: "IdiomaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUltimasVisitas_NoticiaId",
                table: "AppUltimasVisitas",
                column: "NoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUltimasVisitas_UsuarioId",
                table: "AppUltimasVisitas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAlertas_UsuarioId",
                table: "AppAlertas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotificaciones_AlertaId",
                table: "AppNotificaciones",
                column: "AlertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUltimasVisitas_AppNoticias_NoticiaId",
                table: "AppUltimasVisitas",
                column: "NoticiaId",
                principalTable: "AppNoticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUltimasVisitas_AppUsuarios_UsuarioId",
                table: "AppUltimasVisitas",
                column: "UsuarioId",
                principalTable: "AppUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsuarios_AppIdiomas_IdiomaId",
                table: "AppUsuarios",
                column: "IdiomaId",
                principalTable: "AppIdiomas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUltimasVisitas_AppNoticias_NoticiaId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUltimasVisitas_AppUsuarios_UsuarioId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsuarios_AppIdiomas_IdiomaId",
                table: "AppUsuarios");

            migrationBuilder.DropTable(
                name: "AppIdiomas");

            migrationBuilder.DropTable(
                name: "AppNotificaciones");

            migrationBuilder.DropTable(
                name: "AppAlertas");

            migrationBuilder.DropIndex(
                name: "IX_AppUsuarios_IdiomaId",
                table: "AppUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_AppUltimasVisitas_NoticiaId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropIndex(
                name: "IX_AppUltimasVisitas_UsuarioId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropColumn(
                name: "IdiomaId",
                table: "AppUsuarios");

            migrationBuilder.DropColumn(
                name: "NoticiaId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropColumn(
                name: "Etiquetas",
                table: "AppListas");

            migrationBuilder.AddColumn<string>(
                name: "Clave",
                table: "AppUsuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "AppUltimasVisitas",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlNoticia",
                table: "AppUltimasVisitas",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateTable(
                name: "AppIdiomasPreferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idioma = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppIdiomasPreferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppIdiomasPreferencia_AppUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AppUsuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppEtiquetas_ListaId",
                table: "AppEtiquetas",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdiomasPreferencia_UsuarioId",
                table: "AppIdiomasPreferencia",
                column: "UsuarioId");
        }
    }
}
