using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    public partial class UserRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa9b5ca6-b2e0-4559-bf8a-024e92e6162f", "9e39708e-3b6e-488e-b43e-c729232bf921", "SuperAdmin", null },
                    { "60abc5d7-1bdc-4204-aa2c-6ed7cc83ca40", "b8129bf8-8c9a-48dd-a41f-5bc6cadcb935", "Admin", null },
                    { "bf71c790-a12b-4f58-9fe4-511a893e32e5", "03455ed8-583f-43ae-93a3-ab046f3b3120", "Auditor", null },
                    { "b1f5d389-6de5-4275-896b-9a6652753257", "30a23c2f-ee0c-4622-8ce9-5086683fc7a0", "TeamMember", null },
                    { "237ab70d-8324-452a-bca2-75199ebfd78f", "c6cf424f-9ef1-4009-acaf-8f106387ea8d", "BasicMember", null }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "bb43f661-2d44-4617-9b87-abbbd2bb6490", 0, "c1f44b0c-08d3-44f5-b066-50501a57f411", "abrar@jahin.com", true, null, null, false, null, "ABRAR@JAHIN.COM", "ABRAR", "AQAAAAEAACcQAAAAELBORMW/MEfWdbdWh27YnVzljg86cWr4PxQJKOtkhXh/IF8yFLs9Pk5cOAMpA7Mi/A==", null, false, null, "8199ed96-fb6e-41b7-80d4-8478f971cadf", false, "abrar", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "237ab70d-8324-452a-bca2-75199ebfd78f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "60abc5d7-1bdc-4204-aa2c-6ed7cc83ca40");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "aa9b5ca6-b2e0-4559-bf8a-024e92e6162f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "b1f5d389-6de5-4275-896b-9a6652753257");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "bf71c790-a12b-4f58-9fe4-511a893e32e5");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "bb43f661-2d44-4617-9b87-abbbd2bb6490");
        }
    }
}
