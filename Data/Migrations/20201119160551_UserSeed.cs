using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "1982dec8-8fb3-46b1-a311-a01e8027a4d5", 0, "eaee4803-78d4-4b43-b6ad-fe7248322eda", "abrar@jahin.com", true, null, null, false, null, "ABRAR@JAHIN.COM", "ABRAR", "AQAAAAEAACcQAAAAELcE9myuLUQzVqv6RTn7xBKAoDeBh/JEZHYA2h+tNVkCLQ1ZpxcopVkNeox8z+mlzA==", null, false, null, "34e9724f-becf-4758-820b-15fc18dae8a6", false, "abrar", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "1982dec8-8fb3-46b1-a311-a01e8027a4d5");
        }
    }
}
