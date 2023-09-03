using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace syndicateApp.Models;

public partial class SyndicatedContext : DbContext
{
    public SyndicatedContext()
    {
    }

    public SyndicatedContext(DbContextOptions<SyndicatedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblPost> TblPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=syndicated;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblPost>(entity =>
        {
            entity.HasKey(e => e.IdNo);

            entity.ToTable("tbl_posts");

            entity.Property(e => e.IdNo).HasColumnName("id_no");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MetaData)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("meta_data");
            entity.Property(e => e.PostCategory).HasColumnName("post_category");
            entity.Property(e => e.PostImage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("post_image");
            entity.Property(e => e.PostText).HasColumnName("post_text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
