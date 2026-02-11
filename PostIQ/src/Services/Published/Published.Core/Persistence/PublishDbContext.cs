using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Published.Core.Entities;

namespace Published.Core.Persistence;

public partial class PublishDbContext : DbContext
{
    public PublishDbContext()
    {
    }

    public PublishDbContext(DbContextOptions<PublishDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Repo> Repos { get; set; }

    public virtual DbSet<RepoDetail> RepoDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEBASISH\\SQLEXPRESS02;Database=PostIQ_DB;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK_Published.Job");
        });

        modelBuilder.Entity<Repo>(entity =>
        {
            entity.HasKey(e => e.RepoId).HasName("PK_Published_Repo.Job");

            entity.HasOne(d => d.Job).WithMany(p => p.Repos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Repos_Job");
        });

        modelBuilder.Entity<RepoDetail>(entity =>
        {
            entity.HasKey(e => e.RepoDetailsId).HasName("PK_Publish.RepoDetails");

            entity.HasOne(d => d.Repo).WithMany(p => p.RepoDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RepoDetails_Repos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
