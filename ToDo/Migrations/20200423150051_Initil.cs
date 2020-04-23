using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Migrations
{
    public partial class Initil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cd7731a-73d0-4cd2-b361-b09c0ef9939e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aed1a521-ac1f-47fc-9f57-ccc4f356165e", 0, "31ff5aad-a9bd-4f3f-ae3f-04a3612fa63f", "r@r.com", true, "Rose", "Wiz", false, null, "R@R.COM", "R@R.COM", "AQAAAAEAACcQAAAAEL5hoDdZlmiSQph14YTU6Nu2ozLzE+0drlZOkbAlCwkMuS9ZvcmAX45hVk5dN1131A==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "r@r.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aed1a521-ac1f-47fc-9f57-ccc4f356165e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5cd7731a-73d0-4cd2-b361-b09c0ef9939e", 0, "0bacae89-5bee-40c0-a9d3-2a46f4a6014b", "r@r.com", true, "Rose", "Wiz", false, null, "R@R.COM", "R@R.COM", "AQAAAAEAACcQAAAAEFAlkVCbr4QywOJ9E99qLn6eQ0lCq1j+kaE+Iaks+IlhYMyiHZn9kEq8Oxxs6JZzkA==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "r@r.com" });
        }
    }
}
