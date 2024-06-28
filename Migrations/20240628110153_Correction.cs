using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightApi.Migrations
{
    /// <inheritdoc />
    public partial class Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Passengers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Passengers",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Passengers",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Passengers",
                newName: "email");
        }
    }
}
