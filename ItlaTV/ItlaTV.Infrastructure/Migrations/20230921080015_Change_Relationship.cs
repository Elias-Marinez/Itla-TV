using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItlaTV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Generos_SGeneroGeneroId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_SGeneroGeneroId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "SGeneroGeneroId",
                table: "Series");

            migrationBuilder.CreateIndex(
                name: "IX_Series_GeneroId",
                table: "Series",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Generos_GeneroId",
                table: "Series",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Generos_GeneroId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_GeneroId",
                table: "Series");

            migrationBuilder.AddColumn<int>(
                name: "SGeneroGeneroId",
                table: "Series",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_SGeneroGeneroId",
                table: "Series",
                column: "SGeneroGeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Generos_SGeneroGeneroId",
                table: "Series",
                column: "SGeneroGeneroId",
                principalTable: "Generos",
                principalColumn: "GeneroId");
        }
    }
}
