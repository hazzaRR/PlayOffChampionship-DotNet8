﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlayOffChampionship.Models;

#nullable disable

namespace PlayOffChampionship.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240319115651_Points")]
    partial class Points
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LeaguePlayer", b =>
                {
                    b.Property<int>("LeaguesId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayersId")
                        .HasColumnType("integer");

                    b.HasKey("LeaguesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("LeaguePlayer");
                });

            modelBuilder.Entity("PlayOffChampionship.Models.Leaderboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("TotalMatches")
                        .HasColumnType("integer");

                    b.Property<int>("TotalWins")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerId", "LeagueId")
                        .IsUnique();

                    b.ToTable("leaderboard");
                });

            modelBuilder.Entity("PlayOffChampionship.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("league");
                });

            modelBuilder.Entity("PlayOffChampionship.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Player1Id")
                        .HasColumnType("integer");

                    b.Property<int>("Player1Score")
                        .HasColumnType("integer");

                    b.Property<int>("Player2Id")
                        .HasColumnType("integer");

                    b.Property<int>("Player2Score")
                        .HasColumnType("integer");

                    b.Property<int>("WinnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("match");
                });

            modelBuilder.Entity("PlayOffChampionship.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("player");
                });

            modelBuilder.Entity("PlayOffChampionship.Models.PlayerLeague", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId", "LeagueId");

                    b.HasIndex("LeagueId");

                    b.ToTable("player_league");
                });

            modelBuilder.Entity("LeaguePlayer", b =>
                {
                    b.HasOne("PlayOffChampionship.Models.League", null)
                        .WithMany()
                        .HasForeignKey("LeaguesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayOffChampionship.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayOffChampionship.Models.Leaderboard", b =>
                {
                    b.HasOne("PlayOffChampionship.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayOffChampionship.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("PlayOffChampionship.Models.Match", b =>
                {
                    b.HasOne("PlayOffChampionship.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayOffChampionship.Models.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayOffChampionship.Models.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayOffChampionship.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Player1");

                    b.Navigation("Player2");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("PlayOffChampionship.Models.PlayerLeague", b =>
                {
                    b.HasOne("PlayOffChampionship.Models.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayOffChampionship.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
