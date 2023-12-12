using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class eliminamos_entidades_inutiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAlertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    Etiquetas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAlertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAlertas_AbpUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Etiquetas = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "AppNoticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visto = table.Column<bool>(type: "bit", nullable: false),
                    ListaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNoticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNoticias_AppListas_ListaId",
                        column: x => x.ListaId,
                        principalTable: "AppListas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAlertas_UsuarioId",
                table: "AppAlertas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AppListas_ListaId",
                table: "AppListas",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNoticias_ListaId",
                table: "AppNoticias",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNotificaciones_AlertaId",
                table: "AppNotificaciones",
                column: "AlertaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppNoticias");

            migrationBuilder.DropTable(
                name: "AppNotificaciones");

            migrationBuilder.DropTable(
                name: "AppListas");

            migrationBuilder.DropTable(
                name: "AppAlertas");
        }
    }
}
