using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CanvasHelperServerApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentsTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentsTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteFeedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Mark = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFeedbacks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idRole = table.Column<int>(type: "INTEGER", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idCourse = table.Column<int>(type: "INTEGER", nullable: true),
                    idAssignmentType = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentsTypes_idAssignmentType",
                        column: x => x.idAssignmentType,
                        principalTable: "AssignmentsTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_idCourse",
                        column: x => x.idCourse,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idUser = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Mark = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersFavoriteFeedbacks",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "INTEGER", nullable: true),
                    idFavoriteFeedback = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UsersFavoriteFeedbacks_FavoriteFeedbacks_idFavoriteFeedback",
                        column: x => x.idFavoriteFeedback,
                        principalTable: "FavoriteFeedbacks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersFavoriteFeedbacks_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "INTEGER", nullable: true),
                    idRole = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_idRole",
                        column: x => x.idRole,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idAssignment = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MaxMark = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Criteria_Assignments_idAssignment",
                        column: x => x.idAssignment,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermissionsAssignments",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "INTEGER", nullable: true),
                    idPermission = table.Column<int>(type: "INTEGER", nullable: true),
                    idAssignment = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_RolesPermissionsAssignments_Assignments_idAssignment",
                        column: x => x.idAssignment,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesPermissionsAssignments_Permissions_idPermission",
                        column: x => x.idPermission,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesPermissionsAssignments_Roles_idRole",
                        column: x => x.idRole,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersCriteriaFeedbacks",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "INTEGER", nullable: true),
                    idCriteria = table.Column<int>(type: "INTEGER", nullable: true),
                    idFeedback = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UsersCriteriaFeedbacks_Criteria_idCriteria",
                        column: x => x.idCriteria,
                        principalTable: "Criteria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCriteriaFeedbacks_Feedbacks_idFeedback",
                        column: x => x.idFeedback,
                        principalTable: "Feedbacks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCriteriaFeedbacks_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_idAssignmentType",
                table: "Assignments",
                column: "idAssignmentType");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_idCourse",
                table: "Assignments",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_idAssignment",
                table: "Criteria",
                column: "idAssignment");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_idUser",
                table: "Feedbacks",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissionsAssignments_idAssignment",
                table: "RolesPermissionsAssignments",
                column: "idAssignment");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissionsAssignments_idPermission",
                table: "RolesPermissionsAssignments",
                column: "idPermission");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissionsAssignments_idRole",
                table: "RolesPermissionsAssignments",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCriteriaFeedbacks_idCriteria",
                table: "UsersCriteriaFeedbacks",
                column: "idCriteria");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCriteriaFeedbacks_idFeedback",
                table: "UsersCriteriaFeedbacks",
                column: "idFeedback");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCriteriaFeedbacks_idUser",
                table: "UsersCriteriaFeedbacks",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoriteFeedbacks_idFavoriteFeedback",
                table: "UsersFavoriteFeedbacks",
                column: "idFavoriteFeedback");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoriteFeedbacks_idUser",
                table: "UsersFavoriteFeedbacks",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_idRole",
                table: "UsersRoles",
                column: "idRole");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_idUser",
                table: "UsersRoles",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesPermissionsAssignments");

            migrationBuilder.DropTable(
                name: "UsersCriteriaFeedbacks");

            migrationBuilder.DropTable(
                name: "UsersFavoriteFeedbacks");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FavoriteFeedbacks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AssignmentsTypes");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
