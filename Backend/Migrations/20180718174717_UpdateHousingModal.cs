using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class UpdateHousingModal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Housing",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NumberOfBathroom",
                table: "Housing",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBedroom",
                table: "Housing",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Housing",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Housing");

            migrationBuilder.DropColumn(
                name: "NumberOfBathroom",
                table: "Housing");

            migrationBuilder.DropColumn(
                name: "NumberOfBedroom",
                table: "Housing");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Housing");
        }
    }
}
