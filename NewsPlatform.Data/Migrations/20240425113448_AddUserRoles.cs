using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
