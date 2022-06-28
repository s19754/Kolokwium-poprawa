using Microsoft.EntityFrameworkCore.Migrations;

namespace efDataBase.Migrations
{
    public partial class Test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks",
                column: "IdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks");

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks",
                column: "IdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
