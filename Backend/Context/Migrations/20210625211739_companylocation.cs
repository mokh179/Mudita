using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class companylocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Locationcompanies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false),
                    cityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locationcompanies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locationcompanies_City_cityId",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "City_Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Locationcompanies_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locationcompanies_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_Company_Id",
                table: "UserCompany",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Locationcompanies_cityId",
                table: "Locationcompanies",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locationcompanies_companyId",
                table: "Locationcompanies",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Locationcompanies_countryId",
                table: "Locationcompanies",
                column: "countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_User_Id",
                table: "UserCompany",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_AspNetUsers_User_Id",
                table: "UserCompany");

            migrationBuilder.DropTable(
                name: "Locationcompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany");

            migrationBuilder.DropIndex(
                name: "IX_UserCompany_Company_Id",
                table: "UserCompany");

            migrationBuilder.AlterColumn<string>(
                name: "User_Id",
                table: "UserCompany",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "UserCompany",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany",
                columns: new[] { "Company_Id", "User_Id" });

            migrationBuilder.CreateTable(
                name: "CompanyLocations",
                columns: table => new
                {
                    companyId = table.Column<int>(type: "int", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: false),
                    cityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLocations", x => new { x.companyId, x.countryId, x.cityId });
                    table.ForeignKey(
                        name: "FK_CompanyLocations_City_cityId",
                        column: x => x.cityId,
                        principalTable: "City",
                        principalColumn: "City_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyLocations_Company_companyId",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyLocations_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLocations_cityId",
                table: "CompanyLocations",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLocations_countryId",
                table: "CompanyLocations",
                column: "countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_AspNetUsers_User_Id",
                table: "UserCompany",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
