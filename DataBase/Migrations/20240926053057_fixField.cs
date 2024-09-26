using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class fixField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_GenreId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenreId",
                table: "Patients",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_GenreId",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenreId",
                table: "Patients",
                column: "GenreId",
                unique: true);
        }
    }
}
