using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzureChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class User_AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "William", "Admin", "AQAAAAIAAYagAAAAEK1pjSAIwwEkcqnw/47qz6B95CU8T7OGHz8ZV8EE6LXpfhm2PiNPOzFp14T0sEMBKw==" },
                    { 2, "manager@example.com", "William", "Manager", "AQAAAAIAAYagAAAAEFsAmJP1WnMFr8WJupBSlRyKY7jYPjYZV9hul6AlGnFI0V4MPFaf9ZsklXqcAVNGUw==" },
                    { 3, "employee@example.com", "William", "Employee", "AQAAAAIAAYagAAAAELfkk8KwldGfgS4vbA/NhHE6ExgW2P5l1EFbY+iQXkk+rVnoYuLVpQ6xyeiS7HN51A==" }
                });

            migrationBuilder.InsertData(
                table: "User_Role",
                columns: new[] { "RolesId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumns: new[] { "RolesId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumns: new[] { "RolesId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumns: new[] { "RolesId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "User_Role",
                keyColumns: new[] { "RolesId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
