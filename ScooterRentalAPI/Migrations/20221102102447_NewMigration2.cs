using Microsoft.EntityFrameworkCore.Migrations;

namespace ScooterRentalAPI.Migrations
{
    public partial class NewMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "RentedScooters",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ScooterId",
                table: "RentedScooters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScooterId",
                table: "RentedScooters");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RentedScooters",
                newName: "ID");
        }
    }
}
