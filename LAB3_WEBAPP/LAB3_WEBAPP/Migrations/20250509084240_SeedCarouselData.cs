using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB3_WEBAPP.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarouselData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                column: "ImageURL",
                value: "~images/carousel_images/2.png");

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                column: "ImageURL",
                value: "~images/carousel_images/1.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                column: "ImageURL",
                value: "~/carousel_images/images/2.png");

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                column: "ImageURL",
                value: "~/carousel_images/images/1.png");
        }
    }
}
