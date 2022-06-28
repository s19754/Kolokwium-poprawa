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

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>(p =>
            {
                p.HasKey(e => e.OrganizationID);
                p.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                p.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);


                p.HasData(
                    new Organization
                    {
                       OrganizationID = 1,
                       OrganizationName = "Org1",
                       OrganizationDomain = "Dom11"
                    },
                    new Organization
                    {
                        OrganizationID = 2,
                        OrganizationName = "Org2",
                        OrganizationDomain = "Dom2"
                    }
                    );
            });

            modelBuilder.Entity<File>(d =>
            {
                d.HasKey(e => new { e.FileID, e.TeamID });
                d.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                d.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                d.Property(e => e.FileSize).IsRequired();
                d.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);

                d.HasData(
                    new File
                    {
                        FileID = 1,
                        FileName = "Arka",
                        FileExtension = "png",
                        FileSize = 24,
                        TeamID = 1
                    },
                    new File
                    {
                        FileID = 2,
                        FileName = "Cos",
                        FileExtension = "png",
                        FileSize = 64,
                        TeamID = 2
                    }
                    );
            });

            modelBuilder.Entity<Member>(p =>
            {
                p.HasKey(e => e.MemberID);
                p.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                p.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                p.Property(e => e.MemberNickname).HasMaxLength(20);
                p.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);

                p.HasData(
                    new Member
                    {
                        MemberID = 1,
                        MemberName = "Anna",
                        MemberSurname = "Koło",
                        MemberNickname = "Koło",
                        OrganizationID = 1
                    },
                    new Member
                    {
                        MemberID = 2,
                        MemberName = "Tomasz",
                        MemberSurname = "Kołodziejczuk",
                        MemberNickname = "Koło",
                        OrganizationID = 1
                    }, new Member
                    {
                        MemberID = 3,
                        MemberName = "Piotr",
                        MemberSurname = "Pawlik",
                        MemberNickname = null,
                        OrganizationID = 2
                    }, new Member
                    {
                        MemberID = 4,
                        MemberName = "Kasia",
                        MemberSurname = "coś",
                        MemberNickname = null,
                        OrganizationID = 2
                    }
                    );
            });

            modelBuilder.Entity<Team>(m =>
            {
                m.HasKey(e => e.TeamID);
                m.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                m.Property(e => e.TeamDescription).HasMaxLength(20);
                m.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);

                m.HasData(
                    new Team
                    {
                        TeamID = 1,
                        TeamName = "Team1",
                        TeamDescription = "desc1",
                        OrganizationID = 1
                    },
                    new Team
                    {
                        TeamID = 2,
                        TeamName = "Team2",
                        TeamDescription = null,
                        OrganizationID = 2
                    }
                    );
            });

            modelBuilder.Entity<Membership>(p =>
            {
                p.HasKey(e => new { e.MemberID, e.TeamID });
                p.Property(e => e.MembershipDate).IsRequired();
                p.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID).OnDelete(DeleteBehavior.NoAction);
                p.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.NoAction);

                p.HasData(
                    new Membership
                    {
                        TeamID = 1,
                        MembershipDate = DateTime.Parse("2022-03-18"),
                        MemberID = 1

                    },
                    new Membership
                    {
                        TeamID = 1,
                        MembershipDate = DateTime.Parse("2022-05-18"),
                        MemberID = 2

                    },
                    new Membership
                    {
                        TeamID = 2,
                        MembershipDate = DateTime.Parse("2022-04-30"),
                        MemberID = 2

                    },
                    new Membership
                    {
                        TeamID = 2,
                        MembershipDate = DateTime.Parse("2022-04-12"),
                        MemberID = 3

                    },
                    new Membership
                    {
                        TeamID = 2,
                        MembershipDate = DateTime.Parse("2022-04-10"),
                        MemberID = 4

                    }
                    );
            });
        }

    }
}
