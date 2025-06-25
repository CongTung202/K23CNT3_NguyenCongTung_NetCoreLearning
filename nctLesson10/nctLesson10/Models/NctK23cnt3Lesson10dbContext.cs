using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nctLesson10.Models;

public partial class NctK23cnt3Lesson10dbContext : DbContext
{
    public NctK23cnt3Lesson10dbContext()
    {
    }

    public NctK23cnt3Lesson10dbContext(DbContextOptions<NctK23cnt3Lesson10dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NctPost> NctPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BOKA-CHAN\\MSSQLSERVER01;Database=nctK23CNT3_Lesson10db;uid=CongTung205;pwd=12345678; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NctPost>(entity =>
        {
            entity.HasKey(e => e.NctId);

            entity.ToTable("nctPost");

            entity.Property(e => e.NctId).HasColumnName("nctId");
            entity.Property(e => e.NctContent)
                .HasColumnType("ntext")
                .HasColumnName("nctContent");
            entity.Property(e => e.NctImage)
                .HasMaxLength(250)
                .HasColumnName("nctImage");
            entity.Property(e => e.NctStatus).HasColumnName("nctStatus");
            entity.Property(e => e.NctTitle)
                .HasMaxLength(50)
                .HasColumnName("nctTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
