using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS_BACKEND_MAIN.Migrations
{
    /// <inheritdoc />
    public partial class lmao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemRole",
                keyColumn: "Id",
                keyValue: "355f5fcf-92f6-4ef8-b7c6-28aab481da76");

            migrationBuilder.DeleteData(
                table: "SystemRole",
                keyColumn: "Id",
                keyValue: "97f0f3bd-394b-462e-b7b0-0018b129a9db");

            migrationBuilder.DeleteData(
                table: "SystemRole",
                keyColumn: "Id",
                keyValue: "b2ab0e08-6661-4deb-a531-6241b02e1170");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "SystemRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11acfb83-e13f-4460-bd49-19c86228b17b", null, "Teacher", "SUPERVISOR" },
                    { "3e1770f4-e15e-4147-9d98-54faae40d9d5", null, "Student", "STUDENT" },
                    { "e4de5e8c-56bc-40ed-90a1-6b2d57d2e1aa", null, "LabLead", "LABADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemRole",
                keyColumn: "Id",
                keyValue: "11acfb83-e13f-4460-bd49-19c86228b17b");

            migrationBuilder.DeleteData(
                table: "SystemRole",
                keyColumn: "Id",
                keyValue: "3e1770f4-e15e-4147-9d98-54faae40d9d5");

            migrationBuilder.DeleteData(
                table: "SystemRole",
                keyColumn: "Id",
                keyValue: "e4de5e8c-56bc-40ed-90a1-6b2d57d2e1aa");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Account");

            migrationBuilder.InsertData(
                table: "SystemRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "355f5fcf-92f6-4ef8-b7c6-28aab481da76", null, "Teacher", "SUPERVISOR" },
                    { "97f0f3bd-394b-462e-b7b0-0018b129a9db", null, "Student", "STUDENT" },
                    { "b2ab0e08-6661-4deb-a531-6241b02e1170", null, "LabLead", "LABADMIN" }
                });
        }
    }
}
