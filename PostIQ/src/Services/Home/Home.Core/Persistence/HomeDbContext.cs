using System;
using System.Collections.Generic;
using Home.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home.Core.Persistence;

public partial class HomeDbContext : DbContext
{
    public HomeDbContext()
    {
    }

    public HomeDbContext(DbContextOptions<HomeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BatchJobStatus> BatchJobStatuses { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Debasish\\SQLEXPRESS02;Database=PostIQ_DB;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BatchJobStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK_SyncJob");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User.Posts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
