using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItlaTV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Productora",
                columns: table => new
                {
                    ProductoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productora", x => x.ProductoraId);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoraId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    SGeneroId = table.Column<int>(type: "int", nullable: false),
                    Enlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SGeneroGeneroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SerieId);
                    table.ForeignKey(
                        name: "FK_Series_Generos_SGeneroGeneroId",
                        column: x => x.SGeneroGeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId");
                    table.ForeignKey(
                        name: "FK_Series_Generos_SGeneroId",
                        column: x => x.SGeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Productora_ProductoraId",
                        column: x => x.ProductoraId,
                        principalTable: "Productora",
                        principalColumn: "ProductoraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_ProductoraId",
                table: "Series",
                column: "ProductoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_SGeneroGeneroId",
                table: "Series",
                column: "SGeneroGeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_SGeneroId",
                table: "Series",
                column: "SGeneroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Productora");
        }
    }
}
