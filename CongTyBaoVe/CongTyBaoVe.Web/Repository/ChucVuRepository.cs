using CongTyBaoVe.Web.Entites;
using CongTyBaoVe.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongTyBaoVe.Web.Repository
{
	public class ChucVuRepository : RepositoryBase
	{
		
		public ChucVuRepository(CongTyBaoVeDbContext _db):base(_db)
		{
			
		}
		public async Task<List<ChucVu>> ToList()
		{
			return	await db.chucVus.ToListAsync();
		}
		public async Task AddChucVu(AddEditChucVuVM model)
		{
			ChucVu data = new ChucVu();
			data.Id = model.Id;
			data.ChucVuNhanVien = model.ChucVuNhanVien;
			await db.chucVus.AddAsync(data);
			await this.Save();
		}
		public ChucVu Find(int id)
		{
			var data =  db.chucVus.Find(id);
			return data;
		}
		public async Task Editchucvu(AddEditChucVuVM model)
		{
			var data = this.Find(model.Id);
			ChucVu chucVu = new ChucVu();
			chucVu.Id = model.Id;
			chucVu.ChucVuNhanVien = model.ChucVuNhanVien;
			this.Copy<ChucVu>(chucVu, data, "");
			await this.Save();
		}
		public void Delete(int id)
		{
			db.chucVus.Remove(this.Find(id));
		}

	}
}
