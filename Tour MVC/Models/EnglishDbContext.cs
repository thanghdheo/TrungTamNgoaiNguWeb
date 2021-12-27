using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tour_MVC.Models
{
    public partial class EnglishDbContext : DbContext
    {
        public EnglishDbContext()
        {
        }

        public EnglishDbContext(DbContextOptions<EnglishDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DuThi> DuThis { get; set; }
        public virtual DbSet<GiamThi> GiamThis { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<KhoaThi> KhoaThis { get; set; }
        public  DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhongThi> PhongThis { get; set; }
        public virtual DbSet<ThiSinh> ThiSinhs { get; set; }
        public virtual DbSet<TrinhDo> TrinhDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=THNGA406\\BO;Initial Catalog=TrungTamNgoaiNgu;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DuThi>(entity =>
            {
                entity.HasKey(e => new { e.MaKhoaThi, e.Cccd });

                entity.Property(e => e.Cccd).IsUnicode(false);

                entity.HasOne(d => d.CccdNavigation)
                    .WithMany(p => p.DuThis)
                    .HasForeignKey(d => d.Cccd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DuThi_NguoiDung");

                entity.HasOne(d => d.MaKhoaThiNavigation)
                    .WithMany(p => p.DuThis)
                    .HasForeignKey(d => d.MaKhoaThi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DuThi_KhoaThi");

                entity.HasOne(d => d.MaTrinhDoNavigation)
                    .WithMany(p => p.DuThis)
                    .HasForeignKey(d => d.MaTrinhDo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DuThi_TrinhDo");
            });

            modelBuilder.Entity<GiamThi>(entity =>
            {
                entity.HasKey(e => new { e.MaPhong, e.MaGiaoVien });

                entity.HasOne(d => d.MaGiaoVienNavigation)
                    .WithMany(p => p.GiamThis)
                    .HasForeignKey(d => d.MaGiaoVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GiamThi_GiaoVien");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.GiamThis)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GiamThi_PhongThi");
            });

            modelBuilder.Entity<KhoaThi>(entity =>
            {
                entity.HasKey(e => e.MaKhoaThi)
                    .HasName("PK_KhoaThi_1");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.Property(e => e.Cccd).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.SoDienThoai).IsUnicode(false);
            });

            modelBuilder.Entity<PhongThi>(entity =>
            {
                entity.HasOne(d => d.MaKhoaThiNavigation)
                    .WithMany(p => p.PhongThis)
                    .HasForeignKey(d => d.MaKhoaThi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhongThi_KhoaThi");

                entity.HasOne(d => d.MaTrinhDoNavigation)
                    .WithMany(p => p.PhongThis)
                    .HasForeignKey(d => d.MaTrinhDo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhongThi_TrinhDo");
            });

            modelBuilder.Entity<ThiSinh>(entity =>
            {
                entity.HasKey(e => new { e.MaPhong, e.Cccd });

                entity.Property(e => e.Cccd).IsUnicode(false);

                entity.Property(e => e.Sbd).IsUnicode(false);

                entity.HasOne(d => d.CccdNavigation)
                    .WithMany(p => p.ThiSinhs)
                    .HasForeignKey(d => d.Cccd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThiSinh_NguoiDung");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.ThiSinhs)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThiSinh_PhongThi");
            });

            modelBuilder.Entity<TrinhDo>(entity =>
            {
                entity.Property(e => e.TenTrinhDo).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
