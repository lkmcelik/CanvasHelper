using Microsoft.EntityFrameworkCore.Migrations;

namespace CanvasHelperServerApp.Migrations
{
    public partial class CreateDefaultAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Users (FirstName,Password,UserType) values('admin','admin','teacher') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
