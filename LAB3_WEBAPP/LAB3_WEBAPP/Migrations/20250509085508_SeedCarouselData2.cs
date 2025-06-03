using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB3_WEBAPP.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarouselData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                column: "ImageURL",
                value: "carousel_images/1.png");

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                column: "ImageURL",
                value: "carousel_images/2.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                column: "ImageURL",
                value: "/carousel_images/1.png");

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                column: "ImageURL",
                value: "/carousel_images/2.png");
        }
    }
}
