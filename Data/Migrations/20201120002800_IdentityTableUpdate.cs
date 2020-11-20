using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    public partial class IdentityTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Role_RoleId",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_User_UserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "Identity",
                table: "Role");

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

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "AspNetUserTokens",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "AspNetUserRoles",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "AspNetUserLogins",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "AspNetUserClaims",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "AspNetRoleClaims",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "AspNetRoles",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                schema: "public",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                schema: "public",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                schema: "public",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "public",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserTokens",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserLogins",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserClaims",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "public",
                table: "AspNetRoleClaims",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "public",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                schema: "public",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "public",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                schema: "public",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                schema: "public",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                schema: "public",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "public",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UsernameChangeLimit = table.Column<int>(nullable: false),
                    ProfilePicture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { "51715d44-1282-4126-a20f-9927301a2d62", 0, "b55d6519-df3a-4674-be52-2ead680cbb80", "abrar@jahin.com", true, null, null, false, null, "ABRAR@JAHIN.COM", "ABRAR", "AQAAAAEAACcQAAAAEAp8HqNIJg7xZbk+HnxuEyE5F8345eOZ/ZkM3NYfAUz/FVqIm9KZOMDfUC8bBH46Tg==", null, false, null, "37e3321c-b71c-4ed3-b500-5608c620da2a", false, "abrar", 10 });

            migrationBuilder.InsertData(
                schema: "public",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99b02a9f-e794-47c0-a7b3-e4b3c7fa083e", "fa8ed33a-9e2f-438a-a5ae-91c56c1ac4b5", "IdentityRole", "SuperAdmin", null },
                    { "c3b50570-2998-423b-9466-28241cdcff4d", "acd0999c-7a6f-49f0-9299-b80b2fff71f1", "IdentityRole", "Admin", null },
                    { "8b64cd32-4316-4939-bac6-6d1f85649373", "b704d6c1-0917-4d2a-a399-490725e5e33c", "IdentityRole", "Auditor", null },
                    { "dd86275e-417f-4b66-9a3e-875335c143e5", "831d8b5e-62ec-4e12-a94a-78f3a36ba7f9", "IdentityRole", "TeamMember", null },
                    { "6feacd77-159a-42ef-aa74-9b6e1c75b164", "de9aca00-8a13-4c97-882f-44d496b94d0c", "IdentityRole", "BasicMember", null }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "public",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "public",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                schema: "public",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "public",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "public",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "public",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                schema: "public",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "public",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "public",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                schema: "public",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "public",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                schema: "public",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "public",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                schema: "public",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "public",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                schema: "public",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                schema: "public",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "public",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                schema: "public",
                table: "AspNetRoleClaims");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6feacd77-159a-42ef-aa74-9b6e1c75b164");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b64cd32-4316-4939-bac6-6d1f85649373");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99b02a9f-e794-47c0-a7b3-e4b3c7fa083e");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3b50570-2998-423b-9466-28241cdcff4d");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd86275e-417f-4b66-9a3e-875335c143e5");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "public",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "public",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "public",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "public",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "public",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "public",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "public",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "public",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "public",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                schema: "Identity",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                schema: "Identity",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "Identity",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                schema: "Identity",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "bytea", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    UsernameChangeLimit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Role_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_User_UserId",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
