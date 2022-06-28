﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using efDataBase.Models;

namespace efDataBase.Migrations
{
    [DbContext(typeof(s19754Context))]
    [Migration("20220628122332_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("efDataBase.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Arka",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Cos",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("efDataBase.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabels");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Pop"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "Rock"
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musician");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Ktos",
                            LastName = "fwgsdg",
                            Nickname = "krople"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Tomek",
                            LastName = "jajahj"
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.HasKey("IdTrack", "IdMusician");

                    b.HasIndex("IdMusician");

                    b.ToTable("Musician_Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 2,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 2,
                            IdMusician = 2
                        },
                        new
                        {
                            IdTrack = 3,
                            IdMusician = 2
                        },
                        new
                        {
                            IdTrack = 4,
                            IdMusician = 2
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 12f,
                            IdMusicAlbum = 1,
                            TrackName = "Cos"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 23f,
                            TrackName = "Czegos"
                        },
                        new
                        {
                            IdTrack = 3,
                            Duration = 3f,
                            TrackName = "Cos"
                        },
                        new
                        {
                            IdTrack = 4,
                            Duration = 5f,
                            TrackName = "Cos"
                        });
                });

            modelBuilder.Entity("efDataBase.Models.Album", b =>
                {
                    b.HasOne("efDataBase.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("efDataBase.Models.Musician_Track", b =>
                {
                    b.HasOne("efDataBase.Models.Musician", "Musician")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("efDataBase.Models.Track", "Track")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("efDataBase.Models.Track", b =>
                {
                    b.HasOne("efDataBase.Models.Album", "MusicAlbum")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("MusicAlbum");
                });

            modelBuilder.Entity("efDataBase.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("efDataBase.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("efDataBase.Models.Musician", b =>
                {
                    b.Navigation("Musician_Tracks");
                });

            modelBuilder.Entity("efDataBase.Models.Track", b =>
                {
                    b.Navigation("Musician_Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
