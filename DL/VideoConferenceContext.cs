using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace DL {
    public partial class VideoConferenceContext : DbContext
    {
        public VideoConferenceContext()
        {
        }

        public VideoConferenceContext(DbContextOptions<VideoConferenceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Meeting> Meetings { get; set; }

        public virtual DbSet<MeetingParticipant> MeetingParticipants { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=.;Database=Video Conference;Trusted_Connection=True; TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasKey(e => e.MeetingId).HasName("PK__Meetings__C7B91CAB222DCB49");

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
                entity.Property(e => e.AdminUserId).HasColumnName("admin_user_id");
                entity.Property(e => e.MeetingName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("meeting_name");

                entity.HasOne(d => d.AdminUser).WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.AdminUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meetings__admin___6383C8BA");
            });

            modelBuilder.Entity<MeetingParticipant>(entity =>
            {
                entity.HasKey(e => e.MeetingParticipantId).HasName("PK__Meeting___350E99329F9BAEA7");

                entity.ToTable("Meeting_Participants");

                entity.Property(e => e.MeetingParticipantId).HasColumnName("meeting_participant_id");
                entity.Property(e => e.IsMuted).HasColumnName("is_muted");
                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CCB4B10624");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F010ECB18");

                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__role_id__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}