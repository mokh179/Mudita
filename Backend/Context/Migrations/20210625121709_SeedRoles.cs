using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Context.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Discriminator", "Description", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "IdentityRole", "Regular User", "User", "User".ToUpper(), Guid.NewGuid().ToString() }
                );
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Discriminator", "Description","Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "IdentityRole", "Admin Can Do Any Thing in site", "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [AspNetRoles]");
        }
    }
}
