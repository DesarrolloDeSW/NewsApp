using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.Migrations
{
    /// <inheritdoc />
    public partial class createusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "AppListas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppPaises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPaises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsuarios_AppPaises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "AppPaises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AppListas_UsuarioId",
                table: "AppListas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AppIdiomasPreferencia_UsuarioId",
                table: "AppIdiomasPreferencia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsuarios_PaisId",
                table: "AppUsuarios",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppListas_AppUsuarios_UsuarioId",
                table: "AppListas",
                column: "UsuarioId",
                principalTable: "AppUsuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppListas_AppUsuarios_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropTable(
                name: "AppIdiomasPreferencia");

            migrationBuilder.DropTable(
                name: "AppUsuarios");

            migrationBuilder.DropTable(
                name: "AppPaises");

            migrationBuilder.DropIndex(
                name: "IX_AppListas_UsuarioId",
                table: "AppListas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AppListas");
        }
    }
}
