using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenCongTung_2310900051.Models;

public partial class NguyenCongTung2310900051Context : DbContext
{
    public NguyenCongTung2310900051Context()
    {
    }

    public NguyenCongTung2310900051Context(DbContextOptions<NguyenCongTung2310900051Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NctEmployee> NctEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BOKA-CHAN\\MSSQLSERVER01;Database=NguyenCongTung_2310900051;uid=CongTung205;pwd=12345678; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NctEmployee>(entity =>
        {
            entity.HasKey(e => e.NctEmpId).HasName("PK__nctEmplo__8F171A2E279999DA");

            entity.ToTable("nctEmployee");

            entity.Property(e => e.NctEmpId)
                .HasMaxLength(15)
                .HasColumnName("nctEmpId");
            entity.Property(e => e.NctEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("nctEmpLevel");
            entity.Property(e => e.NctEmpName)
                .HasMaxLength(100)
                .HasColumnName("nctEmpName");
            entity.Property(e => e.NctEmpStartDate).HasColumnName("nctEmpStartDate");
            entity.Property(e => e.NctEmpStatus).HasColumnName("nctEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
