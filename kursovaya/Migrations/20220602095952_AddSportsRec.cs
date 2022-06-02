using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kursovaya.Migrations
{
    /// <inheritdoc />
    public partial class AddSportsRec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "distCore",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "distDisk",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "distHammer",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "distSpear",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "distCore",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "distDisk",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "distHammer",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "distSpear",
                table: "Players");
        }
    }
}
