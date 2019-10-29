namespace QLSV.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CSDLQlsv : DbContext
    {
        public CSDLQlsv()
            : base("name=CSDLQlsv")
        {
        }

        public virtual DbSet<BaoCao> BaoCaos { get; set; }
        public virtual DbSet<ChiTietGiangVien> ChiTietGiangViens { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhGia>()
                .HasMany(e => e.BaoCaos)
                .WithRequired(e => e.DanhGia)
                .HasForeignKey(e => e.id_DanhGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.ChiTietGiangViens)
                .WithRequired(e => e.GiangVien)
                .HasForeignKey(e => e.id_GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.ChiTietGiangViens)
                .WithRequired(e => e.Lop)
                .HasForeignKey(e => e.Id_Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.Lop)
                .HasForeignKey(e => e.id_Lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.BaoCaos)
                .WithRequired(e => e.MonHoc)
                .HasForeignKey(e => e.id_MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.ChiTietGiangViens)
                .WithRequired(e => e.MonHoc)
                .HasForeignKey(e => e.id_MonHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nganh>()
                .HasMany(e => e.MonHocs)
                .WithRequired(e => e.Nganh)
                .HasForeignKey(e => e.id_Nganh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nganh>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.Nganh)
                .HasForeignKey(e => e.id_Nganh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.gioiTinh)
                .IsFixedLength();

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MSSV)
                .IsFixedLength();

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.BaoCaos)
                .WithRequired(e => e.SinhVien)
                .HasForeignKey(e => e.id_SinhVien)
                .WillCascadeOnDelete(false);
        }
    }
}
