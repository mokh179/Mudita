using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class appliedvacStutus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobTypeVacancies_Vacancy_Vacancy_Id",
                table: "jobTypeVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_KeySkillsVacancies_Vacancy_VacancyVacancy_Id",
                table: "KeySkillsVacancies");

            migrationBuilder.AlterColumn<int>(
                name: "VacancyVacancy_Id",
                table: "KeySkillsVacancies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Vacancy_Id",
                table: "jobTypeVacancies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AppliedVacancy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_jobTypeVacancies_Vacancy_Vacancy_Id",
                table: "jobTypeVacancies",
                column: "Vacancy_Id",
                principalTable: "Vacancy",
                principalColumn: "Vacancy_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KeySkillsVacancies_Vacancy_VacancyVacancy_Id",
                table: "KeySkillsVacancies",
                column: "VacancyVacancy_Id",
                principalTable: "Vacancy",
                principalColumn: "Vacancy_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobTypeVacancies_Vacancy_Vacancy_Id",
                table: "jobTypeVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_KeySkillsVacancies_Vacancy_VacancyVacancy_Id",
                table: "KeySkillsVacancies");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AppliedVacancy");

            migrationBuilder.AlterColumn<int>(
                name: "VacancyVacancy_Id",
                table: "KeySkillsVacancies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Vacancy_Id",
                table: "jobTypeVacancies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_jobTypeVacancies_Vacancy_Vacancy_Id",
                table: "jobTypeVacancies",
                column: "Vacancy_Id",
                principalTable: "Vacancy",
                principalColumn: "Vacancy_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KeySkillsVacancies_Vacancy_VacancyVacancy_Id",
                table: "KeySkillsVacancies",
                column: "VacancyVacancy_Id",
                principalTable: "Vacancy",
                principalColumn: "Vacancy_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
