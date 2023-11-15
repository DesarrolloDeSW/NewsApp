using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class cambios_varios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAlertas_AppUsuarios_UsuarioId",
                table: "AppAlertas");

            migrationBuilder.DropForeignKey(
                name: "FK_AppListas_AppUsuarios_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropForeignKey(
                name: "FK_AppNoticias_AppFuentes_FuenteId",
                table: "AppNoticias");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUltimasVisitas_AppNoticias_NoticiaId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUltimasVisitas_AppUsuarios_UsuarioId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropTable(
                name: "AppFuentes");

            migrationBuilder.DropTable(
                name: "AppUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_AppUltimasVisitas_NoticiaId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropIndex(
                name: "IX_AppNoticias_FuenteId",
                table: "AppNoticias");

            migrationBuilder.DropColumn(
                name: "NoticiaId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropColumn(
                name: "FuenteId",
                table: "AppNoticias");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "AppUltimasVisitas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UrlNoticia",
                table: "AppUltimasVisitas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fuente",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "AppListas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "AppIdiomas",
                type: "int",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "AppAlertas",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAlertas_AbpUsers_UsuarioId",
                table: "AppAlertas",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppListas_AbpUsers_UsuarioId",
                table: "AppListas",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUltimasVisitas_AbpUsers_UsuarioId",
                table: "AppUltimasVisitas",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAlertas_AbpUsers_UsuarioId",
                table: "AppAlertas");

            migrationBuilder.DropForeignKey(
                name: "FK_AppListas_AbpUsers_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUltimasVisitas_AbpUsers_UsuarioId",
                table: "AppUltimasVisitas");

            migrationBuilder.DropColumn(
                name: "UrlNoticia",
                table: "AppUltimasVisitas");

            migrationBuilder.DropColumn(
                name: "Fuente",
                table: "AppNoticias");

            migrationBuilder.DropColumn(
                name: "Visto",
                table: "AppNoticias");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "AppUltimasVisitas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "NoticiaId",
                table: "AppUltimasVisitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuenteId",
                table: "AppNoticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "AppListas",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "AppIdiomas",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "AppAlertas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "AppFuentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFuentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdiomaId = table.Column<int>(type: "int", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsuarios_AppIdiomas_IdiomaId",
                        column: x => x.IdiomaId,
                        principalTable: "AppIdiomas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUsuarios_AppPaises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "AppPaises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUltimasVisitas_NoticiaId",
                table: "AppUltimasVisitas",
                column: "NoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNoticias_FuenteId",
                table: "AppNoticias",
                column: "FuenteId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsuarios_IdiomaId",
                table: "AppUsuarios",
                column: "IdiomaId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsuarios_PaisId",
                table: "AppUsuarios",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAlertas_AppUsuarios_UsuarioId",
                table: "AppAlertas",
                column: "UsuarioId",
                principalTable: "AppUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppListas_AppUsuarios_UsuarioId",
                table: "AppListas",
                column: "UsuarioId",
                principalTable: "AppUsuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppNoticias_AppFuentes_FuenteId",
                table: "AppNoticias",
                column: "FuenteId",
                principalTable: "AppFuentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
