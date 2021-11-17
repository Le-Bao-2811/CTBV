using CongTyBaoVe.Web.Entites;
using CongTyBaoVe.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CongTyBaoVe.Web.Repository
{
	
	public class NhanVienRepository: RepositoryBase
	{
		public NhanVienRepository(CongTyBaoVeDbContext _db):base(_db)
		{

		}
		public  List<ListNhanVien> ToList()
		{

			var danhsach = db.nhanViens.Select(model => new ListNhanVien
			{
				Id = model.Id,
				TenNhanVien = model.TenNhanVien,
				NamSinh = model.NamSinh,
				SDT = model.SDT,
				TrangThai = model.TrangThai,
				DiaChi = model.DiaChi,
				ChucVu =model.chucVu.ChucVuNhanVien,
			})
			.OrderByDescending(u => u.Id)
			.ToList();
			return danhsach;
		}
		public async Task AddNhanVien(AddEditNhanVIenVM model)
		{
			NhanVien data = new NhanVien();
			data.Id = model.Id;
			data.TenNhanVien = model.TenNhanVien;
			data.NamSinh = model.NamSinh;
			data.SDT = model.SDT;
			data.TrangThai = model.TrangThai;
			data.IdChucVu = model.IdChucVu;
			data.DiaChi = model.DiaChi;
			await db.AddAsync(data);
			await this.Save();
		}
		public NhanVien Find(int id)
		{
			var data =  db.nhanViens.Find(id);
			return data;
		}
		public async Task EditNhanVien(AddEditNhanVIenVM model)
		{
			var datas = this.Find(model.Id);
			NhanVien data = new NhanVien();
			data.Id = model.Id;
			data.TenNhanVien = model.TenNhanVien;
			data.NamSinh = model.NamSinh;
			data.SDT = model.SDT;
			data.TrangThai = model.TrangThai;
			data.IdChucVu = model.IdChucVu;
			data.DiaChi = model.DiaChi; 
			this.Copy<NhanVien>(data, datas, "");
			await this.Save();
		}
		public void Delete(int id)
		{
			db.nhanViens.Remove(this.Find(id));
		}
	}
}
