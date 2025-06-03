using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB3_WEBAPP.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarouselData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "1", "/carousel_images/1.png", "1" });

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "2", "/carousel_images/2.png", "2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 1,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "2", "~images/carousel_images/2.png", "2" });

            migrationBuilder.UpdateData(
                table: "Carousels",
                keyColumn: "CarouselId",
                keyValue: 2,
                columns: new[] { "Description", "ImageURL", "Title" },
                values: new object[] { "1", "~images/carousel_images/1.png", "1" });
        }
    }
}
