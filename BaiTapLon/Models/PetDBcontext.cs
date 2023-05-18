using Microsoft.EntityFrameworkCore;

namespace BaiTapLon.Models
{
    public class PetDBcontext:DbContext
    {
        public PetDBcontext(DbContextOptions<PetDBcontext> options) : base(options) { }
        public DbSet<Pet> Pets { get; set;}
        public DbSet<DanhMuc> DanhMucs { get;set;}
        public DbSet<NguoiDung> NguoiDungs { get;set;}

        public DbSet<DonHang> DonHangs { get;set;}
        public DbSet<ChiTietDonHang> chiTietDonHangs { get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().ToTable("tbPet");
            modelBuilder.Entity<DonHang>().ToTable("tbDonHang");
            modelBuilder.Entity<ChiTietDonHang>().ToTable("tbChiTietDonHang");
            modelBuilder.Entity<NguoiDung>(e =>
            {
                e.ToTable("tbNguoiDung");
                e.Property(e => e.ChucVu).HasDefaultValue(0);

            });
            modelBuilder.Entity<DanhMuc>().ToTable("tbDanhMuc");
        }
    }
}
