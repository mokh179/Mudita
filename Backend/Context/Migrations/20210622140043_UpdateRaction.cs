using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class UpdateRaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "state",
                table: "Reactions",
                newName: "Like");

            migrationBuilder.AddColumn<bool>(
                name: "Dislike",
                table: "Reactions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "Reactions");

            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Reactions",
                newName: "state");
        }
    }
}
