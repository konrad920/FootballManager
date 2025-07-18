﻿// <auto-generated />
using FootballManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballManager.DataAccess.Migrations
{
    [DbContext(typeof(FootballManagerContext))]
    [Migration("20250704202333_AddTabelsName")]
    partial class AddTabelsName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FootballManager.DataAccess.Entities.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("Salary")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("FootballManager.DataAccess.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Position")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<long>("Salary")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FootballManager.DataAccess.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("PlayersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("PlayerTeam");
                });

            modelBuilder.Entity("FootballManager.DataAccess.Entities.Team", b =>
                {
                    b.HasOne("FootballManager.DataAccess.Entities.Coach", "Coach")
                        .WithMany("Teams")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.HasOne("FootballManager.DataAccess.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballManager.DataAccess.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballManager.DataAccess.Entities.Coach", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
