using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class OicarDBContext : DbContext
    {
        public OicarDBContext()
        {
        }

        public OicarDBContext(DbContextOptions<OicarDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatConversation> ChatConversations { get; set; } = null!;
        public virtual DbSet<ChatReply> ChatReplies { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<County> Counties { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public virtual DbSet<ServiceSubcategory> ServiceSubcategories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress2;Database=OicarDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatConversation>(entity =>
            {
                entity.ToTable("ChatConversation");

                entity.HasIndex(e => new { e.ClientIdOne, e.ClientIdTwo }, "Chat")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientIdOne).HasColumnName("ClientID_One");

                entity.Property(e => e.ClientIdTwo).HasColumnName("ClientID_Two");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ClientIdOneNavigation)
                    .WithMany(p => p.ChatConversationClientIdOneNavigations)
                    .HasForeignKey(d => d.ClientIdOne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatConve__Clien__4D94879B");

                entity.HasOne(d => d.ClientIdTwoNavigation)
                    .WithMany(p => p.ChatConversationClientIdTwoNavigations)
                    .HasForeignKey(d => d.ClientIdTwo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatConve__Clien__4E88ABD4");
            });

            modelBuilder.Entity<ChatReply>(entity =>
            {
                entity.ToTable("ChatReply");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChatId).HasColumnName("ChatID");

                entity.Property(e => e.DateSent)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatReplies)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ChatReply__ChatI__5441852A");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.ChatReplies)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatReply__Sende__5535A963");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__CountyID__398D8EEE");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Passw).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.ToTable("County");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.DatePublished)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ServiceSubcategoryId).HasColumnName("ServiceSubcategoryID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__CityID__45F365D3");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__ClientID__4316F928");

                entity.HasOne(d => d.ServiceSubcategory)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.ServiceSubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__ServiceSu__440B1D61");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__ClientID__48CFD27E");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("ServiceCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<ServiceSubcategory>(entity =>
            {
                entity.ToTable("ServiceSubcategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceCategoryId).HasColumnName("ServiceCategoryID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.ServiceSubcategories)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServiceSu__Servi__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
