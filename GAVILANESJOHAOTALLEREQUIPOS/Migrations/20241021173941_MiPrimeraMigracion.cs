using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GAVILANESJOHAOTALLEREQUIPOS.Migrations
{
    /// <inheritdoc />
    public partial class MiPrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estadio",
                columns: table => new
                {
                    IdEstadio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadio", x => x.IdEstadio);
                });

            migrationBuilder.CreateTable(
                name: "Equipoligapro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titulos = table.Column<int>(type: "int", nullable: false),
                    AceptaExtranjeros = table.Column<bool>(type: "bit", nullable: false),
                    IdEstadio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipoligapro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipoligapro_Estadio_IdEstadio",
                        column: x => x.IdEstadio,
                        principalTable: "Estadio",
                        principalColumn: "IdEstadio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "int", maxLength: 70, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.IdJugador);
                    table.ForeignKey(
                        name: "FK_Jugador_Equipoligapro_IdEquipo",
                        column: x => x.IdEquipo,
                        principalTable: "Equipoligapro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipoligapro_IdEstadio",
                table: "Equipoligapro",
                column: "IdEstadio");

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_IdEquipo",
                table: "Jugador",
                column: "IdEquipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Equipoligapro");

            migrationBuilder.DropTable(
                name: "Estadio");
        }
    }
}
