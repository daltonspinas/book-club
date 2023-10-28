using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using book_club.Database.Entity;

namespace book_club.Database.Context;

public partial class BookClubContext : DbContext
{
    public BookClubContext()
    {
    }

    public BookClubContext(DbContextOptions<BookClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookClub> BookClubs { get; set; }

    public virtual DbSet<BookClubMember> BookClubMembers { get; set; }

    public virtual DbSet<ClubMeeting> ClubMeetings { get; set; }

    public virtual DbSet<Rsvp> Rsvps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=45062\\SQLEXPRESS;Initial Catalog=book_club;Integrated Security=SSPI;Encrypt=false");

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

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                .HasPrincipalKey<BookClub>(p => p.OwnerId)
                .HasForeignKey<User>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_BookClub");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
