using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB3_WEBAPP.Migrations
{
    /// <inheritdoc />
    public partial class hashPassAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$lpIJVZRmA94ZEbPzWx61r./7yq/NaJbIxSDgRAbNJ0r9uptRo82lW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$kax64dZCvewMC8iMqHE94eY8BkC0yU3S6qmJbJxnLwiNx4cMS3d5u");
        }
    }
}
