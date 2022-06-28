using Microsoft.EntityFrameworkCore.Migrations;

namespace efDataBase.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Musician_IdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks");

            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Musician_Tracks",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 2,
                column: "IdMusicAlbum",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 3,
                column: "IdMusicAlbum",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 4,
                column: "IdMusicAlbum",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Musician_IdMusician",
                table: "Musician_Tracks",
                column: "IdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks",
                column: "IdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks",
                column: "IdMusicAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Musician_IdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks");

            migrationBuilder.DeleteData(
                table: "Musician_Tracks",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Musician_Tracks",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 2,
                column: "IdMusicAlbum",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 3,
                column: "IdMusicAlbum",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 4,
                column: "IdMusicAlbum",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Musician_IdMusician",
                table: "Musician_Tracks",
                column: "IdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks",
                column: "IdTrack",
                principalTable: "Tracks",
                principalColumn: "IdTrack",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_IdMusicAlbum",
                table: "Tracks",
                column: "IdMusicAlbum",
                principalTable: "Albums",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
