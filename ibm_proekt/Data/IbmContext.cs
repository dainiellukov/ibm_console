using System;
using System.Collections.Generic;
using ibm_proekt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ibm_proekt.Data;

public partial class IbmContext : DbContext
{
    public IbmContext()
    {
    }

    public IbmContext(DbContextOptions<IbmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Firmi> Firmis { get; set; }

    public virtual DbSet<FirmiMarshruti> FirmiMarshrutis { get; set; }

    public virtual DbSet<Marshruti> Marshrutis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DANIELLUKOV\\SQLEXPRESS;Initial Catalog=IBM;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Firmi>(entity =>
        {
            entity.HasKey(e => e.FirmaId).HasName("PK__firmi__5F84B8ADD31C8924");

            entity.ToTable("firmi");

            entity.Property(e => e.FirmaId).HasColumnName("firma_id");
            entity.Property(e => e.FirmaIme)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firma_ime");
        });

        modelBuilder.Entity<FirmiMarshruti>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("firmi_marshruti");

            entity.Property(e => e.FirmaId).HasColumnName("firma_id");
            entity.Property(e => e.MarshrutId).HasColumnName("marshrut_id");

            entity.HasOne(d => d.Firma).WithMany()
                .HasForeignKey(d => d.FirmaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_firmi");

            entity.HasOne(d => d.Marshrut).WithMany()
                .HasForeignKey(d => d.MarshrutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_marshruti");
        });

        modelBuilder.Entity<Marshruti>(entity =>
        {
            entity.HasKey(e => e.MarshrutId).HasName("PK__marshrut__0AF037A5AF211E38");

            entity.ToTable("marshruti");

            entity.Property(e => e.MarshrutId).HasColumnName("marshrut_id");
            entity.Property(e => e.PristigaChas).HasColumnName("pristiga_chas");
            entity.Property(e => e.ZaminavaChas).HasColumnName("zaminava_chas");
            entity.Property(e => e.ZaminavaOt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("zaminava_ot");
            entity.Property(e => e.ZaminavaZa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("zaminava_za");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
