﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using book_club.Database.Context;

#nullable disable

namespace book_club.Migrations
{
    [DbContext(typeof(BookClubContext))]
    [Migration("20240118054340_configure-usermanager")]
    partial class configureusermanager
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("UserID");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("book_club.Database.Entity.BookClub", b =>
                {
                    b.Property<int>("ClubId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ClubID");

                    b.Property<string>("ClubName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("OwnerID");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClubId");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "OwnerId" }, "IX_BookClub")
                        .IsUnique();

                    b.ToTable("BookClub", (string)null);

                    b.HasData(
                        new
                        {
                            ClubId = 1,
                            ClubName = "Demo Book Club",
                            OwnerId = 1
                        });
                });

            modelBuilder.Entity("book_club.Database.Entity.BookClubMember", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<int>("ClubId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ClubID");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("UserId");

                    b.ToTable("BookClubMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClubId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClubId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            ClubId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            ClubId = 1,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("book_club.Database.Entity.ClubMeeting", b =>
                {
                    b.Property<int>("MeetingId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("MeetingID");

                    b.Property<string>("BookId")
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("BookID");

                    b.Property<int>("ClubId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ClubID");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("HostId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("HostID");

                    b.Property<string>("Location")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.HasKey("MeetingId");

                    b.HasIndex("ClubId");

                    b.HasIndex("HostId");

                    b.ToTable("ClubMeeting", (string)null);

                    b.HasData(
                        new
                        {
                            MeetingId = 1,
                            ClubId = 1,
                            Date = new DateTime(2024, 1, 22, 21, 43, 40, 626, DateTimeKind.Local).AddTicks(543),
                            HostId = 3,
                            Location = "1234 Address, City, State, Zip"
                        });
                });

            modelBuilder.Entity("book_club.Database.Entity.Rsvp", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<int>("MeetingId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("MeetingID");

                    b.Property<bool?>("Rsvpstatus")
                        .HasColumnType("INTEGER")
                        .HasColumnName("RSVPStatus");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("UserId");

                    b.ToTable("RSVP", (string)null);
                });

            modelBuilder.Entity("book_club.Database.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("UserID");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b276ad79-1b81-432b-b828-58737577b3a6",
                            Email = "test@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Password = "password",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Demo Owner 1"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "72613071-e8a2-4758-b9e4-72a55ac57090",
                            Email = "test@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Password = "password",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Demo Member 1"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "95bcca5c-3032-48fa-bd6a-6b967a1ebbb0",
                            Email = "test@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Password = "password",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Demo Member 2"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "01eb2285-538c-46f8-9ed0-bc5ad7e53d89",
                            Email = "test@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Password = "password",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Demo Member 3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("book_club.Database.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("book_club.Database.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("book_club.Database.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("book_club.Database.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("book_club.Database.Entity.BookClub", b =>
                {
                    b.HasOne("book_club.Database.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("book_club.Database.Entity.BookClubMember", b =>
                {
                    b.HasOne("book_club.Database.Entity.BookClub", "Club")
                        .WithMany("BookClubMembers")
                        .HasForeignKey("ClubId")
                        .IsRequired()
                        .HasConstraintName("FK_BookClubMembers_BookClub");

                    b.HasOne("book_club.Database.Entity.User", "User")
                        .WithMany("BookClubMembers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_BookClubMembers_User");

                    b.Navigation("Club");

                    b.Navigation("User");
                });

            modelBuilder.Entity("book_club.Database.Entity.ClubMeeting", b =>
                {
                    b.HasOne("book_club.Database.Entity.BookClub", "Club")
                        .WithMany("ClubMeetings")
                        .HasForeignKey("ClubId")
                        .IsRequired()
                        .HasConstraintName("FK_ClubMeeting_BookClub");

                    b.HasOne("book_club.Database.Entity.User", "Host")
                        .WithMany("ClubMeetings")
                        .HasForeignKey("HostId")
                        .HasConstraintName("FK_ClubMeeting_User");

                    b.Navigation("Club");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("book_club.Database.Entity.Rsvp", b =>
                {
                    b.HasOne("book_club.Database.Entity.ClubMeeting", "Meeting")
                        .WithMany("Rsvps")
                        .HasForeignKey("MeetingId")
                        .IsRequired()
                        .HasConstraintName("FK_RSVP_ClubMeeting");

                    b.HasOne("book_club.Database.Entity.User", "User")
                        .WithMany("Rsvps")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_RSVP_User");

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("book_club.Database.Entity.BookClub", b =>
                {
                    b.Navigation("BookClubMembers");

                    b.Navigation("ClubMeetings");
                });

            modelBuilder.Entity("book_club.Database.Entity.ClubMeeting", b =>
                {
                    b.Navigation("Rsvps");
                });

            modelBuilder.Entity("book_club.Database.Entity.User", b =>
                {
                    b.Navigation("BookClubMembers");

                    b.Navigation("ClubMeetings");

                    b.Navigation("Rsvps");
                });
#pragma warning restore 612, 618
        }
    }
}
