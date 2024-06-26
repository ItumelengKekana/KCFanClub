﻿// <auto-generated />
using KCFanClub.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KCFanClub.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240511092459_ChangeDateToString")]
    partial class ChangeDateToString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KCFanClub.Server.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Opponent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Match");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = "2024/05/16",
                            Opponent = "Orlando Pirates",
                            Time = "11:00 am",
                            Venue = "Orlando Stadium"
                        },
                        new
                        {
                            Id = 2,
                            Date = "2024/05/18",
                            Opponent = "Golden Arrows",
                            Time = "11:00 am",
                            Venue = "Lamontville Stadium"
                        },
                        new
                        {
                            Id = 3,
                            Date = "2024/05/21",
                            Opponent = "Bloemfontein Celtics",
                            Time = "11:00 am",
                            Venue = "Bloemfontein Stadium"
                        },
                        new
                        {
                            Id = 4,
                            Date = "2024/05/25",
                            Opponent = "Mamelodi Sundowns",
                            Time = "11:00 am",
                            Venue = "HM Pitje Stadium"
                        },
                        new
                        {
                            Id = 5,
                            Date = "2024/05/30",
                            Opponent = "Moroka Swallows",
                            Time = "11:00 am",
                            Venue = "Moroka Stadium"
                        });
                });

            modelBuilder.Entity("KCFanClub.Server.Models.PlayerProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PlayerProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
