using Microsoft.EntityFrameworkCore.Migrations;

namespace efDataBase.Migrations
{
    public partial class MoreSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 3, 3f, 1, "Cos" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 4, 5f, 1, "Cos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 4);
        }
    }
}
