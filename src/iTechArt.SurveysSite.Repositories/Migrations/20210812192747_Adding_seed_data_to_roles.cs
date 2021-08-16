using Microsoft.EntityFrameworkCore.Migrations;

namespace iTechArt.SurveysSite.Repositories.Migrations
{
    public partial class Adding_seed_data_to_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[] { 1, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[] { 2, "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
