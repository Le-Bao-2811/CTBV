using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Entites
{
	public class CongTyBaoVeDbContext :DbContext
	{
		public DbSet<NhanVien> nhanViens { get; set; }
		public DbSet<ChucVu> chucVus { get; set; }
		public DbSet<User> users { get; set; }
		public CongTyBaoVeDbContext() : base()
		{

		}
		public CongTyBaoVeDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
