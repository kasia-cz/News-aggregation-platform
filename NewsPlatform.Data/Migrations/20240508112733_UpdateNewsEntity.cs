using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "426f2358-76c3-4e81-b58b-4dc11ac8738a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86070e36-32ec-47c2-afd2-47df1d87bc0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e08e68e-08c6-44d8-932a-dd60502b5c14");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceLink",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31bfb30b-f591-4c10-a1a9-843b4015fee5", "2", "AuthorizedUser", "AUTHORIZEDUSER" },
                    { "ae68e7e9-f16c-49cc-86ce-24675a878060", "1", "Moderator", "MODERATOR" },
                    { "c3c53101-930d-40a1-905a-8cacdab7ab61", "3", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31bfb30b-f591-4c10-a1a9-843b4015fee5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae68e7e9-f16c-49cc-86ce-24675a878060");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3c53101-930d-40a1-905a-8cacdab7ab61");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SourceLink",
                table: "News");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "426f2358-76c3-4e81-b58b-4dc11ac8738a", "2", "AuthorizedUser", "AUTHORIZEDUSER" },
                    { "86070e36-32ec-47c2-afd2-47df1d87bc0c", "1", "Moderator", "MODERATOR" },
                    { "9e08e68e-08c6-44d8-932a-dd60502b5c14", "3", "User", "USER" }
                });
        }
    }
}
