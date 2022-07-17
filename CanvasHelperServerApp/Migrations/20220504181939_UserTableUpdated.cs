using Microsoft.EntityFrameworkCore.Migrations;

namespace CanvasHelperServerApp.Migrations
{
    public partial class UserTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "UsersCriteriaFeedbacks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Criteria",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCriteriaFeedbacks",
                table: "UsersCriteriaFeedbacks",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCriteriaFeedbacks",
                table: "UsersCriteriaFeedbacks");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "UsersCriteriaFeedbacks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Criteria");
        }
    }
}
