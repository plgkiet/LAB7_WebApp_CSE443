using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LAB3_WEBAPP.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarousel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carousels",
                columns: new[] { "CarouselId", "CreatedDate", "Description", "ImageURL", "IsActive", "LinkURL", "Order", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "~/carousel_images/images/2.png", true, null, 1, "2", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "~/carousel_images/images/1.png", true, null, 2, "1", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2);
        }
    }
}
