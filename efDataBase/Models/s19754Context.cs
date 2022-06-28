using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Models
{
    public class s19754Context : DbContext
    {

        protected s19754Context()
        {

        }
            

        public s19754Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<Musician> Musician { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MusicLabel>(p =>
            {
                p.HasKey(e => e.IdMusicLabel);
                p.Property(e => e.Name).IsRequired().HasMaxLength(50);
     

                p.HasData(
                    new MusicLabel
                    {
                       IdMusicLabel = 1,
                       Name = "Pop", 
                    },
                    new MusicLabel
                    {
                        IdMusicLabel = 2,
                        Name = "Rock",
                    }
                    );
            });

            modelBuilder.Entity<Album>(d =>
            {
                d.HasKey(e => e.IdAlbum);
                d.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                d.Property(e => e.PublishDate).IsRequired();
                d.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                d.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "Arka",
                        PublishDate = DateTime.Parse("2022-05-21"),
                        IdMusicLabel = 1
                    },
                    new Album
                    {
                        IdAlbum = 2,
                        AlbumName = "Cos",
                        PublishDate = DateTime.Parse("2022-06-21"),
                        IdMusicLabel = 2
                    }
                    );
            });

            modelBuilder.Entity<Track>(p =>
            {
                p.HasKey(e => e.IdTrack);
                p.Property(e => e.Duration).IsRequired();
                p.Property(e => e.TrackName).HasMaxLength(20);
                p.HasOne(e => e.MusicAlbum).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                p.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "Cos",
                        Duration = 12,
                        IdMusicAlbum = 1
                    },
                    new Track
                    {
                        IdTrack = 2,
                        TrackName = "Czegos",
                        Duration = 23,
                        IdMusicAlbum = null
                    }, new Track
                    {
                        IdTrack = 3,
                        TrackName = "Cos",
                        Duration = 3,
                        IdMusicAlbum = null
                    }, new Track
                    {
                        IdTrack = 4,
                        TrackName = "Cos",
                        Duration = 5,
                        IdMusicAlbum = null
                    }
                    );
            });

            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname).HasMaxLength(20);

                m.HasData(
                    new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Ktos",
                        LastName = "fwgsdg",
                        Nickname = "krople"
                    },
                    new Musician
                    {
                        IdMusician = 2,
                        FirstName = "Tomek",
                        LastName = "jajahj",
                        Nickname = null
                    }
                    );
            });

            modelBuilder.Entity<Musician_Track>(p =>
            {
                p.HasKey(e => new { e.IdTrack, e.IdMusician });
                p.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.NoAction);
                p.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician).OnDelete(DeleteBehavior.NoAction);

                p.HasData(
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 1

                    },
                    new Musician_Track
                    {
                        IdMusician = 1,
                        IdTrack = 2

                    },
                    new Musician_Track
                    {
                        IdMusician = 2,
                        IdTrack = 2

                    },
                    new Musician_Track
                    {
                        IdMusician = 2,
                        IdTrack = 3

                    },
                    new Musician_Track
                    {
                        IdMusician = 2,
                        IdTrack = 4

                    }
                    );
            });
        }

    }
}
