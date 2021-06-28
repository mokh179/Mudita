using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Context.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Cat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Cat_Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "int", nullable: false),
                    Sort_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeySkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeySkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typeOfEducations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeOfEducations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    JobCat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCat_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.JobCat_Id);
                    table.ForeignKey(
                        name: "FK_JobCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Cat_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    City_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.City_Id);
                    table.ForeignKey(
                        name: "FK_City_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Ques_Id = table.Column<int>(type: "int", nullable: false),
                    Ques_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobCat_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Ques_Id);
                    table.ForeignKey(
                        name: "FK_Questions_JobCategory_JobCat_Id",
                        column: x => x.JobCat_Id,
                        principalTable: "JobCategory",
                        principalColumn: "JobCat_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    Vacancy_Id = table.Column<int>(type: "int", nullable: false),
                    Vacancy_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCat_Id = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.Vacancy_Id);
                    table.ForeignKey(
                        name: "FK_Vacancy_JobCategory_JobCat_Id",
                        column: x => x.JobCat_Id,
                        principalTable: "JobCategory",
                        principalColumn: "JobCat_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<int>(type: "int", nullable: true),
                    Country_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_City_City_Id",
                        column: x => x.City_Id,
                        principalTable: "City",
                        principalColumn: "City_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_JobCategory_title",
                        column: x => x.title,
                        principalTable: "JobCategory",
                        principalColumn: "JobCat_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "jobTypeVacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    Vacancy_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobTypeVacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobTypeVacancies_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jobTypeVacancies_Vacancy_Vacancy_Id",
                        column: x => x.Vacancy_Id,
                        principalTable: "Vacancy",
                        principalColumn: "Vacancy_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeySkillsVacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeySkillId = table.Column<int>(type: "int", nullable: false),
                    VacancyVacancy_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeySkillsVacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeySkillsVacancies_KeySkills_KeySkillId",
                        column: x => x.KeySkillId,
                        principalTable: "KeySkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeySkillsVacancies_Vacancy_VacancyVacancy_Id",
                        column: x => x.VacancyVacancy_Id,
                        principalTable: "Vacancy",
                        principalColumn: "Vacancy_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Manager_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Company_Id);
                    table.ForeignKey(
                        name: "FK_Company_AspNetUsers_Manager_Id",
                        column: x => x.Manager_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Cat_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Onlineprofiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onlineprofiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Onlineprofiles_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Like = table.Column<bool>(type: "bit", nullable: false),
                    Dislike = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reactions_Questions_qId",
                        column: x => x.qId,
                        principalTable: "Questions",
                        principalColumn: "Ques_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    Role_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.Role_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetRoles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQues",
                columns: table => new
                {
                    Ques_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userQues_Id = table.Column<int>(type: "int", nullable: false),
                    NumOfVote = table.Column<int>(type: "int", nullable: false),
                    Reports = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQues", x => new { x.Ques_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_UserQues_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserQues_Questions_Ques_Id",
                        column: x => x.Ques_Id,
                        principalTable: "Questions",
                        principalColumn: "Ques_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    skillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserSkills_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSkills_KeySkills_skillID",
                        column: x => x.skillID,
                        principalTable: "KeySkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppliedVacancy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    Vacancy_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    withDraw = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedVacancy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppliedVacancy_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppliedVacancy_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppliedVacancy_Statuses_status",
                        column: x => x.status,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppliedVacancy_Vacancy_Vacancy_Id",
                        column: x => x.Vacancy_Id,
                        principalTable: "Vacancy",
                        principalColumn: "Vacancy_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CompanyVacany",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    Vacancy_Id = table.Column<int>(type: "int", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyVacany", x => new { x.Company_Id, x.Vacancy_Id });
                    table.ForeignKey(
                        name: "FK_CompanyVacany_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyVacany_Vacancy_Vacancy_Id",
                        column: x => x.Vacancy_Id,
                        principalTable: "Vacancy",
                        principalColumn: "Vacancy_Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Rate_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalRate = table.Column<double>(type: "float", nullable: false),
                    WorkEnvironmentRate = table.Column<double>(type: "float", nullable: false),
                    ServiceRate = table.Column<double>(type: "float", nullable: false),
                    SafetyRate = table.Column<double>(type: "float", nullable: false),
                    OverAllRate = table.Column<double>(type: "float", nullable: false),
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Rate_Id);
                    table.ForeignKey(
                        name: "FK_Rating_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompany",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    title = table.Column<int>(type: "int", nullable: false),
                    from = table.Column<DateTime>(type: "datetime2", nullable: false),
                    to = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StillWorking = table.Column<bool>(type: "bit", nullable: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCompany_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCompany_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompany_JobCategory_title",
                        column: x => x.title,
                        principalTable: "JobCategory",
                        principalColumn: "JobCat_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "userEducations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    companyID = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userEducations", x => x.id);
                    table.ForeignKey(
                        name: "FK_userEducations_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userEducations_Company_companyID",
                        column: x => x.companyID,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userEducations_typeOfEducations_type",
                        column: x => x.type,
                        principalTable: "typeOfEducations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppliedVacancy_Company_Id",
                table: "AppliedVacancy",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedVacancy_status",
                table: "AppliedVacancy",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedVacancy_User_Id",
                table: "AppliedVacancy",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedVacancy_Vacancy_Id",
                table: "AppliedVacancy",
                column: "Vacancy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_City_Id",
                table: "AspNetUsers",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Country_Id",
                table: "AspNetUsers",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_title",
                table: "AspNetUsers",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_Country_Id",
                table: "City",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Category_Id",
                table: "Company",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Manager_Id",
                table: "Company",
                column: "Manager_Id",
                unique: true,
                filter: "[Manager_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyVacany_Vacancy_Id",
                table: "CompanyVacany",
                column: "Vacancy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_CategoryID",
                table: "JobCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_jobTypeVacancies_JobTypeId",
                table: "jobTypeVacancies",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_jobTypeVacancies_Vacancy_Id",
                table: "jobTypeVacancies",
                column: "Vacancy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KeySkillsVacancies_KeySkillId",
                table: "KeySkillsVacancies",
                column: "KeySkillId");

            migrationBuilder.CreateIndex(
                name: "IX_KeySkillsVacancies_VacancyVacancy_Id",
                table: "KeySkillsVacancies",
                column: "VacancyVacancy_Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Onlineprofiles_userID",
                table: "Onlineprofiles",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_JobCat_Id",
                table: "Questions",
                column: "JobCat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_Company_Id",
                table: "Rating",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_User_Id",
                table: "Rating",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_qId",
                table: "Reactions",
                column: "qId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_userId",
                table: "Reactions",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_User_Id",
                table: "RoleUser",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_Company_Id",
                table: "UserCompany",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_title",
                table: "UserCompany",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_User_Id",
                table: "UserCompany",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_userEducations_companyID",
                table: "userEducations",
                column: "companyID");

            migrationBuilder.CreateIndex(
                name: "IX_userEducations_type",
                table: "userEducations",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_userEducations_userID",
                table: "userEducations",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_UserQues_User_Id",
                table: "UserQues",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_skillID",
                table: "UserSkills",
                column: "skillID");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_userId",
                table: "UserSkills",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_JobCat_Id",
                table: "Vacancy",
                column: "JobCat_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedVacancy");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompanyVacany");

            migrationBuilder.DropTable(
                name: "jobTypeVacancies");

            migrationBuilder.DropTable(
                name: "KeySkillsVacancies");

            migrationBuilder.DropTable(
                name: "Locationcompanies");

            migrationBuilder.DropTable(
                name: "Onlineprofiles");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "UserCompany");

            migrationBuilder.DropTable(
                name: "userEducations");

            migrationBuilder.DropTable(
                name: "UserQues");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Vacancy");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "typeOfEducations");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "KeySkills");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
