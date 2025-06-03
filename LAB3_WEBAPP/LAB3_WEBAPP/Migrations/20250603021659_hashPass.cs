using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB3_WEBAPP.Migrations
{
    /// <inheritdoc />
    public partial class hashPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$kax64dZCvewMC8iMqHE94eY8BkC0yU3S6qmJbJxnLwiNx4cMS3d5u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$DO6pmHlIENmuldPySmnZ5OVRhDFqvVzo04iKun58oZRPbJMYANRZO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$LNROwf1mJ6XybRprV99CR.Q0rPiR5gOO/j/rL8KFSPp8XNPSipj2O");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$z3lJj3Rr7ME0VbDvPBt6LOeb2NTxU5xIOzJsrryOJbcKlf3uNUR5W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$U6ee6taud2X04qRBxRVjbuHN7j5tAvwqGeRqEw8.7uqv16ZwRVpo6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$FEg724AOPVtH9MBYK6Y2eu1YQxqCo0zZd9BhKZTQ2CAKOIXacCXIG");
        }
    }
}
