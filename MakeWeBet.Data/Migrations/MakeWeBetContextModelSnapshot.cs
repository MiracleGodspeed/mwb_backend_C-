﻿// <auto-generated />
using System;
using MakeWeBet.Data.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MakeWeBet.Data.Migrations
{
    [DbContext(typeof(MakeWeBetContext))]
    partial class MakeWeBetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.Bet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BetCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BetEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BetPrivatePasscode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BetReviewStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BetStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BetValidityStatus")
                        .HasColumnType("int");

                    b.Property<long>("CommentCount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorBonus")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<long>("LikeCount")
                        .HasColumnType("bigint");

                    b.Property<long>("ReshareCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BetCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("BET");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.BetCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BET_CATEGORY");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("COUNTRY");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencySymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CURRENCY");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.UserBet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("BetAmount")
                        .HasColumnType("bigint");

                    b.Property<Guid>("BetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BetResult")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<int>("PairingStatus")
                        .HasColumnType("int");

                    b.Property<int>("SelectedBetResponse")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.HasIndex("UserId");

                    b.ToTable("USER_BET");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.UserBetCategorySuggestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("USER_BET_CATEGORY_SUGGESTION");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.UserFollowership", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<int>("FollowershipStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserFollowingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserFollowingId");

                    b.HasIndex("UserId");

                    b.ToTable("USER_FOLLOWERSHIP");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.Bet", b =>
                {
                    b.HasOne("MakeWeBet.Data.Models.Entity.BetCategory", "BetCategory")
                        .WithMany()
                        .HasForeignKey("BetCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MakeWeBet.Data.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BetCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.User", b =>
                {
                    b.HasOne("MakeWeBet.Data.Models.Entity.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.UserBet", b =>
                {
                    b.HasOne("MakeWeBet.Data.Models.Entity.Bet", "Bet")
                        .WithMany()
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MakeWeBet.Data.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.UserBetCategorySuggestion", b =>
                {
                    b.HasOne("MakeWeBet.Data.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MakeWeBet.Data.Models.Entity.UserFollowership", b =>
                {
                    b.HasOne("MakeWeBet.Data.Models.Entity.User", "UserFollowing")
                        .WithMany()
                        .HasForeignKey("UserFollowingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MakeWeBet.Data.Models.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserFollowing");
                });
#pragma warning restore 612, 618
        }
    }
}