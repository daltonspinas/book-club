using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using book_club.Database.Entity;


namespace book_club.Database.Context;

public partial class BookClubContext : DbContext
{
    private readonly IConfiguration _configuration;
    public BookClubContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public BookClubContext(DbContextOptions<BookClubContext> options)
        : base(options)
    {
        using(var context = new BookClubContext(options))
        {
            context.Database.EnsureCreated();
        }
    }

    public virtual DbSet<BookClub> BookClubs { get; set; }

    public virtual DbSet<BookClubMember> BookClubMembers { get; set; }

    public virtual DbSet<ClubMeeting> ClubMeetings { get; set; }

    public virtual DbSet<Rsvp> Rsvps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("book_club"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookClub>(entity =>
        {
            entity.HasKey(e => e.ClubId);

            entity.ToTable("BookClub");

            entity.HasIndex(e => e.OwnerId, "IX_BookClub").IsUnique();

            entity.Property(e => e.ClubId)
                .ValueGeneratedNever()
                .HasColumnName("ClubID");
            entity.Property(e => e.ClubName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
        });

        modelBuilder.Entity<BookClubMember>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Club).WithMany(p => p.BookClubMembers)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookClubMembers_BookClub");

            entity.HasOne(d => d.User).WithMany(p => p.BookClubMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookClubMembers_User");
        });

        modelBuilder.Entity<ClubMeeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId);

            entity.ToTable("ClubMeeting");

            entity.Property(e => e.MeetingId)
                .ValueGeneratedNever()
                .HasColumnName("MeetingID");
            entity.Property(e => e.BookId)
                .IsUnicode(false)
                .HasColumnName("BookID");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.HostId).HasColumnName("HostID");
            entity.Property(e => e.Location).IsUnicode(false);

            entity.HasOne(d => d.Club).WithMany(p => p.ClubMeetings)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClubMeeting_BookClub");

            entity.HasOne(d => d.Host).WithMany(p => p.ClubMeetings)
                .HasForeignKey(d => d.HostId)
                .HasConstraintName("FK_ClubMeeting_User");
        });

        modelBuilder.Entity<Rsvp>(entity =>
        {
            entity.ToTable("RSVP");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.MeetingId).HasColumnName("MeetingID");
            entity.Property(e => e.Rsvpstatus).HasColumnName("RSVPStatus");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Meeting).WithMany(p => p.Rsvps)
                .HasForeignKey(d => d.MeetingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RSVP_ClubMeeting");

            entity.HasOne(d => d.User).WithMany(p => p.Rsvps)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RSVP_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

        });

        modelBuilder.Seed();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
