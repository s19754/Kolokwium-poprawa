﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace efDataBase.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Musician_IdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Musician_IdMusician",
                table: "Musician_Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Tracks_Tracks_IdTrack",
                table: "Musician_Tracks");

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
        }
    }
}